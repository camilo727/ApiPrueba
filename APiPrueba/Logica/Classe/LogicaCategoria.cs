using Datos;
using Logica.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Classe
{
    public class LogicaCategoria : ICategoria
    {
        private ApiComercioContext db;
        public LogicaCategoria(ApiComercioContext db)
        {
            this.db = db;
        }
        public List<Categorium> GetCategoria()
        {
           return db.Categoria.ToList();
        }
        public Categorium GetCategorium(int id)
        {
            return db.Categoria.Where(a => a.IdCategoria == id).FirstOrDefault();
        }
       public void SetCategoria(Categorium categoria)
        {
            db.Categoria.Add(categoria);
            db.SaveChanges();
        }
        public void SetCategoriPut(int id,Categorium categoria)
        {
            categoria.IdCategoria = id;
            db.Categoria.Update(categoria);
            db.SaveChanges();
        }

        public object SetCategoriDele(int id)
        {
            Datos.Categorium categorium = new Datos.Categorium();
            categorium.IdCategoria=id;
            int Validad = db.Productos.Where(a=>a.IdCategoria==id).Count();
            if (Validad>0)
            {
                return new { mensaje = "tiene parametros vigente " };
            }
            db.Categoria.Remove(categorium);
            db.SaveChanges();
            return new { mensaje = "Se eliminado Corretamente  " };
        }

    }
}
