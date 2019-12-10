using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Fiestas
{
    public class ClientesBL
    {
        Contexto _contexto;
        public BindingList<Cliente> listaClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            listaClientes = new BindingList<Cliente>();
        }

      public BindingList<Cliente> ObtenerCliente()
        {
            _contexto.Clientes.Load();
            listaClientes = _contexto.Clientes.Local.ToBindingList();
            return listaClientes;
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }
        public Resultado GuardarCliente(Cliente cliente)
        {
            var resultado = Validar(cliente);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }
            _contexto.SaveChanges();
            resultado.Exitoso = true;

            return resultado;
        }
        public void AgregarCliente()
        {


            var nuevoCliente = new Cliente();
            listaClientes.Add(nuevoCliente);

        }
     

        public bool EliminarCliente(int id)
        {
            foreach (var clientes in listaClientes.ToList())
            {
                if (clientes.Id == id)
                {
                    listaClientes.Remove(clientes);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }
        private Resultado Validar(Cliente cliente)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;
            if (cliente  != null)
            {
                resultado.Mensaje = "Agregue un cliente valido";
                resultado.Exitoso = true;
                return resultado;
            }
            if (string.IsNullOrEmpty(cliente.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese un Nombre";
                resultado.Exitoso = false;
            }
            return resultado;

        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}


   


