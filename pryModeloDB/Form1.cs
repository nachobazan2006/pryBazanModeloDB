using System;
using System.Data;
using System.Windows.Forms;

namespace pryModeloDB
{
    public partial class Form1 : Form
    {
        private readonly DbConnector dbConnector;

        public Form1()
        {
            InitializeComponent();
            dbConnector = new DbConnector();
            ConfigurarGrilla();
        }

        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar archivo Access";
                dialogo.Filter = "Archivos Access (*.mdb;*.accdb)|*.mdb;*.accdb";

                if (dialogo.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    dbConnector.Conectar(dialogo.FileName);
                    txtArchivo.Text = dialogo.FileName;
                    CargarTablas();
                    lblEstado.Text = "Archivo conectado.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el archivo: " + ex.Message, "Conexion Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblEstado.Text = "Error de conexion.";
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void cmbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreTabla = ObtenerTablaSeleccionada();

            if (string.IsNullOrWhiteSpace(nombreTabla))
            {
                return;
            }

            CargarDatos(nombreTabla);
        }

        private void CargarTablas()
        {
            DataTable tablas = dbConnector.ObtenerTablas();
            cmbTablas.SelectedIndexChanged -= cmbTablas_SelectedIndexChanged;
            cmbTablas.DataSource = tablas;
            cmbTablas.DisplayMember = "NombreTabla";
            cmbTablas.ValueMember = "NombreTabla";
            cmbTablas.SelectedIndexChanged += cmbTablas_SelectedIndexChanged;
            lblEstado.Text = "Tablas encontradas: " + tablas.Rows.Count;

            if (tablas.Rows.Count > 0)
            {
                cmbTablas.SelectedIndex = 0;
                CargarDatos(tablas.Rows[0]["NombreTabla"].ToString());
            }
        }

        private void CargarDatos(string nombreTabla)
        {
            DataTable datos = dbConnector.ObtenerDatos(nombreTabla);
            dgvDatos.DataSource = datos;
            lblEstado.Text = "Tabla: " + nombreTabla + " - Registros: " + datos.Rows.Count;
        }

        private void ConfigurarGrilla()
        {
            dgvDatos.ReadOnly = true;
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvDatos.BackgroundColor = System.Drawing.Color.FromArgb(250, 247, 242);
            dgvDatos.BorderStyle = BorderStyle.None;
            dgvDatos.GridColor = System.Drawing.Color.FromArgb(224, 215, 204);
            dgvDatos.EnableHeadersVisualStyles = false;
            dgvDatos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(92, 73, 58);
            dgvDatos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvDatos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Bold);
            dgvDatos.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 8.5F, System.Drawing.FontStyle.Italic);
            dgvDatos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(226, 211, 190);
            dgvDatos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(42, 36, 31);
            dgvDatos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 237, 228);
            dgvDatos.RowHeadersVisible = false;
        }

        private void LimpiarFormulario()
        {
            dbConnector.Cerrar();
            txtArchivo.Clear();
            cmbTablas.SelectedIndexChanged -= cmbTablas_SelectedIndexChanged;
            cmbTablas.DataSource = null;
            cmbTablas.Items.Clear();
            cmbTablas.SelectedIndexChanged += cmbTablas_SelectedIndexChanged;
            dgvDatos.DataSource = null;
            lblEstado.Text = "Seleccione un archivo Access.";
        }

        private string ObtenerTablaSeleccionada()
        {
            DataRowView fila = cmbTablas.SelectedItem as DataRowView;

            if (fila != null)
            {
                return fila["NombreTabla"].ToString();
            }

            return cmbTablas.SelectedValue as string;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            dbConnector.Cerrar();
            base.OnFormClosing(e);
        }
    }
}
