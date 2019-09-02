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
            escuela.AñoFundacion = 2005;
            escuela.EscuelaId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi school";
            return View(escuela);
        }
    }
}