using System;
using ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi school";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Avenida Siempre Viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;      

            ViewBag.CosaDinamica = "La monja";

            return View(escuela);
        }
    }
}