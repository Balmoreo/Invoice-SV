namespace MD_Facturas
{
    partial class ImporData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImporData));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataGExcel = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.BttCargar = new System.Windows.Forms.Button();
            this.BttFacturacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.DataGExcel);
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1102, 535);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Excel";
            // 
            // DataGExcel
            // 
            this.DataGExcel.AllowUserToAddRows = false;
            this.DataGExcel.AllowUserToDeleteRows = false;
            this.DataGExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGExcel.Location = new System.Drawing.Point(3, 16);
            this.DataGExcel.Name = "DataGExcel";
            this.DataGExcel.ReadOnly = true;
            this.DataGExcel.Size = new System.Drawing.Size(1096, 516);
            this.DataGExcel.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label19.Location = new System.Drawing.Point(26, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 17);
            this.label19.TabIndex = 15;
            this.label19.Text = "Importar Excel:";
            // 
            // BttCargar
            // 
            this.BttCargar.Image = ((System.Drawing.Image)(resources.GetObject("BttCargar.Image")));
            this.BttCargar.Location = new System.Drawing.Point(186, 3);
            this.BttCargar.Name = "BttCargar";
            this.BttCargar.Size = new System.Drawing.Size(115, 75);
            this.BttCargar.TabIndex = 16;
            this.BttCargar.Text = "Cargar";
            this.BttCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BttCargar.UseVisualStyleBackColor = true;
            this.BttCargar.Click += new System.EventHandler(this.BttCargar_Click);
            // 
            // BttFacturacion
            // 
            this.BttFacturacion.Enabled = false;
            this.BttFacturacion.Image = ((System.Drawing.Image)(resources.GetObject("BttFacturacion.Image")));
            this.BttFacturacion.Location = new System.Drawing.Point(540, 3);
            this.BttFacturacion.Name = "BttFacturacion";
            this.BttFacturacion.Size = new System.Drawing.Size(115, 75);
            this.BttFacturacion.TabIndex = 17;
            this.BttFacturacion.Text = "Facturacion";
            this.BttFacturacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BttFacturacion.UseVisualStyleBackColor = true;
            this.BttFacturacion.Click += new System.EventHandler(this.BttFacturacion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(351, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Convertir a Facturas:";
            // 
            // ImporData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 618);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BttFacturacion);
            this.Controls.Add(this.BttCargar);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.groupBox1);
            this.Name = "ImporData";
            this.Text = "Importar Datos";
            this.Load += new System.EventHandler(this.ImporData_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView DataGExcel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button BttCargar;
        private System.Windows.Forms.Button BttFacturacion;
        private System.Windows.Forms.Label label1;
    }
}