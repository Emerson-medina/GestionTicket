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
    public partial class TipoServicioView : Form
    {
        public TipoServicioView()
        {
            InitializeComponent();

            TipoServicioController controlador = new TipoServicioController(this); 
        }
    }
}
