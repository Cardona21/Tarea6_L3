using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Fiestas
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }

        public bool PuedeverInventario { get; set; }
        public bool puedeverFactura { get; set; }
        public bool puedeverReserva { get; set; }
        public bool puedeverReporteFactura { get; set; }
        public bool puedeverReporteInventario { get; set; }
        public bool puedeverContrato { get; set; }
        public bool puedeverPoliticas { get; set; }

        public Usuario(int id, string nombre, string password)
        {
            Id = id;
            Nombre = nombre;
            password = Password;

        }
        public Usuario()
        {

        }
    }
}
