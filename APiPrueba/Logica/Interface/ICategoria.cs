using Datos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interface
{
    public interface ICategoria
    {
        List<Categorium> GetCategoria();
        Categorium GetCategorium(int id);
       void SetCategoria(Categorium categoria);
        void SetCategoriPut(int id,Categorium categoria);
        object SetCategoriDele(int id );
    }
}
