namespace MD_Facturas
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Lb_usuario = new System.Windows.Forms.Label();
            this.Txt_Usuario = new System.Windows.Forms.TextBox();
            this.Txt_Pass = new System.Windows.Forms.TextBox();
            this.Lb_Pass = new System.Windows.Forms.Label();
            this.Lb_login = new System.Windows.Forms.Label();
            this.Btt_Aceptar = new System.Windows.Forms.Button();
            this.Btt_cancelar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Lb_usuario
            // 
            this.Lb_usuario.AutoSize = true;
            this.Lb_usuario.Location = new System.Drawing.Point(34, 47);
            this.Lb_usuario.Name = "Lb_usuario";
            this.Lb_usuario.Size = new System.Drawing.Size(43, 13);
            this.Lb_usuario.TabIndex = 0;
            this.Lb_usuario.Text = "Usuario";
            // 
            // Txt_Usuario
            // 
            this.Txt_Usuario.Location = new System.Drawing.Point(95, 44);
            this.Txt_Usuario.Name = "Txt_Usuario";
            this.Txt_Usuario.Size = new System.Drawing.Size(217, 20);
            this.Txt_Usuario.TabIndex = 1;
            // 
            // Txt_Pass
            // 
            this.Txt_Pass.Location = new System.Drawing.Point(95, 91);
            this.Txt_Pass.Name = "Txt_Pass";
            this.Txt_Pass.PasswordChar = '*';
            this.Txt_Pass.Size = new System.Drawing.Size(217, 20);
            this.Txt_Pass.TabIndex = 3;
            this.Txt_Pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Pass_KeyDown);
            // 
            // Lb_Pass
            // 
            this.Lb_Pass.AutoSize = true;
            this.Lb_Pass.Location = new System.Drawing.Point(34, 94);
            this.Lb_Pass.Name = "Lb_Pass";
            this.Lb_Pass.Size = new System.Drawing.Size(53, 13);
            this.Lb_Pass.TabIndex = 2;
            this.Lb_Pass.Text = "Password";
            // 
            // Lb_login
            // 
            this.Lb_login.AutoSize = true;
            this.Lb_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_login.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Lb_login.Location = new System.Drawing.Point(137, 9);
            this.Lb_login.Name = "Lb_login";
            this.Lb_login.Size = new System.Drawing.Size(109, 17);
            this.Lb_login.TabIndex = 4;
            this.Lb_login.Text = "Login Usuario";
            // 
            // Btt_Aceptar
            // 
            this.Btt_Aceptar.Image = ((System.Drawing.Image)(resources.GetObject("Btt_Aceptar.Image")));
            this.Btt_Aceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_Aceptar.Location = new System.Drawing.Point(95, 143);
            this.Btt_Aceptar.Name = "Btt_Aceptar";
            this.Btt_Aceptar.Size = new System.Drawing.Size(80, 55);
            this.Btt_Aceptar.TabIndex = 5;
            this.Btt_Aceptar.Text = "Aceptar";
            this.Btt_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_Aceptar.UseVisualStyleBackColor = true;
            this.Btt_Aceptar.Click += new System.EventHandler(this.Btt_Aceptar_Click);
            // 
            // Btt_cancelar
            // 
            this.Btt_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Btt_cancelar.Image")));
            this.Btt_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_cancelar.Location = new System.Drawing.Point(232, 143);
            this.Btt_cancelar.Name = "Btt_cancelar";
            this.Btt_cancelar.Size = new System.Drawing.Size(80, 55);
            this.Btt_cancelar.TabIndex = 6;
            this.Btt_cancelar.Text = "Cancelar";
            this.Btt_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_cancelar.UseVisualStyleBackColor = true;
            this.Btt_cancelar.Click += new System.EventHandler(this.Btt_cancelar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(390, 210);
            this.ControlBox = false;
            this.Controls.Add(this.Btt_cancelar);
            this.Controls.Add(this.Btt_Aceptar);
            this.Controls.Add(this.Lb_login);
            this.Controls.Add(this.Txt_Pass);
            this.Controls.Add(this.Lb_Pass);
            this.Controls.Add(this.Txt_Usuario);
            this.Controls.Add(this.Lb_usuario);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lb_usuario;
        private System.Windows.Forms.TextBox Txt_Usuario;
        private System.Windows.Forms.TextBox Txt_Pass;
        private System.Windows.Forms.Label Lb_Pass;
        private System.Windows.Forms.Label Lb_login;
        private System.Windows.Forms.Button Btt_Aceptar;
        private System.Windows.Forms.Button Btt_cancelar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}