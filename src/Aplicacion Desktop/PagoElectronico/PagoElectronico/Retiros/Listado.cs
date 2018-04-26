using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Retiros
{
    public partial class Listado : Form
    {
        private Login.Tablero padre;
        private String NumeroCuenta;
        private String usuarioActual;
        private Conexion con = new Conexion();

        public Listado(Login.Tablero ruta,String usuario,String rol)
        {
            InitializeComponent();
            padre = ruta;
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

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if(cbUsuario.Text=="") { MessageBox.Show("Seleccione un usuario"); return; }
            if (cbCuenta.Text== "") { MessageBox.Show("Seleccione una cuenta"); return; }
            NumeroCuenta = cbCuenta.Text;
            Retiros.Retiro Form_retiro = new Retiros.Retiro(padre,usuarioActual,NumeroCuenta);
            Form_retiro.Show();
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
            con.query = "SELECT Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta C JOIN ESCUADRON_SUICIDA.Cliente K ON (C.Cod_Cli=K.Cod_Cli) WHERE Usuario='" + usuarioActual+ "' AND C.Estado='Habilitada'";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbCuenta.Items.Add(con.lector.GetSqlDecimal(0).ToString());
            }
            con.cerrarConexion();
        }
    }
}
