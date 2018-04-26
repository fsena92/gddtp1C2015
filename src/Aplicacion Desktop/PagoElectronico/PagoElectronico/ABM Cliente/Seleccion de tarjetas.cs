using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Cliente
{
    public partial class SeleccionDeTarjetas : Form
    {
        private Login.Tablero padre;
        private char tipodeMod;
        private String usuarioActual;
        public SeleccionDeTarjetas(Login.Tablero ruta,char tipo, String usuario)
        {
            InitializeComponent();
            padre = ruta;
            tipodeMod = tipo;
            usuarioActual = usuario;
            Conexion con = new Conexion();
            if (tipo == 'B')
            {
                con.query = "SELECT SUBSTRING(Nro_Tarjeta,13,4) FROM ESCUADRON_SUICIDA.Tarjeta T Join ESCUADRON_SUICIDA.Cliente C ON (T.Cod_Cli=C.Cod_Cli) WHERE Usuario='" + usuario + "' AND T.Estado!=0 ";
            }
            else 
            {
                con.query = "SELECT SUBSTRING(Nro_Tarjeta,13,4) FROM ESCUADRON_SUICIDA.Tarjeta T Join ESCUADRON_SUICIDA.Cliente C ON (T.Cod_Cli=C.Cod_Cli) WHERE Usuario='" + usuario + "'";
            
            } 
            
            con.ejecutarQuery();
            while (con.leerReader()) 
            {   
                String tarjeta = con.lector.GetString(0);
                cbTarjeta.Items.Add("************" + tarjeta);
                //cbTarjeta.Items.Add(con.lector.GetDecimal(0).ToString());
            }


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            if (cbTarjeta.Text == "")
            {
                MessageBox.Show("Seleccione una tarjeta"); return;
            }

            String nro_tar = cbTarjeta.Text.Remove(0,12);

            if (tipodeMod == 'B')
            {
                con.query = "UPDATE ESCUADRON_SUICIDA.Tarjeta SET Estado = 0 WHERE SUBSTRING(Nro_Tarjeta,13,4) = '"+ nro_tar +"' AND Cod_Cli= (SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='" + usuarioActual + "')";
                con.ejecutarNoQuery();
                MessageBox.Show("La tarjeta ha sido dada de baja");
                padre.Show();
                this.Close();
            }
            else
            {
                AsociarTarjetas form_ModifTar = new AsociarTarjetas(padre,'M', usuarioActual ,nro_tar);
                form_ModifTar.Show();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void cbTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
