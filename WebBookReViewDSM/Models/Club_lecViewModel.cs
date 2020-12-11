using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebBookReViewDSM.Models
{
    public class Club_lecViewModel
    {

        [ScaffoldColumn(false)]
        public int clubID { get; set; }

        [Display(Prompt = "Tipo de mensualidad", Description = "Mensualidad del club de lectura", Name = "Tipo mensualidad")]
        [Required(ErrorMessage = "Debe indicar un tipo de pago")]
        [StringLength(maximumLength: 200, ErrorMessage = "El tipo de pago es muy largo")]
        public DateTime mensualidad { get; set; }

        [Display(Prompt = "Página club de lectura", Description = "Página actual del club de lectura", Name = "Página club lectura")]
        public int paginaActual { get; set; }

        [Display(Prompt = "Estado club de lectura", Description = "Estado actual del club de lectura", Name = "Estado club lectura")]
        public bool estado { get; set; }

        [Display(Prompt = "Libro del club de lectura", Description = "Libro actual del club de lectura", Name = "Libro club lectura")]
        public int lectura { get; set; }
    }
}