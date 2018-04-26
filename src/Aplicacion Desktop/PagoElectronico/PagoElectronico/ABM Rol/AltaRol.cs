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
    public partial class AltaRol : Form
    {
        private Login.Tablero padre;

        public AltaRol(Login.Tablero ruta)
        {
            InitializeComponent();
            padre = ruta;
            Conexion con = new Conexion();
            con.query = "SELECT Nombre FROM ESCUADRON_SUICIDA.Funcionalidades";
            con.ejecutarQuery();

            while (con.leerReader()) {
            
                cblFuncionalidades.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {   
            //VALIDO CAMPOS OBLIGATORIOS
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese Nombre de Rol");
                return;

            }

            if (txtNombre.Text.Contains(",")){
            
                MessageBox.Show("Ingrese Nombre valido");
                return;
            }

            bool tieneFuncionalidades= false;
            foreach (object itemsChequeados in cblFuncionalidades.CheckedItems) {

                tieneFuncionalidades = true;
            }

            if (!tieneFuncionalidades)
            {
                MessageBox.Show("Seleccione funcionalidad");
                return;
            }

            Conexion con = new Conexion();

            //INSERTAR DATOS EN LA BD
            con.query = "INSERT INTO ESCUADRON_SUICIDA.Roles (Nombre, Estado) VALUES ('" +txtNombre.Text+ "', '" +ckEstado.Enabled + "')";
            con.ejecutarNoQuery();

            foreach (object itemsChequeados in cblFuncionalidades.CheckedItems) {
                con.query = "INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol, Id_Funcionalidad) VALUES ((SELECT Id_Rol FROM ESCUADRON_SUICIDA.Roles WHERE Nombre = '" +txtNombre.Text+ "'),(SELECT D.Id_Funcionalidad FROM ESCUADRON_SUICIDA.Funcionalidades D WHERE D.Nombre = '" +itemsChequeados.ToString()+ "'))";
                con.ejecutarNoQuery();
                
            }

            MessageBox.Show("Datos guardados correctamente");
            padre.Show();
            this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        
        }

        private void cblFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            ckEstado.Checked=false;
            foreach (int i in cblFuncionalidades.CheckedIndices)
            {
                 cblFuncionalidades.SetItemChecked(i, false);
            }
        }
    }
}
