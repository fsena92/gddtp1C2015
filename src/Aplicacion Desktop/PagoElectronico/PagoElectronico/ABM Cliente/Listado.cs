using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Cliente
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Refresh();/*TODO: no estoy seguro*/
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            /*Conexion con = new Conexion();
            con.abrirConexion();
            con.query = "SELECT 1 FROM dbo.Cliente WHERE Nombre LIKE '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = con.SelectDataTable(con.query); */
        }

        private void btn_seleccion_Click(object sender, EventArgs e)
        {

        }
    }
}
