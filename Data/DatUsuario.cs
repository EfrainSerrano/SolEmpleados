using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DatUsuario
    {
        public void AgregarUsuario(ProyectoFinalTI usu)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.ProyectoFinalTI.Add(usu);
                db.SaveChanges();
            }
        }
        public ProyectoFinalTI ValidarIngresarUsuario(string RFC, string Contrasena)
        {
            using (Generación29Entities db = new Generación29Entities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                ProyectoFinalTI us = db.ProyectoFinalTI
                .Where(x => x.RFC == RFC && x.Contrasena == Contrasena)
                .FirstOrDefault();
                return us;

            }
        }
    }
}

