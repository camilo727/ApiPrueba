using System;
using System.Collections.Generic;

namespace Datos
{
    public partial class Ventum
    {
        public int ÎdVenta { get; set; }
        public int? ÎdUsuario { get; set; }
        public int? IdProducto { get; set; }
        public virtual Usuario? ÎdUsuario1 { get; set; }
        public virtual Producto? ÎdUsuarioNavigation { get; set; }
    }
}
