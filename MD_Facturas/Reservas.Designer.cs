namespace MD_Facturas
{
    partial class Reservas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reservas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Lb_FcIni = new System.Windows.Forms.Label();
            this.DateInicio = new System.Windows.Forms.DateTimePicker();
            this.DateFin = new System.Windows.Forms.DateTimePicker();
            this.Lb_FcFin = new System.Windows.Forms.Label();
            this.Btt_Buscar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Btt_Facturar = new System.Windows.Forms.Button();
            this.Btt_Cancelar = new System.Windows.Forms.Button();
            this.mODULO_FACT_VECADataSet = new MD_Facturas.MODULO_FACT_VECADataSet();
            this.tblReservasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_ReservasTableAdapter = new MD_Facturas.MODULO_FACT_VECADataSetTableAdapters.Tbl_ReservasTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mODULO_FACT_VECADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReservasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Lb_FcIni
            // 
            this.Lb_FcIni.AutoSize = true;
            this.Lb_FcIni.Location = new System.Drawing.Point(72, 34);
            this.Lb_FcIni.Name = "Lb_FcIni";
            this.Lb_FcIni.Size = new System.Drawing.Size(32, 13);
            this.Lb_FcIni.TabIndex = 0;
            this.Lb_FcIni.Text = "Inicio";
            // 
            // DateInicio
            // 
            this.DateInicio.Location = new System.Drawing.Point(121, 28);
            this.DateInicio.Name = "DateInicio";
            this.DateInicio.Size = new System.Drawing.Size(200, 20);
            this.DateInicio.TabIndex = 1;
            this.DateInicio.Validated += new System.EventHandler(this.DateInicio_Validated);
            // 
            // DateFin
            // 
            this.DateFin.Location = new System.Drawing.Point(119, 67);
            this.DateFin.Name = "DateFin";
            this.DateFin.Size = new System.Drawing.Size(200, 20);
            this.DateFin.TabIndex = 3;
            // 
            // Lb_FcFin
            // 
            this.Lb_FcFin.AutoSize = true;
            this.Lb_FcFin.Location = new System.Drawing.Point(72, 73);
            this.Lb_FcFin.Name = "Lb_FcFin";
            this.Lb_FcFin.Size = new System.Drawing.Size(29, 13);
            this.Lb_FcFin.TabIndex = 2;
            this.Lb_FcFin.Text = "Final";
            // 
            // Btt_Buscar
            // 
            this.Btt_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btt_Buscar.Image")));
            this.Btt_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_Buscar.Location = new System.Drawing.Point(346, 25);
            this.Btt_Buscar.Name = "Btt_Buscar";
            this.Btt_Buscar.Size = new System.Drawing.Size(75, 62);
            this.Btt_Buscar.TabIndex = 4;
            this.Btt_Buscar.Text = "Buscar";
            this.Btt_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_Buscar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dataGridView1.DataSource = this.tblReservasBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(25, 125);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(735, 229);
            this.dataGridView1.TabIndex = 5;
            // 
            // Btt_Facturar
            // 
            this.Btt_Facturar.Image = ((System.Drawing.Image)(resources.GetObject("Btt_Facturar.Image")));
            this.Btt_Facturar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_Facturar.Location = new System.Drawing.Point(472, 25);
            this.Btt_Facturar.Name = "Btt_Facturar";
            this.Btt_Facturar.Size = new System.Drawing.Size(75, 62);
            this.Btt_Facturar.TabIndex = 6;
            this.Btt_Facturar.Text = "Facturar";
            this.Btt_Facturar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_Facturar.UseVisualStyleBackColor = true;
            this.Btt_Facturar.Click += new System.EventHandler(this.Btt_Facturar_Click);
            // 
            // Btt_Cancelar
            // 
            this.Btt_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Btt_Cancelar.Image")));
            this.Btt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_Cancelar.Location = new System.Drawing.Point(598, 24);
            this.Btt_Cancelar.Name = "Btt_Cancelar";
            this.Btt_Cancelar.Size = new System.Drawing.Size(75, 62);
            this.Btt_Cancelar.TabIndex = 7;
            this.Btt_Cancelar.Text = "Cancelar";
            this.Btt_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_Cancelar.UseVisualStyleBackColor = true;
            // 
            // mODULO_FACT_VECADataSet
            // 
            this.mODULO_FACT_VECADataSet.DataSetName = "MODULO_FACT_VECADataSet";
            this.mODULO_FACT_VECADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblReservasBindingSource
            // 
            this.tblReservasBindingSource.DataMember = "Tbl_Reservas";
            this.tblReservasBindingSource.DataSource = this.mODULO_FACT_VECADataSet;
            // 
            // tbl_ReservasTableAdapter
            // 
            this.tbl_ReservasTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "No_Boleto";
            this.dataGridViewTextBoxColumn1.HeaderText = "No_Boleto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Id_cliente";
            this.dataGridViewTextBoxColumn2.HeaderText = "Id_cliente";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Ruta";
            this.dataGridViewTextBoxColumn3.HeaderText = "Ruta";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Monto_Total";
            this.dataGridViewTextBoxColumn4.HeaderText = "Monto_Total";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Monto_Sujeto";
            this.dataGridViewTextBoxColumn5.HeaderText = "Monto_Sujeto";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Monto_Exento";
            this.dataGridViewTextBoxColumn6.HeaderText = "Monto_Exento";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Fecha";
            this.dataGridViewTextBoxColumn7.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn8.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Pasaporte";
            this.dataGridViewTextBoxColumn9.HeaderText = "Pasaporte";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "No_Reserva";
            this.dataGridViewTextBoxColumn10.HeaderText = "No_Reserva";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // Reservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 380);
            this.Controls.Add(this.Btt_Cancelar);
            this.Controls.Add(this.Btt_Facturar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Btt_Buscar);
            this.Controls.Add(this.DateFin);
            this.Controls.Add(this.Lb_FcFin);
            this.Controls.Add(this.DateInicio);
            this.Controls.Add(this.Lb_FcIni);
            this.Name = "Reservas";
            this.Text = "Reservas";
            this.Load += new System.EventHandler(this.Reservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mODULO_FACT_VECADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReservasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lb_FcIni;
        private System.Windows.Forms.DateTimePicker DateInicio;
        private System.Windows.Forms.DateTimePicker DateFin;
        private System.Windows.Forms.Label Lb_FcFin;
        private System.Windows.Forms.Button Btt_Buscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn noBoletoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pasaporteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoSujetoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoExentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button Btt_Facturar;
        private System.Windows.Forms.Button Btt_Cancelar;
        private MODULO_FACT_VECADataSet mODULO_FACT_VECADataSet;
        private System.Windows.Forms.BindingSource tblReservasBindingSource;
        private MODULO_FACT_VECADataSetTableAdapters.Tbl_ReservasTableAdapter tbl_ReservasTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}