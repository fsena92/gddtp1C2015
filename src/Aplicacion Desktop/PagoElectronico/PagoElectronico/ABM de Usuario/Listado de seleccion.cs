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
    public partial class Listado_de_seleccion_usuario : Form
    {
        private char tipoDeSeleccion;
        private Login.Tablero padre;
        
        public Listado_de_seleccion_usuario(Login.Tablero ruta, char tipo)
        {
            InitializeComponent();
            tipoDeSeleccion = tipo;
            padre = ruta;
        }
        
        private void btn_limpiar_Click(object sender, EventArgs e)
        {

        }

        private void btn_seleccion_Click(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }
    }
}
