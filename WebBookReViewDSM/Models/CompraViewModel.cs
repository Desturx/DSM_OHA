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

        [ScaffoldColumn(false)]
        public int compradorId { get; set; }

        [ScaffoldColumn(false)]
        public int LibroId { get; set; }

        [ScaffoldColumn(false)]
        public string nomLib { get; set; }

        [ScaffoldColumn(false)]
        public double precLib { get; set; }

        [Display(Prompt  ="Tipo de pago", Description="Forma de pago de la compra", Name="Tipo pago")]
        [Required(ErrorMessage ="Debe indicar un tipo de pago")]
        [StringLength(maximumLength: 200, ErrorMessage ="El tipo de pago es muy largo")]
        public string tipo_pago { get; set; }

        [Display(Prompt="Información tarjeta", Description="Información de la tarjeta", Name ="Tarjeta")]
        [Required(ErrorMessage="Debe indicar una tarjeta")]
        public string infoTarjeta { get; set; }


        [Display(Prompt = "Fecha", Description = "Fecha de la compra", Name = "Fecha")]
        [Required(ErrorMessage = "Debe indicar un comercio")]
        [DataType(DataType.Date, ErrorMessage = "seleccione una fecha")]
        public DateTime fecha { get; set; }

        [Display(Prompt = "Terminal de pago", Description = "Terminal desde el que se realizó el pago", Name = "Terminal")]
        [Required(ErrorMessage = "Debe indicar una tarjeta")]
        public string terminal { get; set; }

        [Display(Prompt = "Comercio", Description = "Plataforma sobre la que se ha comprado", Name = "Comercio")]
        [Required(ErrorMessage = "Debe indicar un comercio")]
        public string comercio { get; set; }

        

    }
}