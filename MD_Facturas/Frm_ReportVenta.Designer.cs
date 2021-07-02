namespace MD_Facturas
{
    partial class Frm_ReportVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ReportVenta));
            this.TextNofact = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cBoxBusqDocum = new System.Windows.Forms.ComboBox();
            this.tblTipoDocReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mODULO_FACT_VECADataSet = new MD_Facturas.MODULO_FACT_VECADataSet();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rBttNoFact = new System.Windows.Forms.RadioButton();
            this.rBttAnulados = new System.Windows.Forms.RadioButton();
            this.rBttImpresos = new System.Windows.Forms.RadioButton();
            this.rBttAll = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.DatePkFin = new System.Windows.Forms.DateTimePicker();
            this.DatePkINI = new System.Windows.Forms.DateTimePicker();
            this.Btt_FactRecAct = new System.Windows.Forms.Button();
            this.tbl_Tipo_DocReportTableAdapter = new MD_Facturas.MODULO_FACT_VECADataSetTableAdapters.Tbl_Tipo_DocReportTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CboxPVfact = new System.Windows.Forms.ComboBox();
            this.tblPuntoVentaBusquedaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_Punto_VentaBusquedaTableAdapter = new MD_Facturas.MODULO_FACT_VECADataSetTableAdapters.Tbl_Punto_VentaBusquedaTableAdapter();
            this.CboxAllPv = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblTipoDocReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mODULO_FACT_VECADataSet)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblPuntoVentaBusquedaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TextNofact
            // 
            this.TextNofact.Enabled = false;
            this.TextNofact.Location = new System.Drawing.Point(719, 75);
            this.TextNofact.Name = "TextNofact";
            this.TextNofact.Size = new System.Drawing.Size(105, 20);
            this.TextNofact.TabIndex = 46;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(653, 78);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 13);
            this.label23.TabIndex = 45;
            this.label23.Text = "No. Factura";
            // 
            // cBoxBusqDocum
            // 
            this.cBoxBusqDocum.DataSource = this.tblTipoDocReportBindingSource;
            this.cBoxBusqDocum.DisplayMember = "Tipo_Doc";
            this.cBoxBusqDocum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxBusqDocum.FormattingEnabled = true;
            this.cBoxBusqDocum.Location = new System.Drawing.Point(719, 45);
            this.cBoxBusqDocum.Name = "cBoxBusqDocum";
            this.cBoxBusqDocum.Size = new System.Drawing.Size(169, 21);
            this.cBoxBusqDocum.TabIndex = 44;
            this.cBoxBusqDocum.ValueMember = "Cod_Doc";
            // 
            // tblTipoDocReportBindingSource
            // 
            this.tblTipoDocReportBindingSource.DataMember = "Tbl_Tipo_DocReport";
            this.tblTipoDocReportBindingSource.DataSource = this.mODULO_FACT_VECADataSet;
            // 
            // mODULO_FACT_VECADataSet
            // 
            this.mODULO_FACT_VECADataSet.DataSetName = "MODULO_FACT_VECADataSet";
            this.mODULO_FACT_VECADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(630, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 13);
            this.label22.TabIndex = 43;
            this.label22.Text = "Tipo Documento";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rBttNoFact);
            this.groupBox7.Controls.Add(this.rBttAnulados);
            this.groupBox7.Controls.Add(this.rBttImpresos);
            this.groupBox7.Controls.Add(this.rBttAll);
            this.groupBox7.Location = new System.Drawing.Point(449, 42);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(175, 65);
            this.groupBox7.TabIndex = 42;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Opciones de Documentos";
            // 
            // rBttNoFact
            // 
            this.rBttNoFact.AutoSize = true;
            this.rBttNoFact.Location = new System.Drawing.Point(76, 39);
            this.rBttNoFact.Name = "rBttNoFact";
            this.rBttNoFact.Size = new System.Drawing.Size(97, 17);
            this.rBttNoFact.TabIndex = 3;
            this.rBttNoFact.TabStop = true;
            this.rBttNoFact.Text = "No Documento";
            this.rBttNoFact.UseVisualStyleBackColor = true;
            this.rBttNoFact.CheckedChanged += new System.EventHandler(this.rBttNoFact_CheckedChanged);
            // 
            // rBttAnulados
            // 
            this.rBttAnulados.AutoSize = true;
            this.rBttAnulados.Location = new System.Drawing.Point(76, 16);
            this.rBttAnulados.Name = "rBttAnulados";
            this.rBttAnulados.Size = new System.Drawing.Size(69, 17);
            this.rBttAnulados.TabIndex = 2;
            this.rBttAnulados.TabStop = true;
            this.rBttAnulados.Text = "Anulados";
            this.rBttAnulados.UseVisualStyleBackColor = true;
            // 
            // rBttImpresos
            // 
            this.rBttImpresos.AutoSize = true;
            this.rBttImpresos.Location = new System.Drawing.Point(6, 39);
            this.rBttImpresos.Name = "rBttImpresos";
            this.rBttImpresos.Size = new System.Drawing.Size(67, 17);
            this.rBttImpresos.TabIndex = 1;
            this.rBttImpresos.TabStop = true;
            this.rBttImpresos.Text = "Impresos";
            this.rBttImpresos.UseVisualStyleBackColor = true;
            // 
            // rBttAll
            // 
            this.rBttAll.AutoSize = true;
            this.rBttAll.Checked = true;
            this.rBttAll.Location = new System.Drawing.Point(6, 16);
            this.rBttAll.Name = "rBttAll";
            this.rBttAll.Size = new System.Drawing.Size(55, 17);
            this.rBttAll.TabIndex = 0;
            this.rBttAll.TabStop = true;
            this.rBttAll.Text = "Todos";
            this.rBttAll.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Blue;
            this.label19.Location = new System.Drawing.Point(3, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(111, 13);
            this.label19.TabIndex = 41;
            this.label19.Text = "Rango de Fechas:";
            // 
            // DatePkFin
            // 
            this.DatePkFin.Location = new System.Drawing.Point(6, 75);
            this.DatePkFin.Name = "DatePkFin";
            this.DatePkFin.Size = new System.Drawing.Size(200, 20);
            this.DatePkFin.TabIndex = 40;
            // 
            // DatePkINI
            // 
            this.DatePkINI.Location = new System.Drawing.Point(6, 49);
            this.DatePkINI.Name = "DatePkINI";
            this.DatePkINI.Size = new System.Drawing.Size(200, 20);
            this.DatePkINI.TabIndex = 39;
            this.DatePkINI.ValueChanged += new System.EventHandler(this.DatePkINI_ValueChanged);
            // 
            // Btt_FactRecAct
            // 
            this.Btt_FactRecAct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Btt_FactRecAct.Image = ((System.Drawing.Image)(resources.GetObject("Btt_FactRecAct.Image")));
            this.Btt_FactRecAct.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_FactRecAct.Location = new System.Drawing.Point(907, 42);
            this.Btt_FactRecAct.Name = "Btt_FactRecAct";
            this.Btt_FactRecAct.Size = new System.Drawing.Size(75, 53);
            this.Btt_FactRecAct.TabIndex = 38;
            this.Btt_FactRecAct.Text = "Actualizar";
            this.Btt_FactRecAct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_FactRecAct.UseVisualStyleBackColor = true;
            this.Btt_FactRecAct.Click += new System.EventHandler(this.Btt_FactRecAct_Click);
            // 
            // tbl_Tipo_DocReportTableAdapter
            // 
            this.tbl_Tipo_DocReportTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CboxAllPv);
            this.groupBox1.Controls.Add(this.CboxPVfact);
            this.groupBox1.Location = new System.Drawing.Point(212, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 72);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Punto de venta";
            // 
            // CboxPVfact
            // 
            this.CboxPVfact.DataSource = this.tblPuntoVentaBusquedaBindingSource;
            this.CboxPVfact.DisplayMember = "Nombre_Punto";
            this.CboxPVfact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxPVfact.FormattingEnabled = true;
            this.CboxPVfact.Location = new System.Drawing.Point(6, 42);
            this.CboxPVfact.Name = "CboxPVfact";
            this.CboxPVfact.Size = new System.Drawing.Size(188, 21);
            this.CboxPVfact.TabIndex = 0;
            this.CboxPVfact.ValueMember = "Cod_Punto_Venta";
            // 
            // tblPuntoVentaBusquedaBindingSource
            // 
            this.tblPuntoVentaBusquedaBindingSource.DataMember = "Tbl_Punto_VentaBusqueda";
            this.tblPuntoVentaBusquedaBindingSource.DataSource = this.mODULO_FACT_VECADataSet;
            // 
            // tbl_Punto_VentaBusquedaTableAdapter
            // 
            this.tbl_Punto_VentaBusquedaTableAdapter.ClearBeforeFill = true;
            // 
            // CboxAllPv
            // 
            this.CboxAllPv.AutoSize = true;
            this.CboxAllPv.Location = new System.Drawing.Point(8, 18);
            this.CboxAllPv.Name = "CboxAllPv";
            this.CboxAllPv.Size = new System.Drawing.Size(56, 17);
            this.CboxAllPv.TabIndex = 1;
            this.CboxAllPv.Text = "Todos";
            this.CboxAllPv.UseVisualStyleBackColor = true;
            this.CboxAllPv.CheckedChanged += new System.EventHandler(this.CboxAllPv_CheckedChanged);
            // 
            // Frm_ReportVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 126);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TextNofact);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cBoxBusqDocum);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.DatePkFin);
            this.Controls.Add(this.DatePkINI);
            this.Controls.Add(this.Btt_FactRecAct);
            this.Name = "Frm_ReportVenta";
            this.Text = "Reporte Ventas";
            this.Load += new System.EventHandler(this.Frm_ReportVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblTipoDocReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mODULO_FACT_VECADataSet)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblPuntoVentaBusquedaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextNofact;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cBoxBusqDocum;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rBttNoFact;
        private System.Windows.Forms.RadioButton rBttAnulados;
        private System.Windows.Forms.RadioButton rBttImpresos;
        private System.Windows.Forms.RadioButton rBttAll;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker DatePkFin;
        private System.Windows.Forms.DateTimePicker DatePkINI;
        private System.Windows.Forms.Button Btt_FactRecAct;
        private System.Windows.Forms.BindingSource tblTipoDocReportBindingSource;
        private MODULO_FACT_VECADataSet mODULO_FACT_VECADataSet;
        private MODULO_FACT_VECADataSetTableAdapters.Tbl_Tipo_DocReportTableAdapter tbl_Tipo_DocReportTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CboxPVfact;
        private System.Windows.Forms.BindingSource tblPuntoVentaBusquedaBindingSource;
        private MODULO_FACT_VECADataSetTableAdapters.Tbl_Punto_VentaBusquedaTableAdapter tbl_Punto_VentaBusquedaTableAdapter;
        private System.Windows.Forms.CheckBox CboxAllPv;

    }
}