using Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace WebEmpleados.Controllers
{
    public class ConceptoClienteController : Controller
    {
        // GET: ConceptoCliente
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
            {
                TempData["error"] = "No se puede acceder al recurso solicitado";
                return RedirectToAction("Login", "UsuarioCliente");
            }

            List<Conceptos> ls = new List<Conceptos>();

            try
            {
                using (HttpClient clienteHttp = new HttpClient())
                {
                    clienteHttp.BaseAddress = new Uri("https://localhost:44338");
                    var request = clienteHttp.GetAsync("/api/concepto").Result;

                    if (request.IsSuccessStatusCode)
                    {
                        string resultado = request.Content.ReadAsStringAsync().Result;
                        ls = JsonConvert.DeserializeObject<List<Conceptos>>(resultado);
                    }
                    return View(ls);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la peticion GET solicitada para el Rest Api" + ex.Message;
                return RedirectToAction("Index", "UsuariosCliente");
            }
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}