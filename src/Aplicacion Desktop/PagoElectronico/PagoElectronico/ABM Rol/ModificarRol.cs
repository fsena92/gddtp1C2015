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
    public partial class ModificarRol : Form
    {
        private String ID_Seleccionado;
        private Login.Tablero padre;

        public ModificarRol(Login.Tablero ruta,String seleccion ,String nombre)
        {
            InitializeComponent();
            padre = ruta;
            ID_Seleccionado = seleccion;
            txtNombre.Text = nombre;
            Conexion con = new Conexion();
           

            //CARGA FUNCIONALIDADES DEL ROL
            con.query = "SELECT F.Nombre FROM ESCUADRON_SUICIDA.Roles R JOIN ESCUADRON_SUICIDA.FuncionalidadesPorRol FR ON (FR.Id_Rol = R.Id_Rol) JOIN ESCUADRON_SUICIDA.Funcionalidades F ON (F.Id_Funcionalidad = FR.Id_Funcionalidad) WHERE R.Id_Rol = '" + ID_Seleccionado + "'";
            con.ejecutarQuery();

            while (con.leerReader())
            {
                cblFuncionalidades.Items.Add(con.lector.GetString(0), true);
                //cblFuncionalidades;
            }

            con.cerrarConexion();

            //CARGA LAS FUNCIONALIDADES NO POSEIDAS
            con.query = "SELECT F.Nombre FROM ESCUADRON_SUICIDA.Funcionalidades F WHERE F.Id_funcionalidad NOT IN (SELECT FR.Id_funcionalidad FROM ESCUADRON_SUICIDA.FuncionalidadesPorRol FR WHERE (FR.Id_rol = '" + ID_Seleccionado + "'))";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cblFuncionalidades.Items.Add(con.lector.GetString(0));
                //cblFuncionalidades;
            }
            con.cerrarConexion();

            //CARGA ESTADO DEL ROL
            con.query = "SELECT Estado FROM ESCUADRON_SUICIDA.Roles WHERE Id_rol = '" + ID_Seleccionado + "' ";
            con.ejecutarQuery();
            con.leerReader();
            ckEstado.Checked = (con.lector.GetBoolean(0));

            con.cerrarConexion();

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            con.query = "UPDATE ESCUADRON_SUICIDA.Roles SET Nombre= '" + txtNombre.Text + "' WHERE Id_rol = '" + ID_Seleccionado + "' ";
            con.ejecutarNoQuery();

            int estadoActual;
            if (ckEstado.Checked) {estadoActual=1;} else{estadoActual=0;};

            con.query = "UPDATE ESCUADRON_SUICIDA.Roles SET Estado= (" + estadoActual + ") WHERE Id_rol = '" + ID_Seleccionado + "' ";
            con.ejecutarNoQuery();

            con.query = "DELETE FROM ESCUADRON_SUICIDA.FuncionalidadesPorRol WHERE Id_rol = '" + ID_Seleccionado + "'";
            con.ejecutarNoQuery();

            foreach (object itemsChequeados in cblFuncionalidades.CheckedItems)
            {
                con.query = "INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol, Id_Funcionalidad) VALUES(('" + ID_Seleccionado + "'),(SELECT F2.Id_Funcionalidad FROM ESCUADRON_SUICIDA.Funcionalidades F2 WHERE F2.Nombre = '" + itemsChequeados.ToString() + "'))";
                con.ejecutarNoQuery();

            }

            MessageBox.Show("Datos modificados correctamente");
            padre.Show();
            this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void ckEstado_CheckedChanged(object sender, EventArgs e)
        {

        }
      
    }
}