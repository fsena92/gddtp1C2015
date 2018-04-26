using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class Listado_Usuario : Form
    {
        public Listado_Usuario()
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

        }

        private void btn_seleccion_Click(object sender, EventArgs e)
        {

        }
    }
}
