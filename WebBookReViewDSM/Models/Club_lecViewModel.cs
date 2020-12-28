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

        //[Display(Prompt = "Fecha de las reuniones", Description = "Reuniones del club de lectura", Name = "Fecha de las reuniones del club")]
        [DataType(DataType.Date, ErrorMessage = "seleccione una fecha")]
        public DateTime mensualidad { get; set; }

        [Display(Prompt = "Página actual", Description = "Página actual", Name = "Página actual")]
        public int paginaActual { get; set; }

        [Display(Prompt = "Estado club de lectura", Description = "Estado actual del club de lectura", Name = "Estado club lectura")]
        public bool estado { get; set; }

        [Display(Prompt = "Libro del club de lectura", Description = "Libro actual del club de lectura", Name = "ID Libro club lectura")]
        public int lectura { get; set; }

        [Display(Prompt = "Libro del club de lectura", Description = "Libro actual del club de lectura", Name = "Nombre libro club lectura")]
        public string nombrelibro { get; set; }
    }
}