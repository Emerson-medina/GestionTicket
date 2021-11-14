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
        TicketView ticketView;
        TipoServicioView tipoServicioView; 
        public MenuController (MenuView view)
        {
            vista = view;
            vista.TipoServicioToolStripButton.Click += new EventHandler(MostrarTipoServicio);
            vista.AgregarTicketToolStripButton.Click += new EventHandler(MostrarAgregarTicket);
            vista.Deactivate += Vista_Deactivate;
            vista.Load += Vista_Load;
        }

        private void Vista_Deactivate(object sender, EventArgs e)
        {
            //vista.Hide(); 
        }

        private void MostrarAgregarTicket(object sender, EventArgs e)
        {
            if (ticketView == null)
            {
                ticketView = new TicketView(vista);
                ticketView.MdiParent = vista;
                ticketView.FormClosed += TicketView_FormClosed;
                ticketView.Show();
            } else
            {
                ticketView.Activate(); 
            }  
        }

        private void TicketView_FormClosed(object sender, FormClosedEventArgs e)
        {
            ticketView = null;
        }

        private void Vista_Load(object sender, EventArgs e)
        {
            vista.WindowState = FormWindowState.Maximized;
        }

        private void MostrarTipoServicio(object sender, EventArgs e)
        {
            if (tipoServicioView == null)
            {
                tipoServicioView = new TipoServicioView();
                tipoServicioView.MdiParent = vista;
                tipoServicioView.FormClosed += TipoServicioView_FormClosed;
                tipoServicioView.Show();
            } else
            {
                tipoServicioView.Activate(); 
            }
        }

        private void TipoServicioView_FormClosed(object sender, FormClosedEventArgs e)
        {
            tipoServicioView = null; 
        }
    }
}
