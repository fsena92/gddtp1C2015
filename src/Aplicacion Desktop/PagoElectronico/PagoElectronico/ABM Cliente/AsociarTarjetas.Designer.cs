namespace PagoElectronico.ABM_Cliente
{
    partial class AsociarTarjetas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbEmisor = new System.Windows.Forms.ComboBox();
            this.txtNroTar = new System.Windows.Forms.TextBox();
            this.txtSeg = new System.Windows.Forms.TextBox();
            this.dtpFecEm = new System.Windows.Forms.DateTimePicker();
            this.dtpFecVe = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Tarjeta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Emisor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de emision";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de vencimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Codigo de seguridad";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(32, 149);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(188, 149);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbEmisor
            // 
            this.cbEmisor.FormattingEnabled = true;
            this.cbEmisor.Location = new System.Drawing.Point(142, 32);
            this.cbEmisor.Name = "cbEmisor";
            this.cbEmisor.Size = new System.Drawing.Size(121, 21);
            this.cbEmisor.TabIndex = 7;
            // 
            // txtNroTar
            // 
            this.txtNroTar.Location = new System.Drawing.Point(142, 6);
            this.txtNroTar.Name = "txtNroTar";
            this.txtNroTar.Size = new System.Drawing.Size(121, 20);
            this.txtNroTar.TabIndex = 8;
            // 
            // txtSeg
            // 
            this.txtSeg.Location = new System.Drawing.Point(142, 112);
            this.txtSeg.Name = "txtSeg";
            this.txtSeg.Size = new System.Drawing.Size(121, 20);
            this.txtSeg.TabIndex = 9;
            this.txtSeg.UseSystemPasswordChar = true;
            this.txtSeg.TextChanged += new System.EventHandler(this.txtSeg_TextChanged);
            // 
            // dtpFecEm
            // 
            this.dtpFecEm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecEm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecEm.Location = new System.Drawing.Point(142, 58);
            this.dtpFecEm.Name = "dtpFecEm";
            this.dtpFecEm.Size = new System.Drawing.Size(121, 23);
            this.dtpFecEm.TabIndex = 127;
            this.dtpFecEm.Value = new System.DateTime(1995, 1, 1, 7, 19, 0, 0);
            // 
            // dtpFecVe
            // 
            this.dtpFecVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecVe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecVe.Location = new System.Drawing.Point(142, 85);
            this.dtpFecVe.Name = "dtpFecVe";
            this.dtpFecVe.Size = new System.Drawing.Size(121, 23);
            this.dtpFecVe.TabIndex = 128;
            this.dtpFecVe.Value = new System.DateTime(1995, 1, 1, 7, 19, 0, 0);
            // 
            // AsociarTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 179);
            this.Controls.Add(this.dtpFecVe);
            this.Controls.Add(this.dtpFecEm);
            this.Controls.Add(this.txtSeg);
            this.Controls.Add(this.txtNroTar);
            this.Controls.Add(this.cbEmisor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AsociarTarjetas";
            this.Text = "AsociarTarjetas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbEmisor;
        private System.Windows.Forms.TextBox txtNroTar;
        private System.Windows.Forms.TextBox txtSeg;
        private System.Windows.Forms.DateTimePicker dtpFecEm;
        private System.Windows.Forms.DateTimePicker dtpFecVe;
    }
}