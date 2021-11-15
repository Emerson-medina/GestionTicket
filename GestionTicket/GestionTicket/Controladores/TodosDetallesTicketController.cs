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
    public class TodosDetallesTicketController
    {
        TodosDetallesTicketView vista;
        TodosDetallesTicketDAO todosDetallesTicketDAO = new TodosDetallesTicketDAO();
        TicketView ticketView;
        MenuController ControllerMenu; 

        public TodosDetallesTicketController(TodosDetallesTicketView view, MenuController menuController)
        {
            vista = view;
            ControllerMenu = menuController; 
            vista.ModificarButton.Click += new EventHandler(ModificarTicket);
            vista.EliminarButton.Click += new EventHandler(EliminarTicket); 
            vista.Load += Vista_Load;
        }

        private void EliminarTicket(object sender, EventArgs e)
        {

            if (vista.DetallesTicketDataGridView.SelectedRows.Count > 0)
            {
                Ticket ticket = new Ticket();
                ticket.IdTicket = Convert.ToInt32(vista.DetallesTicketDataGridView.CurrentRow.Cells["TICKET"].Value);

                bool elimino = todosDetallesTicketDAO.EliminarTicket(ticket); 

                if (elimino)
                {
                    MessageBox.Show("Ticket Eliminado exitosamente");
                    MostrarTodosDetallesTicket(); 
                }else
                {
                    MessageBox.Show("Tuvimos un error al intentar eliminar el ticket");
                }

            }
            else
            {
                MessageBox.Show("Debes seleccionar un registro");
            }
        }

        private void ModificarTicket(object sender, EventArgs e)
        {
            if (vista.DetallesTicketDataGridView.SelectedRows.Count > 0)
            {
                ControllerMenu.ticketView.ClienteTextBox.Text = vista.DetallesTicketDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                ControllerMenu.ticketView.IdTicket = Convert.ToInt32(vista.DetallesTicketDataGridView.CurrentRow.Cells["TICKET"].Value);
                ControllerMenu.ticketView.TipoServicioTextBox.Text = vista.DetallesTicketDataGridView.CurrentRow.Cells["TIPO_SERVICIO"].Value.ToString();
                ControllerMenu.ticketView.CostoTextBox.Text = vista.DetallesTicketDataGridView.CurrentRow.Cells["COSTO"].Value.ToString();
                ControllerMenu.ticketView.DetalleTextBox.Text = vista.DetallesTicketDataGridView.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                ControllerMenu.ticketView.IdCliente = Convert.ToInt32(vista.DetallesTicketDataGridView.CurrentRow.Cells["ID_CLIENTE"].Value); 

                ControllerMenu.ticketView.Show();                
                ControllerMenu.ticketView.operacion = "Modificar";
                vista.Close(); 
            } else
            {
                MessageBox.Show("Debes seleccionar un registro"); 
            }
        }

        private void Vista_Load(object sender, EventArgs e)
        {
            vista.WindowState = FormWindowState.Maximized;
            MostrarTodosDetallesTicket(); 
        }

        public void MostrarTodosDetallesTicket()
        {
            vista.DetallesTicketDataGridView.DataSource = todosDetallesTicketDAO.GetTodosDetallesTicket();
        }
    }
}
