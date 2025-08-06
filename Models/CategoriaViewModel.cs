namespace netdemo.Models;
using System.ComponentModel.DataAnnotations;
public class CategoriaViewModel
{
    public string CategoriaSeleccionada { get; set; }
    public List<string> Categorias { get; set; }
    public List<Pelicula> Peliculas { get; set; }
}
