using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DatEmpleados
    {
        public List<Empleados> Obtener(int idUsuario)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<Empleados> ls = db.Empleados.Include("ProyectoFinalTI")
                .Where(x => x.IDUsuario == idUsuario)
                .OrderBy(x => x.Nombre)
                .ToList();

                return ls;
            }
        }

        public Empleados ObtenerPorId(int idEmpleado)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                return db.Empleados.Include("ProyectoFinalTI")
                       .Where(x => x.IDEmpleado == idEmpleado)
                       .FirstOrDefault();
            }
        }

        public void agregar(Empleados oEmpleado)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Empleados.Add(oEmpleado);
                db.SaveChanges();
            }
        }

        public void Editar(Empleados oEmpleado)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Entry(oEmpleado).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                Empleados oEmpleado = db.Empleados.Find(id);
                db.Empleados.Remove(oEmpleado);
                db.SaveChanges();
            }
        }
    }
}
