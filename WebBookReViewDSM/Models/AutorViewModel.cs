using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebBookReViewDSM.Models
{
    public class AutorViewModel
    {
        [ScaffoldColumn(false)]
        public int autorID { get; set; }

        [Display(Prompt = "Nombre del autor", Description = "Nombre del autor", Name = "Nombre del autor")]
        public string nombre { get; set; }

        [Display(Prompt = "Libros escritos", Description = "Libros escritos del autor", Name = "Libros que ha escrito el autor")]
        public int numlibros { get; set; }

        [DataType(DataType.Date, ErrorMessage = "seleccione una fecha")]
        public DateTime nacimiento { get; set; }

        [Display(Prompt = "Foto del autor", Description = "Foto del autor", Name = "Foto del autor")]
        public string fotoautor { get; set; }
    }
}