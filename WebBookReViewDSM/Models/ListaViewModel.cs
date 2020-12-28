using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using BookReViewGenNHibernate.Enumerated.BookReview;

namespace WebBookReViewDSM.Models
{
    public class ListaViewModel
    {
        [ScaffoldColumn(false)]
        public TipolistaEnum Tipolista { get; set; }
        public int id { get; set; }

        //[Display(Prompt = "Tipo de lista", Description = "Estado actual de la lista", Name = "Tipo lista")]
        //public string listaEstado { get; set; }

        [Display(Prompt = "Dueño de la lista", Description = "Creador de la lista", Name = "Identificador lista")]
        public int duenyoLista { get; set; }

        [Display(Prompt = "Nombre dueño de la lista", Description = "Creador de la lista", Name = "Creador de la lista")]
        public string nombreduenyo { get; set; }


    }
}