using Business;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebEmpleados.Controllers
{
    public class UsuariosController : ApiController
    {
        BusUsuario BusUsu = new BusUsuario();

        public IHttpActionResult Get(string RFC, string Contrasena)
        {
            try
            {
                ProyectoFinalTI usu = BusUsu.ValidarIngresarUsuario(RFC, Contrasena);
                return Ok(usu);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }

        public void Post(ProyectoFinalTI oUsuario)
        {
            BusUsu.AgregarUsuario(oUsuario);
        }
    }
}
