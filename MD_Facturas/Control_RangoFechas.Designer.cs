namespace MD_Facturas
{
    partial class Control_RangoFechas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DatePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.DatePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta:";
            // 
            // DatePickerDesde
            // 
            this.DatePickerDesde.Location = new System.Drawing.Point(76, 31);
            this.DatePickerDesde.Name = "DatePickerDesde";
            this.DatePickerDesde.Size = new System.Drawing.Size(200, 20);
            this.DatePickerDesde.TabIndex = 2;
            this.DatePickerDesde.ValueChanged += new System.EventHandler(this.DatePickerDesde_ValueChanged);
            // 
            // DatePickerHasta
            // 
            this.DatePickerHasta.Location = new System.Drawing.Point(76, 70);
            this.DatePickerHasta.Name = "DatePickerHasta";
            this.DatePickerHasta.Size = new System.Drawing.Size(200, 20);
            this.DatePickerHasta.TabIndex = 3;
            this.DatePickerHasta.ValueChanged += new System.EventHandler(this.DatePickerHasta_ValueChanged);
            // 
            // Control_RangoFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DatePickerHasta);
            this.Controls.Add(this.DatePickerDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Control_RangoFechas";
            this.Size = new System.Drawing.Size(401, 132);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DatePickerDesde;
        private System.Windows.Forms.DateTimePicker DatePickerHasta;
    }
}
