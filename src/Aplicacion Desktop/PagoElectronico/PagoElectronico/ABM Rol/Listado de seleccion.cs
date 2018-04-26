using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Rol
{
    public partial class Listado_de_seleccion_Rol : Form
    {
        private char tipoDeSeleccion;
        private Login.Tablero padre;
        private String ID_Seleccionado="";
        private String nombre;

        public Listado_de_seleccion_Rol(Login.Tablero ruta, char tipo)
        {
            InitializeComponent();
            tipoDeSeleccion = tipo;
            padre = ruta;
            Conexion con = new Conexion();
            con.query = "SELECT Nombre FROM ESCUADRON_SUICIDA.Roles";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cmbRol.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();
        }

                
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (ID_Seleccionado == "") { MessageBox.Show("Seleccione un rol"); return; }

            Conexion con = new Conexion();

            if (tipoDeSeleccion == 'B')
            {
                con.query = "UPDATE ESCUADRON_SUICIDA.Roles SET Estado = 0 WHERE (ID_Rol = "+ID_Seleccionado+")";
                con.ejecutarQuery();
                con.cerrarConexion();
                MessageBox.Show("El Rol ha sido eliminado");
                padre.Show();
                this.Close();
            }
            else
            {
                ModificarRol form_ModifRol = new ModificarRol(padre, ID_Seleccionado,nombre);
                form_ModifRol.Show();
                this.Close();
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombre = cmbRol.SelectedItem.ToString();
            //SE GUARDA EL ID DEL ROL SELECCIONADO 
            Conexion con = new Conexion();
            con.query = "SELECT Id_Rol FROM ESCUADRON_SUICIDA.Roles WHERE Nombre = '" + nombre + "'";
            con.ejecutarQuery();
            con.leerReader();
            ID_Seleccionado = con.lector.GetInt32(0).ToString();
            con.cerrarConexion();
        }
        
    }
}
