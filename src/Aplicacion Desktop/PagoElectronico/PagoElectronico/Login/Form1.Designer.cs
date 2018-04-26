namespace PagoElectronico.Login
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lab_pass = new System.Windows.Forms.Label();
            this.lab_User = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.group_log = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // but_aceptar
            // 
            this.but_aceptar.Location = new System.Drawing.Point(26, 213);
            this.but_aceptar.Name = "but_aceptar";
            this.but_aceptar.Size = new System.Drawing.Size(75, 23);
            this.but_aceptar.TabIndex = 0;
            this.but_aceptar.Text = "Aceptar";
            this.but_aceptar.UseVisualStyleBackColor = true;
            this.but_aceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // but_cancelar
            // 
            this.but_cancelar.Location = new System.Drawing.Point(183, 213);
            this.but_cancelar.Name = "but_cancelar";
            this.but_cancelar.Size = new System.Drawing.Size(75, 23);
            this.but_cancelar.TabIndex = 1;
            this.but_cancelar.Text = "Cancelar";
            this.but_cancelar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(148, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // lab_pass
            // 
            this.lab_pass.AutoSize = true;
            this.lab_pass.Location = new System.Drawing.Point(37, 135);
            this.lab_pass.Name = "lab_pass";
            this.lab_pass.Size = new System.Drawing.Size(64, 13);
            this.lab_pass.TabIndex = 4;
            this.lab_pass.Text = "Contraseña:";
            // 
            // lab_User
            // 
            this.lab_User.AutoSize = true;
            this.lab_User.Location = new System.Drawing.Point(38, 89);
            this.lab_User.Name = "lab_User";
            this.lab_User.Size = new System.Drawing.Size(49, 13);
            this.lab_User.TabIndex = 5;
            this.lab_User.Text = "Usuario: ";
            this.lab_User.Click += new System.EventHandler(this.lab_User_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(148, 127);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            // 
            // group_log
            // 
            this.group_log.Location = new System.Drawing.Point(3, 30);
            this.group_log.Name = "group_log";
            this.group_log.Size = new System.Drawing.Size(278, 163);
            this.group_log.TabIndex = 7;
            this.group_log.TabStop = false;
            this.group_log.Text = "Login";
            this.group_log.Enter += new System.EventHandler(this.group_log_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 266);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lab_User);
            this.Controls.Add(this.lab_pass);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.but_cancelar);
            this.Controls.Add(this.but_aceptar);
            this.Controls.Add(this.group_log);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_aceptar;
        private System.Windows.Forms.Button but_cancelar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lab_pass;
        private System.Windows.Forms.Label lab_User;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox group_log;
    }
}