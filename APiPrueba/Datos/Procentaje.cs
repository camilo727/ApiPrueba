using System;
using System.Collections.Generic;

namespace Datos
{
    public partial class Procentaje
    {
        public Procentaje()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdProcentaje { get; set; }
        public int Procentaje1 { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
