using Datos;
using Logica.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Classe
{
    public class LogicaPorcentaje : IPorcentaje
    {
        private ApiComercioContext db;
        public LogicaPorcentaje(ApiComercioContext db)
        {
            this.db = db;
        }
        public List<Procentaje> GetPorcentajes()
        {
            return db.Procentajes.ToList();
        }
        public Procentaje GetProcentajeID(int id )
        {
            return db.Procentajes.Where(a => a.IdProcentaje == id).FirstOrDefault();
        }
        public Object SetPorcentajePost(Procentaje procentaje)
        {
            try
            {
                db.Procentajes.Add(procentaje);
                db.SaveChanges();
                return new { mensaje = "Se guardo corretamente" };
            }
            catch (Exception ex) 
            {
                return new { mensaje = "Comunicate con el Adminitrador " };
            }
        }
        public object SetPorcentajePut(int id ,Procentaje procentaje)
        {
            try
            {
                procentaje.IdProcentaje = id;
                db.Procentajes.Update(procentaje);
                db.SaveChanges();
                return new { mensaje = "Se Guardo Corretamente " };

            }
            catch (Exception ex)
            {
                return new { mensaje = "Comunicate con el Administrador " };
            }
        }
        public object SetPorcentajeDele( int id)
        {
            try
            {
                Datos.Procentaje procentaje = new Datos.Procentaje();
                procentaje.IdProcentaje = id;
                int validar = db.Productos.Where(a => a.IdProcentaje == id).Count();
                if (validar > 0)
                {
                    return new { mensaje = "tiene parametros vigente " };
                }
                db.Procentajes.Remove(procentaje);
                db.SaveChanges();
                return new { mensaje = "Se elimino corretamente " };
            }
            catch (Exception ex)
            {
                return new { mensaje = "Comunicate con el Administrador " };
            }

        }

    }
}
