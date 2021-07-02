namespace MD_Facturas
{
    partial class VerClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerClientes));
            this.gvClientes = new System.Windows.Forms.DataGridView();
            this.TxtBusCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btt_Buscar = new System.Windows.Forms.Button();
            this.Id_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // gvClientes
            // 
            this.gvClientes.AllowUserToAddRows = false;
            this.gvClientes.AllowUserToDeleteRows = false;
            this.gvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_cliente,
            this.Nombre});
            this.gvClientes.Location = new System.Drawing.Point(39, 92);
            this.gvClientes.Name = "gvClientes";
            this.gvClientes.ReadOnly = true;
            this.gvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvClientes.Size = new System.Drawing.Size(829, 313);
            this.gvClientes.TabIndex = 0;
            this.gvClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvClientes_CellDoubleClick);
            // 
            // TxtBusCliente
            // 
            this.TxtBusCliente.Location = new System.Drawing.Point(172, 27);
            this.TxtBusCliente.Name = "TxtBusCliente";
            this.TxtBusCliente.Size = new System.Drawing.Size(465, 20);
            this.TxtBusCliente.TabIndex = 1;
            this.TxtBusCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBusCliente_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // Btt_Buscar
            // 
            this.Btt_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btt_Buscar.Image")));
            this.Btt_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_Buscar.Location = new System.Drawing.Point(737, 12);
            this.Btt_Buscar.Name = "Btt_Buscar";
            this.Btt_Buscar.Size = new System.Drawing.Size(75, 62);
            this.Btt_Buscar.TabIndex = 13;
            this.Btt_Buscar.Text = "Buscar";
            this.Btt_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_Buscar.UseVisualStyleBackColor = true;
            this.Btt_Buscar.Click += new System.EventHandler(this.Btt_Buscar_Click);
            // 
            // Id_cliente
            // 
            this.Id_cliente.DataPropertyName = "Id_cliente";
            this.Id_cliente.HeaderText = "Codigo Cliente";
            this.Id_cliente.Name = "Id_cliente";
            this.Id_cliente.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // VerClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 417);
            this.Controls.Add(this.Btt_Buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBusCliente);
            this.Controls.Add(this.gvClientes);
            this.Name = "VerClientes";
            this.Text = "VerClientes";
            ((System.ComponentModel.ISupportInitialize)(this.gvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvClientes;
        private System.Windows.Forms.TextBox TxtBusCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btt_Buscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}