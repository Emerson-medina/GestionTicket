using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTicket.Modelos.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public bool EsAdministrador { get; set; }
        public byte[] Imagen { get; set; }
        public string Clave { get; set; }
    }
}
