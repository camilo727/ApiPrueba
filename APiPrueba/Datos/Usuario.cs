using System;
using System.Collections.Generic;

namespace Datos
{
    public partial class Usuario
    {
        public Usuario()
        {
            Venta = new HashSet<Ventum>();
        }

        public int ÎdUsuario { get; set; }
        public string? Nombre { get; set; }
        public int? Edad { get; set; }
        public int? Identifiacacion { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
