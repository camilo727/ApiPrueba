using Datos;
using Logica.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Classe
{
    public class LogicaProducto : IProducto
    {
        private ApiComercioContext db;

        public LogicaProducto(ApiComercioContext db )
        {
            this.db = db;
        }
        public List<Producto> GetProductos() 
        {
            return db.Productos.ToList();
        }
        public object SetProductoPut(Producto producto)
        {
            try
            {
                decimal PrecioCompra = producto.PrecioCompra ?? 0;
                decimal Iva = PrecioCompra * 0.19m;
                producto.PrecioDeVenta= PrecioCompra + Iva;
                if (producto.IdProcentaje>0 || producto.IdProcentaje != null) 
                {
                    Procentaje procentaje = new Procentaje();
                    procentaje = db.Procentajes.Where(a => a.IdProcentaje == producto.IdProcentaje).FirstOrDefault();
                    decimal Porciento = procentaje.Procentaje1 /100;
                    decimal descuento = PrecioCompra * Porciento;
                    producto.PrecioDeVenta = PrecioCompra - descuento;
                }
                db.Productos.Add( producto );
                db.SaveChanges();
                return new { mensaje = "Se guardo corretamente" };

            }
            catch (Exception ex) 
            {
                return new { mensaje = "Comunicate con el Adminitrador " };
            }

        }
        public object GetProductoId(int id )
        {
            try
            {
                Producto producto = new Producto();
                producto = db.Productos.Where(a=>a.IdProducto==id).FirstOrDefault();
                Categorium categoria = new Categorium();
                categoria = db.Categoria.Where(a => a.IdCategoria == producto.IdProducto).FirstOrDefault();
                Procentaje procentaje = new Procentaje();
                procentaje = db.Procentajes.Where(a=>a.IdProcentaje == producto.IdProcentaje).FirstOrDefault();
                return new { mensaje = " Nombre:"+ producto.Nombre+" ,Codigo de Barra: "+ producto.CodigoBarra+" ,Descripcion:" + producto.Descripcion + " ,Precio compra:"+ producto.PrecioCompra+" ,Precio venta:"+ producto.PrecioDeVenta+ " ,Categoria:"+categoria.Nombre  };
            } catch (Exception ex)
            {
                return new { mensaje = "Comunicate con el Adminitrador " };
            }
           

        }
        public object SetProductoDele(int id)
        {
            try
            {
                Datos.Producto producto = new Datos.Producto();
                producto.IdProducto = id;
                int Validad = db.Venta.Where(a=>a.IdProducto == producto.IdProducto).Count();
                if ( Validad > 0 ) {
                    return new { mensaje = " Esta corrupto " };
                }
                db.Productos.Remove(producto);
                db.SaveChanges();
                return new { mensaje = "Se eliminado Corretamente  " };

            }
            catch (Exception ex)
            {
                return new { mensaje = "Comunicate con el Adminitrador " };
            }
            
        }

    }
}
