namespace pryModeloDB
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSeleccionarCarpeta = new System.Windows.Forms.Button();
            this.lstBases = new System.Windows.Forms.ListBox();
            this.lstTablas = new System.Windows.Forms.ListBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.lblCarpeta = new System.Windows.Forms.Label();
            this.txtCarpeta = new System.Windows.Forms.TextBox();
            this.btnRecargar = new System.Windows.Forms.Button();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.lblArchivoValor = new System.Windows.Forms.Label();
            this.lblTabla = new System.Windows.Forms.Label();
            this.lblTablaValor = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblRegistrosValor = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblEstadoValor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeleccionarCarpeta
            // 
            this.btnSeleccionarCarpeta.Location = new System.Drawing.Point(12, 39);
            this.btnSeleccionarCarpeta.Name = "btnSeleccionarCarpeta";
            this.btnSeleccionarCarpeta.Size = new System.Drawing.Size(172, 31);
            this.btnSeleccionarCarpeta.TabIndex = 0;
            this.btnSeleccionarCarpeta.Text = "Seleccionar carpeta";
            this.btnSeleccionarCarpeta.UseVisualStyleBackColor = true;
            this.btnSeleccionarCarpeta.Click += new System.EventHandler(this.btnSeleccionarCarpeta_Click);
            // 
            // lstBases
            // 
            this.lstBases.FormattingEnabled = true;
            this.lstBases.Location = new System.Drawing.Point(12, 124);
            this.lstBases.Name = "lstBases";
            this.lstBases.Size = new System.Drawing.Size(277, 160);
            this.lstBases.TabIndex = 1;
            this.lstBases.SelectedIndexChanged += new System.EventHandler(this.lstBases_SelectedIndexChanged);
            // 
            // lstTablas
            // 
            this.lstTablas.FormattingEnabled = true;
            this.lstTablas.Location = new System.Drawing.Point(307, 124);
            this.lstTablas.Name = "lstTablas";
            this.lstTablas.Size = new System.Drawing.Size(214, 160);
            this.lstTablas.TabIndex = 2;
            this.lstTablas.SelectedIndexChanged += new System.EventHandler(this.lstTablas_SelectedIndexChanged);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 315);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(886, 284);
            this.dgvDatos.TabIndex = 3;
            // 
            // lblCarpeta
            // 
            this.lblCarpeta.AutoSize = true;
            this.lblCarpeta.Location = new System.Drawing.Point(12, 15);
            this.lblCarpeta.Name = "lblCarpeta";
            this.lblCarpeta.Size = new System.Drawing.Size(97, 13);
            this.lblCarpeta.TabIndex = 4;
            this.lblCarpeta.Text = "Carpeta analizada:";
            // 
            // txtCarpeta
            // 
            this.txtCarpeta.Location = new System.Drawing.Point(190, 45);
            this.txtCarpeta.Name = "txtCarpeta";
            this.txtCarpeta.ReadOnly = true;
            this.txtCarpeta.Size = new System.Drawing.Size(561, 20);
            this.txtCarpeta.TabIndex = 5;
            // 
            // btnRecargar
            // 
            this.btnRecargar.Location = new System.Drawing.Point(763, 39);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(135, 31);
            this.btnRecargar.TabIndex = 6;
            this.btnRecargar.Text = "Recargar lista";
            this.btnRecargar.UseVisualStyleBackColor = true;
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(544, 124);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(41, 13);
            this.lblArchivo.TabIndex = 7;
            this.lblArchivo.Text = "Archivo";
            // 
            // lblArchivoValor
            // 
            this.lblArchivoValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblArchivoValor.Location = new System.Drawing.Point(547, 141);
            this.lblArchivoValor.Name = "lblArchivoValor";
            this.lblArchivoValor.Size = new System.Drawing.Size(351, 27);
            this.lblArchivoValor.TabIndex = 8;
            this.lblArchivoValor.Text = "-";
            this.lblArchivoValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTabla
            // 
            this.lblTabla.AutoSize = true;
            this.lblTabla.Location = new System.Drawing.Point(544, 181);
            this.lblTabla.Name = "lblTabla";
            this.lblTabla.Size = new System.Drawing.Size(34, 13);
            this.lblTabla.TabIndex = 9;
            this.lblTabla.Text = "Tabla";
            // 
            // lblTablaValor
            // 
            this.lblTablaValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTablaValor.Location = new System.Drawing.Point(547, 198);
            this.lblTablaValor.Name = "lblTablaValor";
            this.lblTablaValor.Size = new System.Drawing.Size(351, 27);
            this.lblTablaValor.TabIndex = 10;
            this.lblTablaValor.Text = "-";
            this.lblTablaValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(544, 239);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(49, 13);
            this.lblRegistros.TabIndex = 11;
            this.lblRegistros.Text = "Registros";
            // 
            // lblRegistrosValor
            // 
            this.lblRegistrosValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRegistrosValor.Location = new System.Drawing.Point(547, 256);
            this.lblRegistrosValor.Name = "lblRegistrosValor";
            this.lblRegistrosValor.Size = new System.Drawing.Size(126, 27);
            this.lblRegistrosValor.TabIndex = 12;
            this.lblRegistrosValor.Text = "0";
            this.lblRegistrosValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(12, 92);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 13;
            this.lblEstado.Text = "Estado:";
            // 
            // lblEstadoValor
            // 
            this.lblEstadoValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEstadoValor.Location = new System.Drawing.Point(70, 86);
            this.lblEstadoValor.Name = "lblEstadoValor";
            this.lblEstadoValor.Size = new System.Drawing.Size(828, 24);
            this.lblEstadoValor.TabIndex = 14;
            this.lblEstadoValor.Text = "-";
            this.lblEstadoValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 611);
            this.Controls.Add(this.lblEstadoValor);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblRegistrosValor);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.lblTablaValor);
            this.Controls.Add(this.lblTabla);
            this.Controls.Add(this.lblArchivoValor);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.btnRecargar);
            this.Controls.Add(this.txtCarpeta);
            this.Controls.Add(this.lblCarpeta);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.lstTablas);
            this.Controls.Add(this.lstBases);
            this.Controls.Add(this.btnSeleccionarCarpeta);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modelo de Explorador de BD";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSeleccionarCarpeta;
        private System.Windows.Forms.ListBox lstBases;
        private System.Windows.Forms.ListBox lstTablas;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label lblCarpeta;
        private System.Windows.Forms.TextBox txtCarpeta;
        private System.Windows.Forms.Button btnRecargar;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.Label lblArchivoValor;
        private System.Windows.Forms.Label lblTabla;
        private System.Windows.Forms.Label lblTablaValor;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblRegistrosValor;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblEstadoValor;
    }
}
