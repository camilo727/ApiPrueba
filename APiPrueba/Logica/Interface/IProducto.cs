using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interface
{
    public interface IProducto
    {
        List<Producto> GetProductos();
        object SetProductoPut(Producto producto);
        object GetProductoId(int id);
        object SetProductoDele(int id);
    }
}
