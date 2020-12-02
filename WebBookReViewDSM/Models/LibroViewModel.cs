using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBookReViewDSM.Models
{
    public class LibroViewModel
    {
        [ScaffoldColumn(false)]
        public int libroID { get; set; } //la CP


        [Display(Prompt = "Autor del libro", Description = "Mas de lo mismo ", Name = "autor")] //display info que se muestra junto al campo de entrada
        [Required(ErrorMessage = "Debe incluir un autor para el libro")] //obligatorio y error
        [StringLength(maximumLength: 200, ErrorMessage = "Mucho texto")]
        public string autor { get; set; }


        [Display(Prompt = "Paginas del libro", Description = "Mas de lo mismo ", Name = "paginas")] 
        [Required(ErrorMessage = "Debe incluir un numero de pags para el libro")] 
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "paginas deben ser >0 ")]
        public int paginas { get; set; }

        [Display(Prompt = "Precio del libro", Description = "Mas de lo mismo ", Name = "precio")]
        [Required(ErrorMessage = "Debe incluir un precio para el libro")] 
        [DataType(DataType.Currency,ErrorMessage ="Debe ser un valor numerico")]
        [Range(minimum: 0, maximum: 1000, ErrorMessage = "Precio >0 y <1000 ")]
        public double precio { get; set; }


    }
}