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
        public TicketView ticketView;
        TipoServicioView tipoServicioView;
        EstadosTicketView estadoTicketView;
        TodosDetallesTicketView todosDetallesTicketview; 
        public MenuController (MenuView view)
        {
            vista = view;
            vista.TipoServicioToolStripButton.Click += new EventHandler(MostrarTipoServicio);
            vista.AgregarTicketToolStripButton.Click += new EventHandler(MostrarAgregarTicket);
            vista.EstadoTicketToolStripButton.Click += new EventHandler(MostrarEstadoTicket);
            vista.TodosDetallesTicketToolStripButton.Click += new EventHandler(MostrarTodosDetallesTicket); 
            vista.Load += Vista_Load;
        }

        private void MostrarTodosDetallesTicket(object sender, EventArgs e)
        {
            if (todosDetallesTicketview == null)
            {
                todosDetallesTicketview = new TodosDetallesTicketView(this);
                todosDetallesTicketview.MdiParent = vista;
                todosDetallesTicketview.FormClosed += TodosDetallesTicketview_FormClosed;
                todosDetallesTicketview.Show();
            }
            else
            {
                todosDetallesTicketview.Activate();
            }
        }

        private void TodosDetallesTicketview_FormClosed(object sender, FormClosedEventArgs e)
        {
            todosDetallesTicketview = null; 
        }

        private void MostrarEstadoTicket(object sender, EventArgs e)
        {
            if (estadoTicketView == null)
            {
                estadoTicketView = new EstadosTicketView();
                estadoTicketView.MdiParent = vista;
                estadoTicketView.FormClosed += EstadoTicketView_FormClosed;
                estadoTicketView.Show();
            }
            else
            {
                estadoTicketView.Activate();
            }
        }

        private void EstadoTicketView_FormClosed(object sender, FormClosedEventArgs e)
        {
            estadoTicketView = null; 
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
