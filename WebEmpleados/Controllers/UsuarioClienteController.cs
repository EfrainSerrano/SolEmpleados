using Business;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebEmpleados.Controllers
{
    public class UsuarioClienteController : Controller
    {
        
        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult Validar(string RFC, string Contrasena)
        {
            ProyectoFinalTI oUsuarios = new ProyectoFinalTI();
            try
            {
                using (HttpClient clienteHttp = new HttpClient())
                {
                    clienteHttp.BaseAddress = new Uri("https://localhost:44338"); //end point o servidor 
                    var request = clienteHttp.GetAsync("/api/Usuarios?RFC=" + RFC + "&" + "Contrasena=" + Contrasena).Result; //que se va a ejecutar (GET)

                    if (request.IsSuccessStatusCode)
                    {
                        string resultado = request.Content.ReadAsStringAsync().Result; //se guarda el Json con la lista en un string llamado resultado

                        oUsuarios = JsonConvert.DeserializeObject<ProyectoFinalTI>(resultado); //deserializando el Json en una lista de tipo peliculas

                        Session["usuario"] = oUsuarios;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        string error = request.Content.ReadAsStringAsync().Result;
                        TempData["error"] = error;
                        return View("Login");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Login");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProyectoFinalTI usu)
        {
            try
            {
                using (HttpClient clienteHttp = new HttpClient())
                {
                    clienteHttp.BaseAddress = new Uri("https://localhost:44338"); //end point o servidor 
                    var request = clienteHttp.PostAsJsonAsync("/api/Usuarios", usu).Result; //que se va a ejecutar (POST)

                    if (!request.IsSuccessStatusCode)
                    {
                        throw new Exception("Error al ejecutar el Rest API para agregar");
                    }

                    TempData["mensaje"] = $"Se agregó el un nuevo usuario con el RFC {usu.RFC}";
                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la petición Post del Rest Api. Llamar a sistemas" + ex.Message;
                return View();
            }
        }

        public ActionResult Cerrar()
        {
            Session["usuario"] = null;
            TempData["mensaje"] = "Se cerro la sesión correctamente";
            return RedirectToAction("Login", "UsuarioCliente");
        }
        

        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public ActionResult Agregar()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Agregar(ProyectoFinalTI usu)
        //{
        //    try
        //    {
        //        BusUsu.AgregarUsuario(usu);
        //        TempData["mensaje"] = "Se agrego el usuario";
        //        return RedirectToAction("Login", "Home");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["error"] = ex.Message;
        //        return View();
        //    }

        //}
        //public ActionResult ValidarIngreso(ProyectoFinalTI usu)
        //{
        //    try
        //    {
        //        ProyectoFinalTI us = BusUsu.ValidarIngresarUsuario(usu);
        //        Session["usuario"] = us;
        //        return RedirectToAction("Inico", "Empleados");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["error"] = ex.Message;
        //        return RedirectToAction("Login", "Home");
        //    }
        //}
    }
}