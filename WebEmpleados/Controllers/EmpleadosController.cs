using Business;
using Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebEmpleados.Controllers
{
    public class EmpleadosController : ApiController
    {
        BusEmpleados oBusEmpleados = new BusEmpleados();
        public List<Empleados> Get(int idUsuario, string nombre)
        {
            return oBusEmpleados.Obtener(idUsuario);
        }

        public Empleados Get(int idEmpleado)
        {
            return oBusEmpleados.ObtenerPorId(idEmpleado);
        }

        public void Post(Empleados oEmpleados)
        {
            //string rutaArchivo = Path.Combine(HttpContext.Current.Server.MapPath("~/Imgs"), ArchivoImagen.FileName);
            oBusEmpleados.Agregar(oEmpleados);
        }

        public void Put(Empleados oEmpleados)
        {
            oBusEmpleados.Editar(oEmpleados);
        }

        public void Delete(int idEmpleado)
        {
            oBusEmpleados.Eliminar(idEmpleado);
        }
    }
}
