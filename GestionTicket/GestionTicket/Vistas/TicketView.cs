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
    public partial class TicketView : Form
    {
        MenuView VistaMenu;
        public int IdCliente;
        public int IdTipoServicio;

        public TicketView(MenuView menuView)
        {
            
            InitializeComponent();
            VistaMenu = menuView; 
            TicketControlller controlador = new TicketControlller(this,VistaMenu); 

        }
        public TicketView ()
        {
            TicketControlller controlador = new TicketControlller(this, VistaMenu);
        }
    }
}
