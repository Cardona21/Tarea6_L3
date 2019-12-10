using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Fiestas
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuarioAdmin = new Usuario(1, "Ana", "123");
            usuarioAdmin.Tipo = "Administrador";
            usuarioAdmin.puedeverFactura = true;
            usuarioAdmin.puedeverReporteFactura = true;
            usuarioAdmin.PuedeverInventario = true;
            usuarioAdmin.puedeverReserva = true;
            usuarioAdmin.puedeverReporteInventario = true;
            usuarioAdmin.puedeverContrato = true;
            usuarioAdmin.puedeverPoliticas = true;
            contexto.Usuarios.Add(usuarioAdmin);

            var usuarioCaja = new Usuario(2, "Reyna", "456");
            usuarioCaja.Tipo = "Cajero";
            usuarioCaja.puedeverFactura = true;
            usuarioCaja.puedeverReserva = true;
            usuarioCaja.puedeverReporteFactura = true;
            usuarioCaja.puedeverContrato = true;
            usuarioCaja.puedeverPoliticas = true;
            usuarioCaja.PuedeverInventario = false;
            usuarioCaja.puedeverReporteInventario = false;
            contexto.Usuarios.Add(usuarioCaja);
            

            var usuarioReservas = new Usuario(3, "Carlos", "789");
            usuarioReservas.Tipo = "Reservar";
            usuarioReservas.puedeverFactura = true;
            usuarioReservas.puedeverReporteInventario = true; 
            usuarioReservas.puedeverReserva = true;
            usuarioReservas.puedeverContrato = true;
            usuarioReservas.puedeverReporteFactura = false;
            usuarioReservas.puedeverPoliticas = false;
            usuarioReservas.PuedeverInventario = false;
            contexto.Usuarios.Add(usuarioReservas);


            var categoria1 = new Categoria();
            categoria1.Descripcion = "Mesas";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Sillas";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Manteles";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Salones";
            contexto.Categorias.Add(categoria4);


            base.Seed(contexto);
        }
    }
}
