using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusUsuario
    {
        DatUsuario datUsu = new DatUsuario();

        public ProyectoFinalTI ValidarIngresarUsuario(string RFC, string Contrasena)
        {
            ProyectoFinalTI us = datUsu.ValidarIngresarUsuario(RFC, Contrasena);
            if (us == null)
                throw new Exception("Usuario y/o contraseña son incorrectos");
            return us;
        }
        public void AgregarUsuario(ProyectoFinalTI usu)
        {
            datUsu.AgregarUsuario(usu);
        }
    }
}
