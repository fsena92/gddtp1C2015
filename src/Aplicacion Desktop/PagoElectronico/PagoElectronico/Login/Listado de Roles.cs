using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Login
{
    public partial class Listado_de_Roles : Form
    {
        private Login padre;
        private String usuarioActual;
        private Conexion con = new Conexion();

        public Listado_de_Roles(Login ruta, String usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            padre = ruta;
            con.query = "SELECT Nombre FROM ESCUADRON_SUICIDA.RolPorUsuario RU JOIN ESCUADRON_SUICIDA.Roles R ON (RU.Id_Rol=R.Id_Rol)WHERE RU.Usuario='"+usuario+"'";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbRoles.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cbRoles.Text == "")
            {
                MessageBox.Show("Seleccione el rol deseado");
                return;
            }

            Tablero form_Tab = new Tablero(padre, usuarioActual, cbRoles.Text);
            form_Tab.Show();
            this.Close();
        }
    }
}
