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
    public class NominaController : ApiController
    {
        BusNomina oBusNomina = new BusNomina();
        [HttpGet]
        public List<Nomina> Get()
        {
            return oBusNomina.Obtener();
        }

        [HttpGet]
        [Route("NominaCliente")]
        public List<Nomina> Get(int idEmpleado)
        {
            return oBusNomina.ObtenerNominasEmpleado(idEmpleado);
        }
        [HttpGet]
        public Nomina GetNomina(int idNomina)
        {
            return oBusNomina.Obtener(idNomina);
        }

        [HttpPost]
        public void Post(Nomina oNomina)
        {
            oBusNomina.Agregar(oNomina);
        }

        [HttpPut]
        public void Put(Nomina oNomina)
        {
            oBusNomina.Editar(oNomina);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            oBusNomina.Eliminar(id);
        }
    }
}
