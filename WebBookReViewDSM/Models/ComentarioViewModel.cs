using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

using BookReViewGenNHibernate.CEN.BookReview;

namespace WebBookReViewDSM.Models
{
    public class ComentarioViewModel
    {
        [ScaffoldColumn(false)]
        public int comentario { get; set; } //la CP


        [Display(Prompt = "Titulo coment", Description = "Mas de lo mismo ", Name = "titulo")] //display info que se muestra junto al campo de entrada
        [Required(ErrorMessage = "Debe incluir un titulo")] //obligatorio y error
        [StringLength(maximumLength: 20, ErrorMessage = "Mucho texto")]
        public string titulo { get; set; }

        [Display(Prompt = "Mensaje del coment", Description = "Mas de lo mismo ", Name = "comentario")] //display info que se muestra junto al campo de entrada
        [Required(ErrorMessage = "Debe incluir un titulo")] //obligatorio y error
        [StringLength(maximumLength: 400, ErrorMessage = "Mucho texto")]
        public string contenido { get; set; }
        public DateTime fecha { get; set; }


        [Display(Prompt = "Pagina por la que va", Description = "Mas de lo mismo ", Name = "paginasLeidas")]
        [Required(ErrorMessage = "Debe incluir un numero de pags para el libro")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "paginas deben ser >0 ")]
        public int paginasLeidas { get; set; }
        public int comentador { get; set; }
        public int lectura { get; set; }
        [Display(Prompt = "Comentador", Description = "Mas de lo mismo ", Name = "comentador")]
        [Required(ErrorMessage = "Debe incluir un comentador")]
        public string comentadorname { get; set; }
        [Display(Prompt = "Lectura", Description = "Mas de lo mismo ", Name = "lectura")]
        [Required(ErrorMessage = "Debe incluir un comentador")]
        public string lecturatitulo { get; set; }
    }
}