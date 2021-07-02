namespace MD_Facturas
{
    partial class Informacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Informacion));
            this.DataGridInformacion = new System.Windows.Forms.DataGridView();
            this.Btt_Buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBusCliente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridInformacion)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridInformacion
            // 
            this.DataGridInformacion.AllowUserToAddRows = false;
            this.DataGridInformacion.AllowUserToDeleteRows = false;
            this.DataGridInformacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridInformacion.Location = new System.Drawing.Point(0, 95);
            this.DataGridInformacion.Name = "DataGridInformacion";
            this.DataGridInformacion.ReadOnly = true;
            this.DataGridInformacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridInformacion.Size = new System.Drawing.Size(1054, 467);
            this.DataGridInformacion.TabIndex = 0;
            this.DataGridInformacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridInformacion_CellDoubleClick);
            // 
            // Btt_Buscar
            // 
            this.Btt_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btt_Buscar.Image")));
            this.Btt_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_Buscar.Location = new System.Drawing.Point(773, 17);
            this.Btt_Buscar.Name = "Btt_Buscar";
            this.Btt_Buscar.Size = new System.Drawing.Size(75, 62);
            this.Btt_Buscar.TabIndex = 16;
            this.Btt_Buscar.Text = "Buscar";
            this.Btt_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_Buscar.UseVisualStyleBackColor = true;
            this.Btt_Buscar.Click += new System.EventHandler(this.Btt_Buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nombre";
            // 
            // TxtBusCliente
            // 
            this.TxtBusCliente.Location = new System.Drawing.Point(208, 32);
            this.TxtBusCliente.Name = "TxtBusCliente";
            this.TxtBusCliente.Size = new System.Drawing.Size(465, 20);
            this.TxtBusCliente.TabIndex = 14;
            this.TxtBusCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBusCliente_KeyDown);
            // 
            // Informacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1054, 562);
            this.Controls.Add(this.Btt_Buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBusCliente);
            this.Controls.Add(this.DataGridInformacion);
            this.Name = "Informacion";
            this.Text = "Informacion";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridInformacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DataGridInformacion;
        private System.Windows.Forms.Button Btt_Buscar;
        private System.Windows.Forms.TextBox TxtBusCliente;
        public System.Windows.Forms.Label label1;

    }
}