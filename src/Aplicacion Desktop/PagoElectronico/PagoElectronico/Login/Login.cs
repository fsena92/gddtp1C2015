using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comparadores;

namespace PagoElectronico.Login
{
    public partial class Login : Form
    {
        private Conexion con = new Conexion();
        int intentos = 0;

        public Login()
        {
            InitializeComponent();
        }

        private void but_aceptar_Click(object sender, EventArgs e)
        {
            con.cerrarConexion();
            con.query = "SELECT Password, Estado FROM ESCUADRON_SUICIDA.Usuario WHERE Usuario='" + txtUsuario.Text + "'";
            con.ejecutarQuery();
            if (con.leerReader())
            {
                if (!con.lector.GetBoolean(1))
                {
                    MessageBox.Show("El usuario no esta habilitado");
                    return;
                }

                String encriptada = txtContraseña.Text.Sha256();

                if (!(encriptada == con.lector.GetString(0)))
                {
                    con.cerrarConexion();
                    MessageBox.Show("Contraseña incorrecta");
                    intentos++;
                    grabar_intento("Fallido");
                    if (intentos == 3)
                    {
                        con.query = "UPDATE ESCUADRON_SUICIDA.Usuario SET Estado=0 WHERE Usuario='" + txtUsuario.Text + "'";
                        con.ejecutarNoQuery();
                        intentos = 0;
                    }
                    return;
                }

                con.cerrarConexion();

                grabar_intento("Efectivo");
                con.query = "SELECT COUNT(ID_Rol) FROM ESCUADRON_SUICIDA.RolPorUsuario WHERE Usuario='" + txtUsuario.Text + "'";
                con.ejecutarQuery();
                con.leerReader();
                if (con.lector.GetInt32(0) == 1)
                {
                    con.cerrarConexion();
                    con.query = "SELECT Nombre FROM ESCUADRON_SUICIDA.Roles R JOIN ESCUADRON_SUICIDA.RolPorUsuario RU ON(R.Id_Rol=RU.Id_Rol) WHERE RU.Usuario='" + txtUsuario.Text + "'";
                    con.ejecutarQuery();
                    con.leerReader();
                    Tablero tab = new Tablero(this, txtUsuario.Text, con.lector.GetString(0));
                    con.cerrarConexion();
                    tab.Show();
                    this.Hide();
                }
                else
                {
                    con.cerrarConexion();
                    Listado_de_Roles form_List = new Listado_de_Roles(this, txtUsuario.Text);
                    this.Hide();
                    form_List.Show();
                }
            }
            else { con.cerrarConexion(); MessageBox.Show("No existe el usuario"); return; }
        }

        private void but_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grabar_intento(String tipo)
        {
            con.query = "INSERT INTO ESCUADRON_SUICIDA.LoginAudit (Usuario,Fecha,Resultado,Intentos)"+
                                                    " VALUES('"+txtUsuario.Text+"',GetDate(),'"+tipo+"',"+intentos+")";
            con.ejecutarNoQuery();
        }
    }
}
