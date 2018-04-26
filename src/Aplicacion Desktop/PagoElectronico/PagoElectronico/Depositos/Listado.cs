using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Depositos
{
    public partial class Listado : Form
    {
        private Login.Tablero padre;
        private String NumeroCuenta;
        private Conexion con = new Conexion();
        String usuarioActual;
        int NumeroDeposito;

        public Listado(Login.Tablero ruta, String usuario,String rol)
        {
            InitializeComponent();
            padre = ruta;
            usuarioActual = usuario;
            if (rol == "Cliente")
            {
                usuarioActual = usuario;
                cbUsuario.Text = usuario;
                cbUsuario.Enabled = false;
                con.query = "SELECT Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta Cu JOIN ESCUADRON_SUICIDA.Cliente Cl ON (Cu.Cod_Cli=Cl.Cod_Cli) JOIN ESCUADRON_SUICIDA.Usuario U ON (Cl.Usuario=U.Usuario)" +
                            "WHERE U.Usuario='" + usuario + "' AND Cu.Estado = 'Habilitada'";
                con.ejecutarQuery();
                while (con.leerReader())
                {
                    cbCuenta.Items.Add(con.lector.GetDecimal(0));
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

        }

        private void btn_Aceptar_Click_1(object sender, EventArgs e)
        {
            if (cbUsuario.Text == "") { MessageBox.Show("Seleccione un usuario para poder seleccionar una cuenta"); return; }
            if (cbCuenta.Text == "") { MessageBox.Show("Seleccione una cuenta"); return; }

            con.query = "SELECT COUNT(Cod_Deposito) FROM ESCUADRON_SUICIDA.Deposito";
            con.ejecutarQuery();
            if (con.leerReader())
            {
                NumeroDeposito = con.lector.GetInt32(0) + 1;
            }
            else { NumeroDeposito = 1; }

            Depositos.Deposito Form_deposito = new Depositos.Deposito(padre, usuarioActual, NumeroDeposito,cbCuenta.Text);
            Form_deposito.Show();
            this.Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void cbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarioActual = cbUsuario.Text;
            cbCuenta.Items.Clear();
            cbCuenta.Text = "";
            con.query = "SELECT Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta C JOIN ESCUADRON_SUICIDA.Cliente K ON (C.Cod_Cli=K.Cod_Cli) WHERE Usuario='" + usuarioActual + "' AND C.Estado='Habilitada'";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbCuenta.Items.Add(con.lector.GetSqlDecimal(0).ToString());
            }
            con.cerrarConexion();
        }

        private void cbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
