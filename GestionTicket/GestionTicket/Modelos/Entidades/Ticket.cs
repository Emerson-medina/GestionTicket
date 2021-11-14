using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTicket.Modelos.Entidades
{
    public class Ticket
    {
        public int IdCliente { get; set; }
        public int IdTipoServicio { get; set; }
        public int IdEquipo { get; set; }
        public int IdTicket { get; set; }
        public string Detalle { get; set; }
        public decimal Costo { get; set; }
        public decimal Total { get; set; }

    }
}
