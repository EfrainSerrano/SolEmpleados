using Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebEmpleados.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int page = 1, int pageSize = 7)
        {
            if (Session["usuario"] == null)
            {
                TempData["error"] = "No se puede acceder al recurso solicitado";
                return RedirectToAction("Login", "UsuarioCliente");
            }
            List<Empleados> ls = new List<Empleados>();
            ProyectoFinalTI usu = (ProyectoFinalTI)Session["usuario"];
            try
            {

                using (HttpClient clienteHttp = new HttpClient())
                {
                    clienteHttp.BaseAddress = new Uri("https://localhost:44338"); //end point o servidor 
                    var request = clienteHttp.GetAsync("/api/Empleados?idUsuario=" + usu.IDUsuario + "&" + "nombre=" + usu.Nombre).Result; //que se va a ejecutar (GET)

                    if (request.IsSuccessStatusCode)
                    {
                        string resultado = request.Content.ReadAsStringAsync().Result; //se guarda el Json con la lista en un string llamado resultado

                        ls = JsonConvert.DeserializeObject<List<Empleados>>(resultado); //deserializando el Json en una lista de tipo peliculas
                    }

                    int totalItems = ls.Count;
                    var paginatedEmpleados = ls.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                    ViewBag.TotalItems = totalItems;
                    ViewBag.PageSize = pageSize;
                    ViewBag.CurrentPage = page;

                    return View(paginatedEmpleados);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Create()
        {
            if (Session["usuario"] == null)
            {
                TempData["error"] = "No se puede acceder al recurso solicitado";
                return RedirectToAction("Login", "UsuarioCliente");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Create(Empleados oEmpleados, HttpPostedFileBase foto)
        {
            try
            {
                string rutaArchivo = Path.Combine(Server.MapPath("~/Img"), foto.FileName);
                foto.SaveAs(rutaArchivo);
                oEmpleados.Foto = foto.FileName;

                using (HttpClient clienteHttp = new HttpClient())
                {
                    clienteHttp.BaseAddress = new Uri("https://localhost:44338");
                    var request = clienteHttp.PostAsJsonAsync("/api/Empleados", oEmpleados).Result;

                    if (!request.IsSuccessStatusCode)
                    {
                        throw new Exception("Error al ejecutar el Rest API para agregar");
                    }
                    TempData["mensaje"] = $"Se registro al empleado {oEmpleados.Nombre}";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la petición Post del Rest Api. Llamar a sistemas" + ex.Message;
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            if (Session["usuario"] == null)
            {
                TempData["error"] = "No se puede acceder al recurso solicitado";
                return RedirectToAction("Login", "UsuarioCliente");
            }

            Empleados oEmpleado = new Empleados();
            try
            {
                using (HttpClient clienteHttp = new HttpClient())
                {
                    clienteHttp.BaseAddress = new Uri("https://localhost:44338");
                    var request = clienteHttp.GetAsync("/api/Empleados?IDEmpleado=" + id).Result;

                    if (request.IsSuccessStatusCode)
                    {
                        string resultado = request.Content.ReadAsStringAsync().Result;
                        oEmpleado = JsonConvert.DeserializeObject<Empleados>(resultado);
                    }
                    return View(oEmpleado);
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la petición GET del Rest Api. Llamar a sistemas" + ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Edit(Empleados oEmpleados)
        {
            try
            {
                using (HttpClient clienteHttp = new HttpClient())
                {
                    clienteHttp.BaseAddress = new Uri("https://localhost:44338");
                    var request = clienteHttp.PutAsJsonAsync("/api/Empleados", oEmpleados).Result;

                    if (!request.IsSuccessStatusCode)
                    {
                        throw new Exception("Error al ejecutar el Rest API para editar");
                    }
                    TempData["mensaje"] = "El registro se editó correctamente";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la petición PUT del Rest Api. Llamar a sistemas" + ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Delete(int id)
        {
            if (Session["usuario"] == null)
            {
                TempData["error"] = "No se puede acceder al recurso solicitado";
                return RedirectToAction("Login", "UsuarioCliente");
            }

            Empleados oEmpleado = new Empleados();
            try
            {
                using (HttpClient clienteHttp = new HttpClient())
                {
                    clienteHttp.BaseAddress = new Uri("https://localhost:44338");
                    var request = clienteHttp.GetAsync("/api/Empleados?IDEmpleado=" + id).Result;

                    if (request.IsSuccessStatusCode)
                    {
                        string resultado = request.Content.ReadAsStringAsync().Result;
                        oEmpleado = JsonConvert.DeserializeObject<Empleados>(resultado);
                    }
                    return View(oEmpleado);
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la petición GET del Rest Api. Llamar a sistemas" + ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Delete(Empleados oEmpleados)
        {
            try
            {
                using (HttpClient clienteHttp = new HttpClient())
                {
                    clienteHttp.BaseAddress = new Uri("https://localhost:44338");
                    var request = clienteHttp.DeleteAsync("/api/Empleados/?IDEmpleado=" + oEmpleados.IDEmpleado).Result;

                    if (!request.IsSuccessStatusCode)
                    {
                        throw new Exception("Error al cargar la peticion Rest Api para eliminar");
                    }

                    TempData["Mensaje"] = $"Se eliminó al empleado {oEmpleados.Nombre}";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la peticion Delete del Rest Api" + ex.Message;
                return View();
            }
        }
    }
}