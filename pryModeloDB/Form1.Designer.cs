namespace pryModeloDB
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSeleccionarArchivo;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.ComboBox cmbTablas;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.Label lblTabla;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnLimpiar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnSeleccionarArchivo = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.cmbTablas = new System.Windows.Forms.ComboBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.lblTabla = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeleccionarArchivo
            // 
            this.btnSeleccionarArchivo.Location = new System.Drawing.Point(12, 34);
            this.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            this.btnSeleccionarArchivo.Size = new System.Drawing.Size(150, 30);
            this.btnSeleccionarArchivo.TabIndex = 0;
            this.btnSeleccionarArchivo.Text = "Seleccionar Access";
            this.btnSeleccionarArchivo.BackColor = System.Drawing.Color.FromArgb(111, 86, 67);
            this.btnSeleccionarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarArchivo.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarArchivo.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarArchivo.UseVisualStyleBackColor = false;
            this.btnSeleccionarArchivo.Click += new System.EventHandler(this.btnSeleccionarArchivo_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(168, 39);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.BackColor = System.Drawing.Color.FromArgb(250, 247, 242);
            this.txtArchivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArchivo.Size = new System.Drawing.Size(480, 22);
            this.txtArchivo.TabIndex = 1;
            // 
            // cmbTablas
            // 
            this.cmbTablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTablas.FormattingEnabled = true;
            this.cmbTablas.Location = new System.Drawing.Point(75, 82);
            this.cmbTablas.Name = "cmbTablas";
            this.cmbTablas.Size = new System.Drawing.Size(250, 21);
            this.cmbTablas.BackColor = System.Drawing.Color.FromArgb(250, 247, 242);
            this.cmbTablas.TabIndex = 2;
            this.cmbTablas.SelectedIndexChanged += new System.EventHandler(this.cmbTablas_SelectedIndexChanged);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 125);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(756, 360);
            this.dgvDatos.TabIndex = 3;
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(12, 14);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(46, 13);
            this.lblArchivo.TabIndex = 4;
            this.lblArchivo.Text = "Archivo:";
            // 
            // lblTabla
            // 
            this.lblTabla.AutoSize = true;
            this.lblTabla.Location = new System.Drawing.Point(12, 85);
            this.lblTabla.Name = "lblTabla";
            this.lblTabla.Size = new System.Drawing.Size(39, 13);
            this.lblTabla.TabIndex = 5;
            this.lblTabla.Text = "Tabla:";
            // 
            // lblEstado
            // 
            this.lblEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEstado.Location = new System.Drawing.Point(12, 499);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(756, 24);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Seleccione un archivo Access.";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEstado.BackColor = System.Drawing.Color.FromArgb(250, 247, 242);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(664, 34);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(104, 30);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(150, 132, 112);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 235, 226);
            this.ClientSize = new System.Drawing.Size(780, 535);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblTabla);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.cmbTablas);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.btnSeleccionarArchivo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modelo minimo Access";
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
