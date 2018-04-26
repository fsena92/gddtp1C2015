using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comparadores;

namespace PagoElectronico.Depositos/*TODO generar comprobante*/
{
    public partial class Deposito : Form
    {
        public int Codigo_Cliente;
        private string usuario2;
        private int NumeroDeposito;
        private Login.Tablero padre;
        public String tarjeta;
        public Deposito(Login.Tablero ruta, String usuario, int deposito, String cuenta)
        {
            InitializeComponent();
            usuario2 = usuario;
            padre = ruta;
            NumeroDeposito = deposito;
            txt_Fecha.Text = lectorConfig.Config.fechaSystem().ToString();

            Conexion c2 = new Conexion();
            c2.query = "SELECT Tipo_Moneda FROM ESCUADRON_SUICIDA.TipoMoneda";
            c2.ejecutarQuery();
            while (c2.leerReader())
            {
                cmb_tipomoneda.Items.Add(c2.lector.GetString(0));
            }
            c2.cerrarConexion();
            Conexion c3 = new Conexion();//modificar el insert y select de substring
            c3.query = "SELECT Nro_Tarjeta FROM ESCUADRON_SUICIDA.Tarjeta T JOIN ESCUADRON_SUICIDA.Cliente C ON (T.Cod_Cli=C.Cod_Cli)" +
                "WHERE Usuario='" + usuario + "' AND T.Estado = 1 AND T.Fecha_Vencimiento > '" + lectorConfig.Config.fechaSystem() + " 00:00:00.000'";
            c3.ejecutarQuery();
            while (c3.leerReader())
            {
                tarjeta = c3.lector.GetString(0);
                cmb_tarjeta.Items.Add("************" + tarjeta[12].ToString()+tarjeta[13].ToString()+tarjeta[14].ToString()+tarjeta[15].ToString());
            }
            c3.cerrarConexion();
            txtcuenta.Text = cuenta;
        }

        private void txt_Importe_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_tipomoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_tarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            /*verificar campos completos*/
            if (txtcuenta.Text == "")
            {
                MessageBox.Show("Seleccione una Cuenta");
                return;
            }
            if (cmb_tarjeta.Text == "")
            {
                MessageBox.Show("Seleccione una Tarjeta");
                return;
            }
            if (cmb_tipomoneda.Text == "")
            {
                MessageBox.Show("Seleccione un Tipo de Moneda");
                return;
            }
            if (!txt_Importe.Text.IsNumeric() || txt_Importe.Text == "" || String.Compare(txt_Importe.Text,"0")<=0)
            {
                MessageBox.Show("Ingrese Importe mayor a cero");
                return;
            }

            /*insertar deposito y modificar saldo cuenta*/
            Conexion con = new Conexion();
            con.query = "INSERT INTO ESCUADRON_SUICIDA.Deposito (Nro_Cuenta,Importe,Fecha_Deposito,Tipo_Moneda,Nro_Tarjeta) VALUES (" +
                                    txtcuenta.Text + "," + txt_Importe.Text + ",'" + txt_Fecha.Text + "','" + cmb_tipomoneda.Text + "',"+ tarjeta +")";
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Saldo = Saldo + " + txt_Importe.Text + " WHERE Nro_Cuenta = " + txtcuenta.Text;
            con.ejecutarNoQuery();

            MessageBox.Show("Deposito realizado con exito");
            padre.Show();
            this.Close();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            cmb_tarjeta.ResetText();
            cmb_tipomoneda.ResetText();
            txt_Importe.Clear();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void txt_Fecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
