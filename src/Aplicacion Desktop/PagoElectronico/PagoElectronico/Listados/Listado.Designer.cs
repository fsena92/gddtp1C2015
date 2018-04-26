namespace PagoElectronico.Listados
{
    partial class Listado
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
            this.dvTabla = new System.Windows.Forms.DataGridView();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.cbTrimestre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClientePropias = new System.Windows.Forms.Button();
            this.btnPaises = new System.Windows.Forms.Button();
            this.btnInhabilitadas = new System.Windows.Forms.Button();
            this.btnFacturado = new System.Windows.Forms.Button();
            this.totalFacturado = new System.Windows.Forms.Button();
            this.cbTipoDeCuenta = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // dvTabla
            // 
            this.dvTabla.AllowUserToAddRows = false;
            this.dvTabla.AllowUserToDeleteRows = false;
            this.dvTabla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvTabla.Location = new System.Drawing.Point(15, 142);
            this.dvTabla.Name = "dvTabla";
            this.dvTabla.ReadOnly = true;
            this.dvTabla.Size = new System.Drawing.Size(573, 326);
            this.dvTabla.TabIndex = 13;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(15, 29);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(100, 20);
            this.txtAnio.TabIndex = 14;
            // 
            // cbTrimestre
            // 
            this.cbTrimestre.FormattingEnabled = true;
            this.cbTrimestre.Location = new System.Drawing.Point(121, 28);
            this.cbTrimestre.Name = "cbTrimestre";
            this.cbTrimestre.Size = new System.Drawing.Size(121, 21);
            this.cbTrimestre.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Trimestre";
            // 
            // btnClientePropias
            // 
            this.btnClientePropias.Location = new System.Drawing.Point(252, 26);
            this.btnClientePropias.Name = "btnClientePropias";
            this.btnClientePropias.Size = new System.Drawing.Size(336, 23);
            this.btnClientePropias.TabIndex = 18;
            this.btnClientePropias.Text = "Cliente con mayor cantidad de transacciones entre cuentas propias";
            this.btnClientePropias.UseVisualStyleBackColor = true;
            this.btnClientePropias.Click += new System.EventHandler(this.btnClientePropias_Click);
            // 
            // btnPaises
            // 
            this.btnPaises.Location = new System.Drawing.Point(252, 55);
            this.btnPaises.Name = "btnPaises";
            this.btnPaises.Size = new System.Drawing.Size(336, 23);
            this.btnPaises.TabIndex = 19;
            this.btnPaises.Text = "Paises con mayor cantidad de movimientos";
            this.btnPaises.UseVisualStyleBackColor = true;
            this.btnPaises.Click += new System.EventHandler(this.btnPaises_Click);
            // 
            // btnInhabilitadas
            // 
            this.btnInhabilitadas.Location = new System.Drawing.Point(252, 84);
            this.btnInhabilitadas.Name = "btnInhabilitadas";
            this.btnInhabilitadas.Size = new System.Drawing.Size(336, 23);
            this.btnInhabilitadas.TabIndex = 20;
            this.btnInhabilitadas.Text = "Clientes con cuentas inhabilitadas";
            this.btnInhabilitadas.UseVisualStyleBackColor = true;
            this.btnInhabilitadas.Click += new System.EventHandler(this.btnInhabilitadas_Click);
            // 
            // btnFacturado
            // 
            this.btnFacturado.Location = new System.Drawing.Point(252, 113);
            this.btnFacturado.Name = "btnFacturado";
            this.btnFacturado.Size = new System.Drawing.Size(336, 23);
            this.btnFacturado.TabIndex = 21;
            this.btnFacturado.Text = "Clientes mayor cantidad de comisiones facturadas";
            this.btnFacturado.UseVisualStyleBackColor = true;
            this.btnFacturado.Click += new System.EventHandler(this.btnFacturado_Click);
            // 
            // totalFacturado
            // 
            this.totalFacturado.Location = new System.Drawing.Point(15, 55);
            this.totalFacturado.Name = "totalFacturado";
            this.totalFacturado.Size = new System.Drawing.Size(227, 23);
            this.totalFacturado.TabIndex = 22;
            this.totalFacturado.Text = "Total facturado para:";
            this.totalFacturado.UseVisualStyleBackColor = true;
            this.totalFacturado.Click += new System.EventHandler(this.totalFacturado_Click);
            // 
            // cbTipoDeCuenta
            // 
            this.cbTipoDeCuenta.FormattingEnabled = true;
            this.cbTipoDeCuenta.Location = new System.Drawing.Point(15, 84);
            this.cbTipoDeCuenta.Name = "cbTipoDeCuenta";
            this.cbTipoDeCuenta.Size = new System.Drawing.Size(227, 21);
            this.cbTipoDeCuenta.TabIndex = 23;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(15, 474);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(573, 21);
            this.btnVolver.TabIndex = 24;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 507);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cbTipoDeCuenta);
            this.Controls.Add(this.totalFacturado);
            this.Controls.Add(this.btnFacturado);
            this.Controls.Add(this.btnInhabilitadas);
            this.Controls.Add(this.btnPaises);
            this.Controls.Add(this.btnClientePropias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTrimestre);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.dvTabla);
            this.Name = "Listado";
            this.Text = "Listado";
            ((System.ComponentModel.ISupportInitialize)(this.dvTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvTabla;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.ComboBox cbTrimestre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClientePropias;
        private System.Windows.Forms.Button btnPaises;
        private System.Windows.Forms.Button btnInhabilitadas;
        private System.Windows.Forms.Button btnFacturado;
        private System.Windows.Forms.Button totalFacturado;
        private System.Windows.Forms.ComboBox cbTipoDeCuenta;
        private System.Windows.Forms.Button btnVolver;
    }
}