using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comparadores;

namespace PagoElectronico.ABM_Cliente
{
    public partial class AsociarTarjetas : Form
    {
        private Login.Tablero padre;
        private String usuarioActual;
        private char movimiento;
        private Conexion con = new Conexion();
        DateTime anteriorEmision;

        public AsociarTarjetas(Login.Tablero ruta,char tipo,String usuario,String tarjeta)
        {
            InitializeComponent();
            padre=ruta;
            usuarioActual = usuario;
            movimiento=tipo;
            if (tipo == 'M') 
            {
                txtNroTar.Text = "************"+tarjeta;
                txtNroTar.Enabled = false;
                txtSeg.Visible = false;
                label5.Visible = false;
                con.query = "SELECT T.Emisor, T.Fecha_Emision, T.Fecha_Vencimiento, T.Codigo_Seg FROM ESCUADRON_SUICIDA.Tarjeta T JOIN ESCUADRON_SUICIDA.Cliente C ON(T.Cod_Cli=C.Cod_Cli) WHERE SUBSTRING(T.Nro_Tarjeta,13,4)= '" + tarjeta + "' AND C.Usuario= '" + usuarioActual + "'";
                con.ejecutarQuery();
                con.leerReader();
                cbEmisor.Text = con.lector.GetString(0);
                dtpFecEm.Value = Convert.ToDateTime(con.lector.GetDateTime(1));
                anteriorEmision = Convert.ToDateTime(con.lector.GetDateTime(1));
                dtpFecVe.Value = Convert.ToDateTime(con.lector.GetDateTime(2));
                txtSeg.Text = con.lector.GetString(3);
                con.cerrarConexion();
            }
            con.query = "SELECT DISTINCT Emisor FROM ESCUADRON_SUICIDA.Tarjeta";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbEmisor.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {           
            if (!esCorrectaFechaDeVencimiento(2)) { MessageBox.Show("No se puede ingresar una fecha de vencimiento menor o igual a la fecha de emision"); return; }

            if (!esCorrectaFechaDeVencimiento(1)) { MessageBox.Show("No se puede ingresar una fecha de vencimiento menor a la actual"); return; }

            if (movimiento == 'A')
            {                
                if (!txtNroTar.Text.IsNumeric() || txtNroTar.Text.Length != 16 || string.Compare(txtNroTar.Text,"0000000000000000",false)==0)
                {
                    MessageBox.Show("El numero de tarjeta debe ser de 16 caracteres y contener solo numeros");
                    return;
                }

                if (!txtSeg.Text.IsNumeric() || txtSeg.Text.Length > 3)
                {
                    MessageBox.Show("El numero de seguridad debe ser menor a 3 caracteres y contener solo numeros");
                    return;
                }

                con.query = "SELECT Nro_Tarjeta FROM ESCUADRON_SUICIDA.Tarjeta WHERE Nro_Tarjeta='" + txtNroTar.Text + "'";
                con.ejecutarQuery();
                if (con.leerReader())
                {
                    MessageBox.Show("Esta tarjeta esta asociada a otro cliente");
                    con.cerrarConexion();
                    return;
                }
                con.cerrarConexion();

                try
                {
                    con.query = "INSERT INTO ESCUADRON_SUICIDA.Tarjeta (Nro_Tarjeta,Emisor,Fecha_Emision,Fecha_Vencimiento,Codigo_Seg,Cod_Cli)" +
                        "VALUES('" + txtNroTar.Text + "','" + cbEmisor.Text + "','" + dtpFecEm.Value.ToString("yyyy-dd-MM") + "','" +
                         dtpFecVe.Value.ToString("yyyy-dd-MM") + "', '" + txtSeg.Text + "',(SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='" + usuarioActual + "'))";
                    con.ejecutarNoQuery();
                    MessageBox.Show("La tajeta fue asociada correctamente");
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Su cuenta de usuario no tiene asociado ningun cliente");
                }
                finally
                {
                    padre.Show();
                    this.Hide();
                }
            }
            if(movimiento=='M')
            {
                String nro_tar = txtNroTar.Text.Remove(0, 12);

                if (!esCorrectaFechaDeEmision()) { MessageBox.Show("La nueva fecha de emision debe ser posterior a la antigua"); return; }

                con.query = "UPDATE ESCUADRON_SUICIDA.Tarjeta SET Emisor='" + cbEmisor.Text + "' WHERE SUBSTRING( Nro_Tarjeta , 13, 4) = '" + nro_tar + "' AND Codigo_Seg= '"+txtSeg.Text+"'";
                con.ejecutarNoQuery();
                con.query = "UPDATE ESCUADRON_SUICIDA.Tarjeta SET Fecha_Emision='" + dtpFecEm.Value.ToString("yyyy-dd-MM")+"' WHERE SUBSTRING( Nro_Tarjeta , 13, 4) = '" + nro_tar + "' AND Codigo_Seg= '" + txtSeg.Text + "'";
                con.ejecutarNoQuery();
                con.query = "UPDATE ESCUADRON_SUICIDA.Tarjeta SET Fecha_Vencimiento='" + dtpFecVe.Value.ToString("yyyy-dd-MM") + "' WHERE SUBSTRING( Nro_Tarjeta , 13, 4) = '" + nro_tar + "' AND Codigo_Seg= '" + txtSeg.Text + "'";
                con.ejecutarNoQuery();
                MessageBox.Show("La tajeta fue Modificada correctamente");
            }
            padre.Show();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private bool esCorrectaFechaDeVencimiento(int i)
        {
            if (i == 1)
            {
                if ((String.Compare(dtpFecVe.Text.Remove(0, 6), lectorConfig.Config.fechaSystem().Remove(4, 6)) < 0) ||
                    ((String.Compare(dtpFecVe.Text.Remove(0, 6), lectorConfig.Config.fechaSystem().Remove(4, 6)) == 0) &&
                        (String.Compare(dtpFecVe.Text.Substring(3, 2), lectorConfig.Config.fechaSystem().Substring(5, 2)) < 0)) ||
                    ((String.Compare(dtpFecVe.Text.Remove(0, 6), lectorConfig.Config.fechaSystem().Remove(4, 6)) == 0) &&
                        (String.Compare(dtpFecVe.Text.Substring(3, 2), lectorConfig.Config.fechaSystem().Substring(5, 2)) == 0) &&
                        (String.Compare(dtpFecVe.Text.Remove(2, 8), lectorConfig.Config.fechaSystem().Substring(8,2)) < 0)))
                
                /*if (DateTime.Compare(dtpFecVe.Value,DateTime.Today)<0)*/{
                    return false;
                }
                else { return true; }
            }
            else 
            {
                /*if ((String.Compare(dtpFecVe.Text.Remove(0, 6), dtpFecEm.Text.Remove(0, 6)) < 0) ||
                    ((String.Compare(dtpFecVe.Text.Remove(0, 6), dtpFecEm.Text.Remove(0, 6)) == 0) &&
                        (String.Compare(dtpFecVe.Text.Substring(3, 2), dtpFecEm.Text.Substring(3, 2)) < 0)) ||
                    ((String.Compare(dtpFecVe.Text.Remove(0, 6), dtpFecEm.Text.Remove(0, 6)) == 0) &&
                        (String.Compare(dtpFecVe.Text.Substring(3, 2), dtpFecEm.Text.Substring(3, 2)) == 0) &&
                        (String.Compare(dtpFecVe.Text.Remove(2, 8), dtpFecEm.Text.Remove(2, 8)) <= 0)))
                */if (DateTime.Compare(dtpFecVe.Value,dtpFecEm.Value)<=0){ return false; }
                else { return true; }
            }
        }

        private bool esCorrectaFechaDeEmision()
        {
            return (DateTime.Compare(dtpFecEm.Value, anteriorEmision) > 0);            
        }

        private void txtSeg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
