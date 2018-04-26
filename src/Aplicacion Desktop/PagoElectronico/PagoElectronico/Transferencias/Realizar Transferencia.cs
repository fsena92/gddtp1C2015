using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comparadores;

namespace PagoElectronico.Transferencias
{
    public partial class Realizar_Transferencia : Form
    {
        private Login.Tablero padre;
        private String usuarioOrigen;
        private String usuarioDestino;
        private Conexion con=new Conexion();

        public Realizar_Transferencia(Login.Tablero ruta, String usuario, String rol)
        {
            InitializeComponent();
            textBox1.Visible = false;
            padre = ruta;
            if (rol == "Cliente")
            {
                usuarioOrigen = usuario;
                cbUsuario.Text = usuario;
                cbUsuario.Enabled = false;
                con.query = "SELECT Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta C JOIN ESCUADRON_SUICIDA.Cliente K ON (C.Cod_Cli=K.Cod_Cli) WHERE Usuario='" + usuario + "' AND C.Estado='Habilitada'";
                con.ejecutarQuery();
                while (con.leerReader())
                {
                    cbOrigen.Items.Add(con.lector.GetSqlDecimal(0).ToString());
                }
                con.cerrarConexion();
            }
            else
            {
                con.query = "Select Usuario From ESCUADRON_SUICIDA.RolPorUsuario RU JOIN ESCUADRON_SUICIDA.Roles R ON(RU.Id_Rol=R.Id_Rol) WHERE Nombre='Cliente'";
                con.ejecutarQuery();
                while (con.leerReader())
                {
                    cbUsuario.Items.Add(con.lector.GetString(0));
                }
                con.cerrarConexion();
            }

            txtMoneda.Enabled = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String tipoMoneda="";

            if (cbOrigen.Text == "") 
            {
                MessageBox.Show("Elija una cuenta de origen");
                return;
            }

            if (cbDestino.Text == "")
            {
                MessageBox.Show("Elija una cuenta de Destino");
                return;
            }

            if (cbOrigen.Text == cbDestino.Text)
            {
                MessageBox.Show("No se puede crear transacciones a la misma cuenta, seleccione un destino distinto");
                return;
            }

            if (!txtImporte.Text.IsNumeric() || txtImporte.Text == "" || String.Compare(txtImporte.Text,"0")<=0)
            {
                MessageBox.Show("El importe debe ser un numero mayor a cero");
                return;
            }
            
            con.query = "SELECT Saldo FROM ESCUADRON_SUICIDA.Cuenta WHERE Nro_Cuenta=" + cbOrigen.Text+ "AND Saldo >="+txtImporte.Text;
            con.ejecutarQuery();
            if (con.leerReader())
            {
                decimal saldo = con.lector.GetDecimal(0);
            }
            else
            {
                MessageBox.Show("No posee suficiente saldo en esta cuenta");
                con.cerrarConexion();
                return;
            }
            con.cerrarConexion();

            /*/if (String.Compare(txtImporte.Text,saldo.ToString())>0)
            {
                MessageBox.Show("No posee suficiente saldo en esta cuenta");
                return; 
            }/*/

            con.query = "SELECT K.Usuario From ESCUADRON_SUICIDA.Cuenta C JOIN ESCUADRON_SUICIDA.Cliente K ON(C.Cod_Cli=K.Cod_Cli) WHERE Nro_Cuenta=" + cbDestino.Text;
            con.ejecutarQuery();
            con.leerReader();
            usuarioDestino = con.lector.GetString(0);
            con.cerrarConexion();

            decimal costo;

            if (usuarioOrigen == usuarioDestino)
            {
                costo = 0;
                tipoMoneda = "USD";
            }
            else
            {
               con.query="SELECT Costo, T.Tipo_Moneda FROM ESCUADRON_SUICIDA.Cuenta C JOIN ESCUADRON_SUICIDA.TipoCuenta T ON (C.Tipo_Cuenta=T.Tipo_Cuenta) WHERE Nro_Cuenta=" + cbOrigen.Text;
               con.ejecutarQuery();
               con.leerReader();
               costo = con.lector.GetDecimal(0);
               tipoMoneda = con.lector.GetString(1);
               con.cerrarConexion();

            }

            con.query = "INSERT INTO ESCUADRON_SUICIDA.Transferencia (Fecha_Transf,Importe,Cuenta_Origen,Cuenta_Destino,Costo,Tipo_Moneda) VALUES ('" + lectorConfig.Config.fechaSystem() + " 00:00:00.000', " + txtImporte.Text + "," + cbOrigen.Text + "," + cbDestino.Text + "," + costo.ToString().Replace(',', '.') + ",'"+ tipoMoneda +"')";
            con.ejecutarNoQuery();

            con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Saldo= (Saldo-" + txtImporte.Text + ") WHERE Nro_Cuenta=" + cbOrigen.Text;
            con.ejecutarNoQuery();

            con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Saldo= (Saldo+" + txtImporte.Text + ")WHERE Nro_Cuenta=" + cbDestino.Text;
            con.ejecutarNoQuery();

            con.query = "SELECT COUNT(*) FROM ESCUADRON_SUICIDA.Transferencia WHERE Facturado=0 AND Cuenta_Origen= "+cbOrigen.Text;
            con.ejecutarQuery();
            con.leerReader();
            if (con.lector.GetInt32(0) < 5)
            {
                MessageBox.Show("Transferencia realizada correctamente");
                con.cerrarConexion();
                padre.Show();
                this.Close();
            }
            else
            {
                con.cerrarConexion();
                con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Estado='InHabilitada' WHERE Nro_Cuenta=" + cbOrigen.Text;
                con.ejecutarNoQuery();
                MessageBox.Show("Transferencia realizada correctamente. Su cuenta se ha inhabilitado por acumulacion de transferencias sin facturar");
                padre.Show();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void cbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarioOrigen = cbUsuario.Text;
            cbOrigen.Items.Clear();
            cbOrigen.Text = "";
            con.query = "SELECT Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta C JOIN ESCUADRON_SUICIDA.Cliente K ON (C.Cod_Cli=K.Cod_Cli) WHERE Usuario='" + usuarioOrigen + "' AND C.Estado='Habilitada'";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbOrigen.Items.Add(con.lector.GetSqlDecimal(0).ToString());
            }
            con.cerrarConexion();
        }

        private void cbOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.query="SELECT Tipo_Moneda FROM ESCUADRON_SUICIDA.Cuenta WHERE Nro_Cuenta="+cbOrigen.Text;
            con.ejecutarQuery();
            con.leerReader();
            txtMoneda.Text=con.lector.GetString(0);
            con.cerrarConexion();

            con.query="SELECT Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta WHERE estado IN ('Habilitada','Inhabilitada') AND Nro_Cuenta!="+cbOrigen.Text;
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbDestino.Items.Add(con.lector.GetSqlDecimal(0).ToString());
            }
            con.cerrarConexion();
        }
    }
}
