using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebBookReViewDSM.Models
{
    public class ListaViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Tipo de lista", Description = "Estado actual de la lista", Name = "Tipo lista")]
        public string Tipolista { get; set; }
    }
}