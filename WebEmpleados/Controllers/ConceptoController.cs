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
    public class ConceptoController : ApiController
    {
        BusConcepto oBusConcepto = new BusConcepto();
        public List<Conceptos> Get()
        {
            return oBusConcepto.Obtener();
        }

        public Conceptos Get(int id)
        {
            return oBusConcepto.Obtener(id);
        }

        public void Post(Conceptos oConceptos)
        {
            oBusConcepto.Agregar(oConceptos);
        }

        public void Put(Conceptos oConceptos)
        {
            oBusConcepto.Editar(oConceptos);
        }

        public void Delete(int id)
        {
            oBusConcepto.Eliminar(id);
        }
    }
}
