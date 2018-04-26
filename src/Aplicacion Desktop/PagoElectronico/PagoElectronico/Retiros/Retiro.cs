using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comparadores;

namespace PagoElectronico.Retiros
{
    public partial class Retiro : Form
    {
        public int codigoCliente;
        public String usuario2;
        public String NumeroCuenta;
        private Login.Tablero padre;

        public Retiro(Login.Tablero ruta,String usuario,String cuenta)
        {
            InitializeComponent();
            usuario2 = usuario;
            padre = ruta;
            NumeroCuenta = cuenta;
            Conexion con = new Conexion();
            con.query = "SELECT Cod_Cli, Nro_Doc FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario = '"+ usuario2 +"'";
            con.ejecutarQuery();
            con.leerReader();
            codigoCliente = con.lector.GetInt32(0);
            txt_documento.Text = con.lector.GetDecimal(1).ToString();
            con.cerrarConexion();
            txt_cuenta.Text = NumeroCuenta;
            con.query = "SELECT Id_Banco FROM ESCUADRON_SUICIDA.Banco";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbBanco.Items.Add(con.lector.GetDecimal(0));
            }
            con.cerrarConexion();

            con.query = "SELECT Tipo_Moneda FROM ESCUADRON_SUICIDA.Cuenta WHERE Nro_Cuenta=" + NumeroCuenta;
            con.ejecutarQuery();
            con.leerReader();
            txtMoneda.Text = con.lector.GetString(0);
            con.cerrarConexion();
            txtMoneda.Enabled = false;
            txt_documento.Enabled = false;
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {            
            txt_importe.Clear();
            cbBanco.Text = "";
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void txt_documento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_importe_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_cuenta_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {        
            /*validacion de campos*/
            if (txt_cuenta.Text == "")
            {
                MessageBox.Show("Seleccione una cuenta para realizar el retiro");
                return;
            }
            if (txt_documento.Text == "")
            {
                MessageBox.Show("Ingrese numero de documento");
                return;
            }
            if (!txt_importe.Text.IsNumeric() || String.Compare(txt_importe.Text,"0")<=0 || txt_importe.Text=="" )
            {
                MessageBox.Show("Ingrese un importe de valor numerico mayor a cero");
                return;
            }
            /*actualizacion de cuenta e insert en cheque*/
            Conexion c1 = new Conexion();
            c1.query = "SELECT Saldo FROM ESCUADRON_SUICIDA.Cuenta WHERE Cod_Cli = (SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='" + usuario2 + "') AND Saldo >= " + txt_importe.Text + " AND Nro_Cuenta=" + NumeroCuenta;
            c1.ejecutarQuery();
            if (c1.leerReader())/*no estoy seguro =S*/
            {
                Conexion c3 = new Conexion();
                c3.query = "INSERT INTO ESCUADRON_SUICIDA.Retiro (Fecha_Retiro, Importe, Nro_Cuenta, Tipo_Moneda) VALUES('" + lectorConfig.Config.fechaSystem() + " 00:00:00.000', " + txt_importe.Text + "," + txt_cuenta.Text + ",'"+txtMoneda.Text+"')";
                c3.ejecutarNoQuery();

                c3.query = "SELECT TOP 1 Cod_Retiro FROM ESCUADRON_SUICIDA.Retiro WHERE Nro_Cuenta=" + txt_cuenta.Text + " ORDER BY Cod_Retiro DESC";
                c3.ejecutarQuery();
                c3.leerReader();
                
                Conexion c2 = new Conexion();
                c2.query = "INSERT INTO ESCUADRON_SUICIDA.Cheque (Nro_Cuenta, Fecha_Cheque, Importe, Id_Banco, Nro_Egreso,Tipo_Moneda,Cli_Nombre)"+
                            " VALUES(" + txt_cuenta.Text + ", '" + lectorConfig.Config.fechaSystem() + " 00:00:00.000', " + txt_importe.Text + "," + cbBanco.Text +
                            "," + c3.lector.GetDecimal(0) + ",'" + txtMoneda.Text + "',(SELECT Apellido+' '+Nombre FROM ESCUADRON_SUICIDA.Cliente WHERE Cod_Cli= (SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='" + usuario2 + "')))";
                c3.cerrarConexion();
                c2.ejecutarNoQuery();

                Conexion con = new Conexion();
                con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Saldo = Saldo -" + txt_importe.Text + " WHERE Nro_Cuenta = " + txt_cuenta.Text;
                con.ejecutarNoQuery();
            }
            else
            {
                MessageBox.Show("El saldo de la cuenta es menor al solicitado");
                return;
            }
            c1.cerrarConexion();
            MessageBox.Show("Retiro realizado con exito");
            padre.Show();
            this.Close();
        }
    }
}
