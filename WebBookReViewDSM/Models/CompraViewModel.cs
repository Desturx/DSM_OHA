using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBookReViewDSM.Models
{
    public class CompraViewModel
    {
        [ScaffoldColumn(false)]
        public int CompraId { get; set; }

        [Display(Prompt  ="Tipo de pago", Description="Forma de pago de la compra", Name="Tipo pago")]
        [Required(ErrorMessage ="Debe indicar un tipo de pago")]
        [StringLength(maximumLength: 200, ErrorMessage ="El tipo de pago es muy largo")]
        public string Tipo_pago { get; set; }

        [Display(Prompt = "Fecha", Description = "Fecha de la compra", Name = "Fecha")]
        [Required(ErrorMessage = "Debe indicar un comercio")]
        public DateTime Fecha { get; set; }

        [Display(Prompt = "Comercio", Description = "Plataforma sobre la que se ha comprado", Name = "Comercio")]
        [Required(ErrorMessage = "Debe indicar un comercio")]
        public string Comercio { get; set; }

    }
}