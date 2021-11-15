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
    public class EstadoTicketController
    {
        EstadosTicketView vista; 
        EstadosTicketDAO estadosTicketDAO = new EstadosTicketDAO();
        EstadoTicket estadoTicket = new EstadoTicket(); 
        public EstadoTicketController( EstadosTicketView estadosTicketView)
        {
            vista = estadosTicketView;
            vista.GuardarButton.Click += new EventHandler(GuardarEstado);
            vista.ModificarButton.Click += new EventHandler(ModificarEstado);
            vista.Load += Vista_Load;
        }

        private void Vista_Load(object sender, EventArgs e)
        {
            ListarTicket();
            vista.GuardarButton.Enabled = false;
            vista.EstadoTicketComboBox.Enabled = false;
            vista.WindowState = FormWindowState.Maximized;
        }

        private void ListarTicket()
        {
            vista.EstadosTicketDataGridView.DataSource = estadosTicketDAO.GetTicket(); 
        }

        private void ModificarEstado(object sender, EventArgs e)
        {
            if (vista.EstadosTicketDataGridView.SelectedRows.Count > 0)
            {
                vista.GuardarButton.Enabled = true;
                vista.EstadoTicketComboBox.Enabled = true; 
                vista.IdTicketTextBox.Text = vista.EstadosTicketDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.EstadoTicketComboBox.SelectedItem = vista.EstadosTicketDataGridView.CurrentRow.Cells["ESTADO"].Value.ToString(); 
            } else
            {
                MessageBox.Show("Debes seleccionar un registro"); 
            }
        }

        private void GuardarEstado(object sender, EventArgs e)
        {
            if (RevisarContenidoControles())
            {
                estadoTicket.Estado = vista.EstadoTicketComboBox.SelectedItem.ToString();
                estadoTicket.Id = Convert.ToInt32(vista.IdTicketTextBox.Text);

                bool inserto = estadosTicketDAO.GuardarEstado(estadoTicket);

                if (inserto)
                {
                    MessageBox.Show("Registro guardado exitosamente");
                    LimpiarControles();
                    ListarTicket(); 
                    vista.GuardarButton.Enabled = false;
                    vista.EstadoTicketComboBox.Enabled = false; 
                }
            }
           
        }

        private void LimpiarControles()
        {
            vista.IdTicketTextBox.Clear();
            vista.EstadoTicketComboBox.SelectedItem = "";  
        }

        private bool RevisarContenidoControles()
        {
            if (vista.IdTicketTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.IdTicketTextBox, "Debes seleccionar un ticket");
                vista.ModificarButton.Focus();
                return false;
            }

            return true;
        }
    }
}
