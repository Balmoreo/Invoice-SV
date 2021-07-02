namespace MD_Facturas
{
    partial class Visor_Informe
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
            this.GeneralViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // GeneralViewer1
            // 
            this.GeneralViewer1.ActiveViewIndex = -1;
            this.GeneralViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GeneralViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.GeneralViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralViewer1.Location = new System.Drawing.Point(0, 0);
            this.GeneralViewer1.Name = "GeneralViewer1";
            this.GeneralViewer1.Size = new System.Drawing.Size(925, 582);
            this.GeneralViewer1.TabIndex = 0;
            // 
            // Visor_Informe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 582);
            this.Controls.Add(this.GeneralViewer1);
            this.Name = "Visor_Informe";
            this.Text = "Reportes";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer GeneralViewer1;

    }
}