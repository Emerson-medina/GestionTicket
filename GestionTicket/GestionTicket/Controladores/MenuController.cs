using GestionTicket.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTicket.Controladores
{
    public class MenuController
    {
        MenuView vista; 
        public MenuController (MenuView view)
        {
            vista = view;
            vista.TipoServicioToolStripButton.Click += new EventHandler(MostrarTipoServicio);
            vista.Load += Vista_Load;
        }

        private void Vista_Load(object sender, EventArgs e)
        {
            vista.WindowState = FormWindowState.Maximized;
        }

        private void MostrarTipoServicio(object sender, EventArgs e)
        {
            TipoServicioView tipoServicioView = new TipoServicioView();
            tipoServicioView.MdiParent = vista;  
            tipoServicioView.Show(); 
        }
    }
}
