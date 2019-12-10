using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Fiestas
{
    public class ReservaBL
    {
        Contexto _contexto;

        public BindingList<Reserva> ListaReserva { get; set; }

        public ReservaBL()
        {
            _contexto = new Contexto();

            ListaReserva = new BindingList<Reserva>();
            
        }
        public BindingList<Reserva> ObtenerReservas()
        {
            _contexto.Reservas.Load();
            ListaReserva = _contexto.Reservas.Local.ToBindingList();
            return ListaReserva;

        }
        public BindingList<Reserva> ObtenerReservas(string buscar)
        {
            var query = _contexto.Reservas.Where(p => p.Descripcion.ToLower().Contains(buscar.ToLower()) == true).ToList();

            var resultado = new BindingList<Reserva>(query);
            return resultado;
        }
        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarResrva(Reserva reserva)
        {
            var resultado = Validar(reserva);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }
            _contexto.SaveChanges();
            resultado.Exitoso = true;

            return resultado;
        }
        public void AgregarReserva()
        {


            var nuevaReserva = new Reserva();
            ListaReserva.Add(nuevaReserva);

        }

        public bool EliminarResrva(int id)
        {
            foreach (var reservalista in ListaReserva)
            {
                if (reservalista.Id == id)
                {
                    ListaReserva.Remove(reservalista);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Reserva reserva)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;
        
            if (reserva == null )
            {
                resultado.Mensaje = "Agregue una reserva valida";
                resultado.Exitoso = false;
                return resultado;
            }
            if(string.IsNullOrEmpty(reserva.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripcion";
                resultado.Exitoso = false;
            }
            if (reserva.Existencia == 0)
            {
                resultado.Mensaje = "La existencia debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            if (reserva.Precio == 0)
            {
                resultado.Mensaje = "el precio debe de ser mayor que cero";
                resultado.Exitoso = false;
            }
            if (reserva.CategoriaId == 0)
            {
                resultado.Mensaje = "Seleccione una categoria";
                resultado.Exitoso = false;
            }
           
            return resultado;
           }
        

       
    }
    public class Reserva
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public byte[] Foto { get; set; }
        public bool Activo { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }


    }
}
