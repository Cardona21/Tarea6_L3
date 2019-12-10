using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Fiestas
{



    public class SeguridadBL
    {
        Contexto _contexto;
        public BindingList<Usuario> ListaUsuario { get; set; }

        public SeguridadBL()
        {
            _contexto = new Contexto();
            ListaUsuario = new BindingList<Usuario>();

        }
        public BindingList<Usuario> ObtenerUsuario()
        {
            _contexto.Usuarios.Load();
            ListaUsuario = _contexto.Usuarios.Local.ToBindingList();
            return ListaUsuario;

        }
        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }
        public Resultado GuardarUsuario(Usuario usuario)
        {
            var resultado = Validar(usuario);
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


            var nuevoUsuario = new Usuario();
            ListaUsuario.Add(nuevoUsuario);

        }

        public bool EliminarUsuario(int id)
        {
            foreach (var Usuariolista in ListaUsuario)
            {
                if (Usuariolista.Id == id)
                {
                    ListaUsuario.Remove(Usuariolista);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Usuario usuario)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (usuario == null)
            {
                resultado.Mensaje = "Agregue un usuario valido";
                resultado.Exitoso = false;
                return resultado;
            }

            return resultado;
        }

        public Usuario Autorizar(string nombreUsuario, string Contraseña)
        {
            var usuarios = _contexto.Usuarios.ToList();

            foreach (var usuarioBD in usuarios)
            {
                if (nombreUsuario == usuarioBD.Nombre && Contraseña == usuarioBD.Password)
                {
                    return usuarioBD;
                }

            }


            return null;
        }
    }
}

