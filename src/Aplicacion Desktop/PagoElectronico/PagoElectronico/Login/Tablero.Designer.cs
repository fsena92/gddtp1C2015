namespace PagoElectronico.Login
{
    partial class Tablero
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
            this.gbUsuario = new System.Windows.Forms.GroupBox();
            this.btnRetiro = new System.Windows.Forms.Button();
            this.btnDeposito = new System.Windows.Forms.Button();
            this.btnTransf = new System.Windows.Forms.Button();
            this.btnModifTar = new System.Windows.Forms.Button();
            this.btnDesAsociar = new System.Windows.Forms.Button();
            this.btnAsociar = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_BajaCli = new System.Windows.Forms.Button();
            this.btn_ModiCli = new System.Windows.Forms.Button();
            this.btn_AltaCli = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_BajaRol = new System.Windows.Forms.Button();
            this.btn_ModiRol = new System.Windows.Forms.Button();
            this.btn_AltaRol = new System.Windows.Forms.Button();
            this.btn_BajaCue = new System.Windows.Forms.Button();
            this.btn_ModiCue = new System.Windows.Forms.Button();
            this.btn_AltaCuen = new System.Windows.Forms.Button();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnListado = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConSal = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Label = new System.Windows.Forms.Label();
            this.btnDesloguearse2 = new System.Windows.Forms.Button();
            this.gbUsuario.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbAdmin.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUsuario
            // 
            this.gbUsuario.Controls.Add(this.btnRetiro);
            this.gbUsuario.Controls.Add(this.btnDeposito);
            this.gbUsuario.Controls.Add(this.btnTransf);
            this.gbUsuario.Controls.Add(this.btnModifTar);
            this.gbUsuario.Controls.Add(this.btnDesAsociar);
            this.gbUsuario.Controls.Add(this.btnAsociar);
            this.gbUsuario.Location = new System.Drawing.Point(12, 12);
            this.gbUsuario.Name = "gbUsuario";
            this.gbUsuario.Size = new System.Drawing.Size(511, 100);
            this.gbUsuario.TabIndex = 0;
            this.gbUsuario.TabStop = false;
            this.gbUsuario.Text = "Opciones";
            // 
            // btnRetiro
            // 
            this.btnRetiro.Location = new System.Drawing.Point(178, 57);
            this.btnRetiro.Name = "btnRetiro";
            this.btnRetiro.Size = new System.Drawing.Size(156, 30);
            this.btnRetiro.TabIndex = 6;
            this.btnRetiro.Text = "Realizar Retiro";
            this.btnRetiro.UseVisualStyleBackColor = true;
            this.btnRetiro.Click += new System.EventHandler(this.btnRetiro_Click);
            // 
            // btnDeposito
            // 
            this.btnDeposito.Location = new System.Drawing.Point(340, 57);
            this.btnDeposito.Name = "btnDeposito";
            this.btnDeposito.Size = new System.Drawing.Size(160, 30);
            this.btnDeposito.TabIndex = 5;
            this.btnDeposito.Text = "Realizar Deposito";
            this.btnDeposito.UseVisualStyleBackColor = true;
            this.btnDeposito.Click += new System.EventHandler(this.btnDeposito_Click);
            // 
            // btnTransf
            // 
            this.btnTransf.Location = new System.Drawing.Point(12, 57);
            this.btnTransf.Name = "btnTransf";
            this.btnTransf.Size = new System.Drawing.Size(160, 30);
            this.btnTransf.TabIndex = 3;
            this.btnTransf.Text = "Realizar Transferencia";
            this.btnTransf.UseVisualStyleBackColor = true;
            this.btnTransf.Click += new System.EventHandler(this.btnTransf_Click);
            // 
            // btnModifTar
            // 
            this.btnModifTar.Location = new System.Drawing.Point(178, 19);
            this.btnModifTar.Name = "btnModifTar";
            this.btnModifTar.Size = new System.Drawing.Size(156, 30);
            this.btnModifTar.TabIndex = 2;
            this.btnModifTar.Text = "Modificar Tarjetas";
            this.btnModifTar.UseVisualStyleBackColor = true;
            this.btnModifTar.Click += new System.EventHandler(this.btnModifTar_Click);
            // 
            // btnDesAsociar
            // 
            this.btnDesAsociar.Location = new System.Drawing.Point(340, 19);
            this.btnDesAsociar.Name = "btnDesAsociar";
            this.btnDesAsociar.Size = new System.Drawing.Size(160, 30);
            this.btnDesAsociar.TabIndex = 1;
            this.btnDesAsociar.Text = "Desasociar Tarjetas";
            this.btnDesAsociar.UseVisualStyleBackColor = true;
            this.btnDesAsociar.Click += new System.EventHandler(this.btnDesAsociar_Click);
            // 
            // btnAsociar
            // 
            this.btnAsociar.Location = new System.Drawing.Point(12, 20);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(160, 30);
            this.btnAsociar.TabIndex = 0;
            this.btnAsociar.Text = "Asociar Tarjetas";
            this.btnAsociar.UseVisualStyleBackColor = true;
            this.btnAsociar.Click += new System.EventHandler(this.btnAsociar_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_BajaCli);
            this.groupBox6.Controls.Add(this.btn_ModiCli);
            this.groupBox6.Controls.Add(this.btn_AltaCli);
            this.groupBox6.Location = new System.Drawing.Point(6, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(500, 65);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Opciones Cliente";
            // 
            // btn_BajaCli
            // 
            this.btn_BajaCli.Location = new System.Drawing.Point(334, 19);
            this.btn_BajaCli.Name = "btn_BajaCli";
            this.btn_BajaCli.Size = new System.Drawing.Size(160, 30);
            this.btn_BajaCli.TabIndex = 5;
            this.btn_BajaCli.Text = "Baja Cliente";
            this.btn_BajaCli.UseVisualStyleBackColor = true;
            this.btn_BajaCli.Click += new System.EventHandler(this.btn_BajaCli_Click);
            // 
            // btn_ModiCli
            // 
            this.btn_ModiCli.Location = new System.Drawing.Point(172, 19);
            this.btn_ModiCli.Name = "btn_ModiCli";
            this.btn_ModiCli.Size = new System.Drawing.Size(156, 30);
            this.btn_ModiCli.TabIndex = 4;
            this.btn_ModiCli.Text = "Modificar Cliente";
            this.btn_ModiCli.UseVisualStyleBackColor = true;
            this.btn_ModiCli.Click += new System.EventHandler(this.btn_ModiCli_Click);
            // 
            // btn_AltaCli
            // 
            this.btn_AltaCli.Location = new System.Drawing.Point(6, 19);
            this.btn_AltaCli.Name = "btn_AltaCli";
            this.btn_AltaCli.Size = new System.Drawing.Size(160, 30);
            this.btn_AltaCli.TabIndex = 3;
            this.btn_AltaCli.Text = "Alta Cliente";
            this.btn_AltaCli.UseVisualStyleBackColor = true;
            this.btn_AltaCli.Click += new System.EventHandler(this.btn_AltaCli_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_BajaRol);
            this.groupBox5.Controls.Add(this.btn_ModiRol);
            this.groupBox5.Controls.Add(this.btn_AltaRol);
            this.groupBox5.Location = new System.Drawing.Point(6, 90);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(500, 65);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Opciones Rol";
            // 
            // btn_BajaRol
            // 
            this.btn_BajaRol.Location = new System.Drawing.Point(334, 19);
            this.btn_BajaRol.Name = "btn_BajaRol";
            this.btn_BajaRol.Size = new System.Drawing.Size(160, 30);
            this.btn_BajaRol.TabIndex = 11;
            this.btn_BajaRol.Text = "Baja Rol";
            this.btn_BajaRol.UseVisualStyleBackColor = true;
            this.btn_BajaRol.Click += new System.EventHandler(this.btn_BajaRol_Click);
            // 
            // btn_ModiRol
            // 
            this.btn_ModiRol.Location = new System.Drawing.Point(172, 19);
            this.btn_ModiRol.Name = "btn_ModiRol";
            this.btn_ModiRol.Size = new System.Drawing.Size(156, 30);
            this.btn_ModiRol.TabIndex = 10;
            this.btn_ModiRol.Text = "Modificar Rol";
            this.btn_ModiRol.UseVisualStyleBackColor = true;
            this.btn_ModiRol.Click += new System.EventHandler(this.btn_ModiRol_Click);
            // 
            // btn_AltaRol
            // 
            this.btn_AltaRol.Location = new System.Drawing.Point(6, 19);
            this.btn_AltaRol.Name = "btn_AltaRol";
            this.btn_AltaRol.Size = new System.Drawing.Size(160, 30);
            this.btn_AltaRol.TabIndex = 9;
            this.btn_AltaRol.Text = "Alta Rol";
            this.btn_AltaRol.UseVisualStyleBackColor = true;
            this.btn_AltaRol.Click += new System.EventHandler(this.btn_AltaRol_Click);
            // 
            // btn_BajaCue
            // 
            this.btn_BajaCue.Location = new System.Drawing.Point(340, 56);
            this.btn_BajaCue.Name = "btn_BajaCue";
            this.btn_BajaCue.Size = new System.Drawing.Size(160, 30);
            this.btn_BajaCue.TabIndex = 8;
            this.btn_BajaCue.Text = "Baja Cuenta";
            this.btn_BajaCue.UseVisualStyleBackColor = true;
            this.btn_BajaCue.Click += new System.EventHandler(this.btn_BajaCue_Click);
            // 
            // btn_ModiCue
            // 
            this.btn_ModiCue.Location = new System.Drawing.Point(178, 56);
            this.btn_ModiCue.Name = "btn_ModiCue";
            this.btn_ModiCue.Size = new System.Drawing.Size(156, 30);
            this.btn_ModiCue.TabIndex = 7;
            this.btn_ModiCue.Text = "Modificar Cuenta";
            this.btn_ModiCue.UseVisualStyleBackColor = true;
            this.btn_ModiCue.Click += new System.EventHandler(this.btn_ModiCue_Click);
            // 
            // btn_AltaCuen
            // 
            this.btn_AltaCuen.Location = new System.Drawing.Point(12, 57);
            this.btn_AltaCuen.Name = "btn_AltaCuen";
            this.btn_AltaCuen.Size = new System.Drawing.Size(160, 30);
            this.btn_AltaCuen.TabIndex = 6;
            this.btn_AltaCuen.Text = "Alta Cuenta";
            this.btn_AltaCuen.UseVisualStyleBackColor = true;
            this.btn_AltaCuen.Click += new System.EventHandler(this.btn_AltaCuen_Click);
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.groupBox4);
            this.gbAdmin.Controls.Add(this.groupBox5);
            this.gbAdmin.Controls.Add(this.groupBox6);
            this.gbAdmin.Location = new System.Drawing.Point(12, 118);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(1060, 161);
            this.gbAdmin.TabIndex = 1;
            this.gbAdmin.TabStop = false;
            this.gbAdmin.Text = "Opciones de Administracion";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnListado);
            this.groupBox4.Location = new System.Drawing.Point(554, 90);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(500, 65);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Opciones de Listado";
            // 
            // btnListado
            // 
            this.btnListado.Location = new System.Drawing.Point(7, 20);
            this.btnListado.Name = "btnListado";
            this.btnListado.Size = new System.Drawing.Size(160, 30);
            this.btnListado.TabIndex = 0;
            this.btnListado.Text = "Realizar Listado Estadistico";
            this.btnListado.UseVisualStyleBackColor = true;
            this.btnListado.Click += new System.EventHandler(this.btnListado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_BajaCue);
            this.groupBox1.Controls.Add(this.btnConSal);
            this.groupBox1.Controls.Add(this.btn_ModiCue);
            this.groupBox1.Controls.Add(this.btnFacturar);
            this.groupBox1.Controls.Add(this.btn_AltaCuen);
            this.groupBox1.Location = new System.Drawing.Point(561, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // btnConSal
            // 
            this.btnConSal.Location = new System.Drawing.Point(177, 20);
            this.btnConSal.Name = "btnConSal";
            this.btnConSal.Size = new System.Drawing.Size(156, 30);
            this.btnConSal.TabIndex = 1;
            this.btnConSal.Text = "Consultar Saldo";
            this.btnConSal.UseVisualStyleBackColor = true;
            this.btnConSal.Click += new System.EventHandler(this.btnConSal_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(11, 20);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(160, 30);
            this.btnFacturar.TabIndex = 0;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(12, 286);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(1059, 31);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Desloguearse";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(530, 98);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(0, 13);
            this.Label.TabIndex = 6;
            // 
            // btnDesloguearse2
            // 
            this.btnDesloguearse2.BackColor = System.Drawing.SystemColors.Control;
            this.btnDesloguearse2.Location = new System.Drawing.Point(1039, 310);
            this.btnDesloguearse2.Name = "btnDesloguearse2";
            this.btnDesloguearse2.Size = new System.Drawing.Size(150, 30);
            this.btnDesloguearse2.TabIndex = 97;
            this.btnDesloguearse2.Text = "Desloguearse";
            this.btnDesloguearse2.UseVisualStyleBackColor = false;
            this.btnDesloguearse2.Click += new System.EventHandler(this.btnDesloguearse2_Click);
            // 
            // Tablero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 329);
            this.Controls.Add(this.btnDesloguearse2);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbAdmin);
            this.Controls.Add(this.gbUsuario);
            this.Name = "Tablero";
            this.Text = "Tablero";
            this.gbUsuario.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.gbAdmin.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUsuario;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_BajaCli;
        private System.Windows.Forms.Button btn_ModiCli;
        private System.Windows.Forms.Button btn_AltaCli;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_BajaRol;
        private System.Windows.Forms.Button btn_ModiRol;
        private System.Windows.Forms.Button btn_AltaRol;
        private System.Windows.Forms.Button btn_BajaCue;
        private System.Windows.Forms.Button btn_ModiCue;
        private System.Windows.Forms.Button btn_AltaCuen;
        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.Button btnAsociar;
        private System.Windows.Forms.Button btnDesAsociar;
        private System.Windows.Forms.Button btnModifTar;
        private System.Windows.Forms.Button btnTransf;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnConSal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnListado;
        private System.Windows.Forms.Button btnRetiro;
        private System.Windows.Forms.Button btnDeposito;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button btnDesloguearse2;
    }
}