using System;
using System.Collections.Generic;

namespace Datos
{
    public partial class Producto
    {
        public Producto()
        {
            Venta = new HashSet<Ventum>();
        }

        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoBarra { get; set; }
        public string? Descripcion { get; set; }
        public string? Marca { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? PrecioDeVenta { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdProcentaje { get; set; }

        public virtual Categorium? IdCategoriaNavigation { get; set; }
        public virtual Procentaje? IdProcentajeNavigation { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
