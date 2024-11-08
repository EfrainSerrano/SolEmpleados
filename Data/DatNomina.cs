using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DatNomina
    {
        public List<Nomina> Obtener()
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<Nomina> ls = db.Nomina.Include("Empleados").Include("Conceptos").OrderByDescending(x => x.FechaPago).ToList();
                return ls;
            }
        }

        public Nomina Obtener(int id)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                return db.Nomina.Include("Empleados").Include("Conceptos")
                .Where(x=> x.IDNomina == id).FirstOrDefault();
            }
        }

        public List<Nomina> ObtenerNominasEmpleado(int idEmpleado)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                return db.Nomina.Include("Empleados").Include("Conceptos")
                .Where(x => x.Empleados.IDEmpleado == idEmpleado)
                .OrderByDescending(x=> x.FechaPago)
                .ToList();
            }
        }

        public void Agregar(Nomina oNomina)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Nomina.Add(oNomina);
                db.SaveChanges();
            }
        }

        public void Editar(Nomina oNomina)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Entry(oNomina).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                Nomina oNomina = db.Nomina.Find(id);
                db.Nomina.Remove(oNomina);
                db.SaveChanges();
            }
        }
    }
}
