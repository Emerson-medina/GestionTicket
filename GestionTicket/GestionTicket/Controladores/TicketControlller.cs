using GestionTicket.Modelos.DAO;
using GestionTicket.Modelos.Entidades;
using GestionTicket.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTicket.Controladores
{
    public class TicketControlller
    {
        TicketView vista;
        MenuView vistaMenu; 

        TicketDAO ticketDAO = new TicketDAO();
        Ticket ticket = new Ticket();

        public TicketControlller (TicketView view, MenuView menuView)
        {
            vistaMenu = menuView; 
            vista = view;
            vista.GuardarButton.Click += new EventHandler(GuardarTicket);
            vista.ClienteButton.Click += new EventHandler(MostrarClientes);
            vista.TipoServicioButton.Click += new EventHandler(MostrarTipoServicio);
            vista.Load += Vista_Load;
        }

        private void Vista_Load(object sender, EventArgs e)
        {
            vista.WindowState = FormWindowState.Maximized; 
        }

        private void MostrarTipoServicio(object sender, EventArgs e)
        {
            TipoServicioView tipoServicioView = new TipoServicioView(vista);
            tipoServicioView.SeleccionarButton.Visible = true;
            tipoServicioView.MdiParent = vistaMenu;
            tipoServicioView.Show();
        }

        public TicketControlller()
        {
            
        }

        private void MostrarClientes(object sender, EventArgs e)
        {
            ClienteView clienteView = new ClienteView(vista);
            clienteView.SeleccionarButton.Visible = true;
            clienteView.MdiParent = vistaMenu; 
            clienteView.Show(); 
        }

        private void GuardarTicket(object sender, EventArgs e)
        {
            if (RevisarContenidoControles())
            {
                if (vista.operacion == "Modificar")
                {
                    ticket.IdTicket = vista.IdTicket; 
                    ticket.IdCliente = vista.IdCliente;
                    ticket.IdTipoServicio = vista.IdTipoServicio;
                    ticket.Detalle = vista.DetalleTextBox.Text;
                    ticket.Costo = Convert.ToDecimal(vista.CostoTextBox.Text);

                    bool modifico = ticketDAO.ModificarTicket(ticket); 

                    if (modifico)
                    {
                        MessageBox.Show("Ticket modificado exitosamente");
                        LimpiarControles();
                    } else
                    {
                        MessageBox.Show("Ocurrió un problema al intentar modificar el ticket");
                    } 

                } else
                {
                    ticket.IdCliente = vista.IdCliente;
                    ticket.IdTipoServicio = vista.IdTipoServicio;
                    ticket.Detalle = vista.DetalleTextBox.Text;
                    ticket.Costo = Convert.ToDecimal(vista.CostoTextBox.Text);

                    bool inserto = ticketDAO.AddTicket(ticket);
                    if (inserto)
                    {
                        MessageBox.Show("Ticket agregado exitosamente");
                        LimpiarControles();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un problema al intentar agregar el ticket");
                    }
                }
                
            } else
            {
                return; 
            }
            
        }

        private void LimpiarControles()
        {
            vista.ClienteTextBox.Clear();
            vista.TipoServicioTextBox.Clear();
            vista.DetalleTextBox.Clear();
            vista.CostoTextBox.Clear();
        }

        private bool RevisarContenidoControles()
        {
            if (vista.CostoTextBox.Text != "")
            {
                try
                {
                    Convert.ToDecimal(vista.CostoTextBox.Text);
                }
                catch (Exception)
                {
                    vista.errorProvider1.SetError(vista.CostoTextBox, "Debes ingresar una cantidad");

                    return false;
                }
            }
             

            if (vista.ClienteTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.ClienteTextBox, "Debes ingresar un Cliente");
                vista.ClienteTextBox.Focus();
                return false;
            }

            if (vista.TipoServicioTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.TipoServicioTextBox, "Debes ingresar un tipo de servicio");
                vista.TipoServicioTextBox.Focus();
                return false;
            }

            if (vista.DetalleTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DetalleTextBox, "Debes ingresar los detalles");
                vista.DetalleTextBox.Focus();
                return false;
            }

            if (vista.CostoTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.CostoTextBox, "Debes ingresar el costo del ticket");
                vista.CostoTextBox.Focus();
                return false;
            }

            return true;
        }
    }
}
