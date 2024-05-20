using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interface
{
    public interface IPorcentaje
    {
        List<Procentaje> GetPorcentajes();
        Procentaje GetProcentajeID(int Id);
        object SetPorcentajePost(Procentaje procentaje);
        object SetPorcentajePut(int id ,Procentaje procentaje);
        object SetPorcentajeDele( int id );

    }
}
