using GestionTicket.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTicket.Vistas
{
    public partial class MenuView : Form
    {
        public MenuView()
        {
            InitializeComponent();

            MenuController controlador = new MenuController(this); 
        }
    }
}
