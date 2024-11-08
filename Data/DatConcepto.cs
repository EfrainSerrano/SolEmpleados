using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DatConcepto
    {
        public List<Conceptos> Obtener()
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                return db.Conceptos.OrderBy(x => x.Concepto).ToList();
            }
        }

        public Conceptos Obtener(int id)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                return db.Conceptos.Where(x => x.IdConcepto == id).FirstOrDefault();
            }
        }

        public void Agregar(Conceptos oConceptos)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Conceptos.Add(oConceptos);
                db.SaveChanges();
            }
        }

        public void Editar(Conceptos oConceptos)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Entry(oConceptos).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                Conceptos oConceptos = db.Conceptos.Find(id);
                db.Conceptos.Remove(oConceptos);
                db.SaveChanges();
            }
        }
    }
}
