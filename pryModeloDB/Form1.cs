using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace pryModeloDB
{
    public partial class Form1 : Form
    {
        private OleDbConnection currentConnection;

        public Form1()
        {
            InitializeComponent();
            ConfigureGrid();
            UpdateStatus("Selecciona una carpeta para comenzar.");
        }

        private void btnSeleccionarCarpeta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecciona una carpeta con archivos Access o Excel";

                if (folderDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                txtCarpeta.Text = folderDialog.SelectedPath;
                LoadCompatibleFiles(folderDialog.SelectedPath);
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarpeta.Text) || !Directory.Exists(txtCarpeta.Text))
            {
                MessageBox.Show("Primero debes seleccionar una carpeta valida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadCompatibleFiles(txtCarpeta.Text);
        }

        private void lstBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBases.SelectedItem == null)
            {
                return;
            }

            FileItem selectedFile = lstBases.SelectedItem as FileItem;
            if (selectedFile == null)
            {
                return;
            }

            CloseCurrentConnection();
            ClearTableSelection();

            currentConnection = DbConnector.TryConnect(selectedFile.Path);

            if (currentConnection == null)
            {
                UpdateStatus("No se pudo abrir el archivo seleccionado.");
                MessageBox.Show(
                    $"No se pudo abrir {selectedFile.Name}.{Environment.NewLine}{Environment.NewLine}{DbConnector.LastError}",
                    "Error de conexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var tables = DbConnector.GetTableNames(currentConnection);
            foreach (string table in tables.OrderBy(x => x))
            {
                lstTablas.Items.Add(table);
            }

            lblArchivoValor.Text = selectedFile.Name;
            UpdateStatus($"Archivo abierto: {selectedFile.Name}. Selecciona una tabla.");
        }

        private void lstTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentConnection == null || lstTablas.SelectedItem == null)
            {
                return;
            }

            string tableName = lstTablas.SelectedItem.ToString();
            DataTable table = DbConnector.GetTableData(currentConnection, tableName);
            dgvDatos.DataSource = table;

            if (table.Rows.Count == 0 && !string.IsNullOrWhiteSpace(DbConnector.LastError))
            {
                MessageBox.Show(
                    $"No se pudieron mostrar los datos de {tableName}.{Environment.NewLine}{Environment.NewLine}{DbConnector.LastError}",
                    "Error al cargar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                UpdateStatus("La tabla no pudo cargarse correctamente.");
                lblRegistrosValor.Text = "0";
                return;
            }

            lblTablaValor.Text = tableName;
            lblRegistrosValor.Text = table.Rows.Count.ToString();
            UpdateStatus($"Tabla cargada: {tableName}. Registros: {table.Rows.Count}.");
        }

        private void LoadCompatibleFiles(string folderPath)
        {
            var files = Directory
                .GetFiles(folderPath)
                .Where(file =>
                    file.EndsWith(".mdb", StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".accdb", StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".xls", StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                .OrderBy(Path.GetFileName)
                .ToArray();

            CloseCurrentConnection();
            lstBases.Items.Clear();
            ClearTableSelection();
            lblArchivoValor.Text = "-";

            foreach (string file in files)
            {
                lstBases.Items.Add(new FileItem(Path.GetFileName(file), file));
            }

            UpdateStatus($"Se encontraron {files.Length} archivo(s) compatibles.");

            if (files.Length == 0)
            {
                MessageBox.Show("La carpeta no contiene archivos Access o Excel.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearTableSelection()
        {
            lstTablas.Items.Clear();
            dgvDatos.DataSource = null;
            lblTablaValor.Text = "-";
            lblRegistrosValor.Text = "0";
        }

        private void ConfigureGrid()
        {
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvDatos.ReadOnly = true;
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.MultiSelect = false;
        }

        private void UpdateStatus(string message)
        {
            lblEstadoValor.Text = message;
        }

        private void CloseCurrentConnection()
        {
            try
            {
                if (currentConnection != null)
                {
                    currentConnection.Close();
                    currentConnection.Dispose();
                }
            }
            catch
            {
            }

            currentConnection = null;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CloseCurrentConnection();
            base.OnFormClosing(e);
        }

        private class FileItem
        {
            public string Name { get; private set; }
            public string Path { get; private set; }

            public FileItem(string name, string path)
            {
                Name = name;
                Path = path;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
