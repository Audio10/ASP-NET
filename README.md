# ASP.net

## **Para trabajar con ASP.**

Necesitamos instalar **.Net core** que es una plataforma de .NET para crear websites, servicios y aplicaciones de consola.

En este caso se va a trabajar con **htttps** por lo cual necesitamos activar el certificado de la plataforma .Net con el siguiente comando.

```c#
dotnet dev-certs https--trust
```

Net core tiene un amplio pool de aplicaciones que puedes crear, pero en este caso vamos a desarrollar una con modelo MVC.

Por lo cual ejecutamos para crear esta aplicación con el comando.

```c#
dotnet new mvc
```

------

## **Estructura de patrón MVC**

### vscode 

Que contiene los archivos de configuración de visual studio code.

### bin

 Donde están todos los binarios que se generan cuando compilamos la solución.

### obj

 Carpeta de transición que se genera en el proceso de compilación.

### wwwroot 

Que contiene:

- **Css**
- **imágenes**
- **Js**
- **lib** (Librerías de terceros.)

### Controllers 

En esta carpeta se encuentra el *BackEnd* de la solución este responde request teniendo en cuenta la ruta y el método Http.

**Acciones**

Cada acción dentro de un *controlador* es creada para responder *requests* este puede realizar acciones intermedias como hacer cálculos, consultar una base de datos, etc.

Las acciones tienen una firma característica, devuelven un *IActionResult*. Y una vez que hace lo que tiene que hacer llama a la vista.

### Views 

Cada una de las acciones del *controlador* esta asociada a una de las vistas.

En esta carpeta se encuentran las vistas que se van a renderizar con unas plantillas preinstaladas. 

### Model

Este sirve para definir la estructura de los datos mediante **POCO**.

Los **POCO** son entidades simples que definen el modelo y se usan para persistir

------

## **Razor Syntax (Cuchilla)**

Surge como la necesidad que tenían los desarrolladores de poder escribir un código familiar de manera rápida dentro del código html. Porque si vamos a combinar el html con la información con la que nos pasa el modelo vamos a tener que realizar algunas operaciones en el backend.

Es básicamente que lo que programas en C# lo puedes meter en la vista, para que utilizando el código que se crea cuando ejecutas la vista.

Todo lo que este inmerso antes de una **@** es código Razor, por ejemplo.

```c#
@{
    ViewData["Title"] = "Informacion Escuela";
}
```

### Convenciones.

Dentro de las convenciones de Razor esta que todo objeto que es enviado como parámetro responde a **@Model.**

------

## **Generar de EndPoint con MVC.**

Para generar una vista necesitas crear una carpeta que coincida con el nombre del controlador. Por ejemplo si la carpeta de vista se llama **Escuela** el controlador se debe llamar **EscuelaController.cs** , esta clase debe heredar de controller que es una clase con soporte para MVC.

**Models/Escuela.cs**

El modelo es simplemente un POCO.

```
namespace ASP_NET.Models
{
    public class Escuela
    {
        public string EscuelaId {get; set;}
        public string Nombre {get; set;}
        public int AñoFundacion {get; set;}
    }
}
```

 **Controllers/EscuelaController.cs**

Cuando quieres enviar un modelo desde el controller en el endpoint creas una variable del modelo y la envías por parámetro a la View.

```c#
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
            // Envia el modelo como parametro a la vista.
            return View(escuela);
        }
    }
}
```

**Views/Escuela/Index.cshtml**

La forma mas fácil de ingresar a los datos enviados desde el controller es con la anotación **@Model.ATRIBUTO**

**Razor** es un **Model débilmente tipado** por lo cual se debe especificar el modelo que recibe en la sección de arriba de la vista. 

```c#
@model Escuela
// METADATOS
@{
    ViewData["Title"] = "Informacion Escuela";
}

<h1>Escuela</h1>
<h2>Nombre: @Model.Nombre </h2>
<p> <strong> Año fundacion: @Model.AñoFundacion</strong> </p>
```

### Modificar Ruta de inicio.

La ruta principal que se abrirá al iniciar el app se puede cambiar en el archivo **Startup.cs.**

```c#
app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Escuela}/{action=Index}/{id?}");
            });
```

------

