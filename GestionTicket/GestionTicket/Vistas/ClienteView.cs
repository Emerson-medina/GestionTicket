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
    public partial class ClienteView : Form
    {
        TicketView vistaTicket; 
        public ClienteView(TicketView ticketView)
        {
            InitializeComponent();
            vistaTicket = ticketView; 

            ClienteController controlador = new ClienteController(this,vistaTicket); 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
