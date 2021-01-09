using BookReViewGenNHibernate.EN.BookReview;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBookReViewDSM.Models
{
    public class UsuarioViewModel
    {
        [ScaffoldColumn(false)]

        public int usuarioID { get; set; } // Clave primaria del usuario


        [ScaffoldColumn(false)]

        public IList<LibroEN> libros { get; set; } // Clave primaria del usuario


        [Display(Prompt = "Usuario", Description = "Este es un usuario", Name = "nombre")] // informacion del campo
        [Required(ErrorMessage = "Debe añadir un usuario")] // Es obligatorio y da un error
        [StringLength(maximumLength: 20, ErrorMessage = "El usuario contiene muchos caracteres")] // longitud maxima del campo

        public String nombre { get; set; }

       
        [Display(Prompt = "mail", Description = "Este es el correo del usuario", Name = "mail")]
        [Required(ErrorMessage = "Debe introducir un correo válido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El correo debe tener más de 10 caracteres")]

        public String mail { get; set; }

        [Display(Prompt = "contraseña", Description = "Esta es la contraseña del usuario", Name = "password")]
        [Required(ErrorMessage = "Debe introducir la contraseña")]
        [StringLength(maximumLength: 20, ErrorMessage = "La contraseña no tiene caracteres o es demasiado larga")]

        public String password { get; set; }

        [Display(Prompt = "foto perfil", Description = "Foto del perfil del usuario", Name = "fotoperfil")]
        [Required(ErrorMessage = "La ruta de la foto es incorrecta")]

        public String fotoperfil { get; set; }

        [Display(Prompt = "dinero", Description = "Dinero que tiene el usuario", Name = "dineroventa")]
        [Required(ErrorMessage = "No tiene dinero")]

        public Double dineroventa { get; set; }




    }
}