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
    public partial class AltaRolViejo : Form
    {
        public AltaRolViejo()
        {
            InitializeComponent();
            Conexion con = new Conexion();
            con.query = "SELECT Nombre FROM dbo.Funcionalidades";
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
            }

            Conexion con = new Conexion();

            //INSERTAR DATOS EN LA BD
            con.query = "INSERT INTO dbo.Roles (Nombre, Estado) VALUES ('" +txtNombre.Text+ "', '" +ckEstado.Enabled + "')";
            con.ejecutarNoQuery();

            foreach (object itemsChequeados in cblFuncionalidades.CheckedItems) {
                con.query = "INSERT INTO dbo.FuncionalidadesPorRol (Id_Rol, Id_Funcionalidad) VALUES ((SELECT Id_Rol FROM dbo.Roles WHERE Nombre = '" +txtNombre.Text+ "'),(SELECT D.Id_Funcionalidad FROM dbo.Funcionalidades D WHERE D.Nombre = '" +itemsChequeados.ToString()+ "'))";
                con.ejecutarNoQuery();
                
            }

            MessageBox.Show("Datos guardados correctamente");
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        
        }

        private void cblFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
