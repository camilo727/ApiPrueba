using Datos;
using Logica.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Classe
{
    public class LogicaVentas : IVentas
    {
        private ApiComercioContext db;
        public LogicaVentas()
        {
            db = new ApiComercioContext();
        }
        public object SetVentaPost(Ventum ventas)
        {
            try
            {
                db.Venta.Add(ventas);
                db.SaveChanges();
                return new { mensaje = "Se guardo Corretamente  " };
            }
            catch (Exception ex)
            {
                return new { mensaje = "Comunicate con el Adminitrador " };
            }
        }
        public object GetVetas(int id )
        {
            try
            {
                Usuario Usu = new Usuario();
                Ventum Ventas = new Ventum();
                Producto producto = new Producto();

                //List<Ventum> Ventas = ( from V in db.Venta 
                //                        join P in db.Producto on V.IdProducto equals P.IdProducto 
                //                        join U in db.Usuarios on V.ÎdUsuario equals U.ÎdUsuario select new { V.NombreUsu ,U.Nombre, V.NombrePro ,P.Nombre }
                //                         ).ToList();

                Ventas = db.Venta.Where(a => a.ÎdVenta == id).FirstOrDefault();
                producto = db.Productos.Where(a => a.IdProducto == Ventas.IdProducto).FirstOrDefault();
                Usu = db.Usuarios.Where(a => a.ÎdUsuario == Ventas.ÎdUsuario).FirstOrDefault();

                return new { mensaje = "Nombre cliente:"+Usu.Nombre+" ,Producto:"+ producto.Nombre+ " ,Precio producto="+ producto.PrecioDeVenta };
            }
            catch (Exception ex)
            {
                return new { mensaje = "Comunicate con el Adminitrador " };
            }
        }
        public object SetVentaDele(int id )
        {
            try
            {
                Ventum ventas = new Ventum();
                ventas.IdProducto = id;
                db.Venta.Remove(ventas);
                db.SaveChanges();
                return new { mensaje = "Se eliminado Corretamente" };
            }
            catch (Exception ex)
            {
                return new { mensaje = "Comunicate con el Adminitrador " };
            }
           
        }

    }
}
