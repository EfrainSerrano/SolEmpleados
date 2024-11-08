using Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebEmpleados.Controllers
{
    public class NominaClienteController : Controller
    {
        // GET: NominaCliente
        public ActionResult Index()
        {
            List<Nomina> ls = new List<Nomina>();

            try
            {
                using (HttpClient clienteHttp = new HttpClient())
                {
                    clienteHttp.BaseAddress = new Uri("https://localhost:44338");
                    var request = clienteHttp.GetAsync("/api/nomina").Result;

                    if (request.IsSuccessStatusCode)
                    {
                        string resultado = request.Content.ReadAsStringAsync().Result;
                        ls = JsonConvert.DeserializeObject<List<Nomina>>(resultado);
                    }

                    return View(ls);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la solicitud GET del Rest Api" + ex.Message;
                return View(new List<Nomina>());
            }
        }
    }
}