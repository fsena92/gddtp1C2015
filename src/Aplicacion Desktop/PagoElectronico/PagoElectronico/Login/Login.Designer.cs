namespace PagoElectronico.Login
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
            this.but_aceptar = new System.Windows.Forms.Button();
            this.but_cancelar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lab_pass = new System.Windows.Forms.Label();
            this.lab_User = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.group_log = new System.Windows.Forms.GroupBox();
            this.group_log.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_aceptar
            // 
            this.but_aceptar.Location = new System.Drawing.Point(35, 100);
            this.but_aceptar.Name = "but_aceptar";
            this.but_aceptar.Size = new System.Drawing.Size(75, 23);
            this.but_aceptar.TabIndex = 0;
            this.but_aceptar.Text = "Aceptar";
            this.but_aceptar.UseVisualStyleBackColor = true;
            this.but_aceptar.Click += new System.EventHandler(this.but_aceptar_Click);
            // 
            // but_cancelar
            // 
            this.but_cancelar.Location = new System.Drawing.Point(192, 100);
            this.but_cancelar.Name = "but_cancelar";
            this.but_cancelar.Size = new System.Drawing.Size(75, 23);
            this.but_cancelar.TabIndex = 1;
            this.but_cancelar.Text = "Salir";
            this.but_cancelar.UseVisualStyleBackColor = true;
            this.but_cancelar.Click += new System.EventHandler(this.but_cancelar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(114, 19);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // lab_pass
            // 
            this.lab_pass.AutoSize = true;
            this.lab_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab_pass.Location = new System.Drawing.Point(20, 46);
            this.lab_pass.Name = "lab_pass";
            this.lab_pass.Size = new System.Drawing.Size(80, 16);
            this.lab_pass.TabIndex = 4;
            this.lab_pass.Text = "Contraseña:";
            // 
            // lab_User
            // 
            this.lab_User.AutoSize = true;
            this.lab_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab_User.Location = new System.Drawing.Point(20, 20);
            this.lab_User.Name = "lab_User";
            this.lab_User.Size = new System.Drawing.Size(61, 16);
            this.lab_User.TabIndex = 5;
            this.lab_User.Text = "Usuario: ";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(114, 45);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(100, 20);
            this.txtContraseña.TabIndex = 6;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // group_log
            // 
            this.group_log.Controls.Add(this.txtContraseña);
            this.group_log.Controls.Add(this.lab_User);
            this.group_log.Controls.Add(this.lab_pass);
            this.group_log.Controls.Add(this.txtUsuario);
            this.group_log.Location = new System.Drawing.Point(12, 12);
            this.group_log.Name = "group_log";
            this.group_log.Size = new System.Drawing.Size(278, 82);
            this.group_log.TabIndex = 7;
            this.group_log.TabStop = false;
            this.group_log.Text = "Login";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 134);
            this.Controls.Add(this.but_cancelar);
            this.Controls.Add(this.but_aceptar);
            this.Controls.Add(this.group_log);
            this.Name = "Login";
            this.Text = "Login";
            this.group_log.ResumeLayout(false);
            this.group_log.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_aceptar;
        private System.Windows.Forms.Button but_cancelar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lab_pass;
        private System.Windows.Forms.Label lab_User;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.GroupBox group_log;
    }
}