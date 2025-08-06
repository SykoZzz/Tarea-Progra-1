using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using netdemo.Models;

public class HomeController : Controller
{
private static Dictionary<string, List<Pelicula>> baseDatos = new()
{
    { "Acción", new List<Pelicula>
        {
            new Pelicula { Titulo = "John Wick", Director = "Chad Stahelski", Categoria = "Acción" },
            new Pelicula { Titulo = "Mad Max: Fury Road", Director = "George Miller", Categoria = "Acción" },
            new Pelicula { Titulo = "Gladiator", Director = "Ridley Scott", Categoria = "Acción" },
            new Pelicula { Titulo = "Die Hard", Director = "John McTiernan", Categoria = "Acción" }
        }
    },
    { "Comedia", new List<Pelicula>
        {
            new Pelicula { Titulo = "The Mask", Director = "Chuck Russell", Categoria = "Comedia" },
            new Pelicula { Titulo = "Superbad", Director = "Greg Mottola", Categoria = "Comedia" },
            new Pelicula { Titulo = "Step Brothers", Director = "Adam McKay", Categoria = "Comedia" },
            new Pelicula { Titulo = "The Hangover", Director = "Todd Phillips", Categoria = "Comedia" }
        }
    },
    { "Drama", new List<Pelicula>
        {
            new Pelicula { Titulo = "The Shawshank Redemption", Director = "Frank Darabont", Categoria = "Drama" },
            new Pelicula { Titulo = "Forrest Gump", Director = "Robert Zemeckis", Categoria = "Drama" },
            new Pelicula { Titulo = "The Godfather", Director = "Francis Ford Coppola", Categoria = "Drama" },
            new Pelicula { Titulo = "Fight Club", Director = "David Fincher", Categoria = "Drama" }
        }
    }
};

    public IActionResult Index(string categoria = null)
    {
        var model = new CategoriaViewModel
        {
            Categorias = baseDatos.Keys.ToList(),
            CategoriaSeleccionada = categoria,
            Peliculas = categoria != null && baseDatos.ContainsKey(categoria)
                ? baseDatos[categoria]
                : new List<Pelicula>()
        };
        return View(model);
    }

    public IActionResult Agregar()
    {
        return View(new Pelicula());
    }

    [HttpPost]
    public IActionResult Agregar(Pelicula peli)
    {
        if (string.IsNullOrWhiteSpace(peli.Titulo) || string.IsNullOrWhiteSpace(peli.Director) || string.IsNullOrWhiteSpace(peli.Categoria))
        {
            ViewBag.Mensaje = "Por favor, complete todos los campos.";
            return View(peli);
        }

        // Aquí podrías guardar en base de datos real
        return RedirectToAction("Gracias");
    }

    public IActionResult Gracias()
    {
        return View();
    }
}