using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReViewGenNHibernate.EN.BookReview;
using WebBookReViewDSM.Models;

namespace WebBookReViewDSM.Assemblers
{
    public class CompraAssembler
    {
        public CompraViewModel ConvertEnToModelUI(CompraEN en)
        {
            CompraViewModel compra = new CompraViewModel();
            compra.CompraId = en.CompraID;
            compra.tipo_pago = en.Tipo_pago;
            compra.infoTarjeta = en.Infotarjeta;
            compra.fecha = (DateTime)en.Fechaped;
            compra.terminal = en.Terminal;
            compra.comercio = en.Comercio;
            compra.LibroId = en.Solicitante.LibroID;
            compra.nomLib = en.Solicitante.Nombre;
            compra.precLib = en.Solicitante.Precio;
            compra.compradorId = en.Comprador.UsuarioID;
            return compra;
        }


        public IList<CompraViewModel> ConvertListENToModel(IList<CompraEN> ens)
        {
            IList<CompraViewModel> compras = new List<CompraViewModel>();
            foreach (CompraEN cp in ens)
            {
                compras.Add(ConvertEnToModelUI(cp));
            }

            return compras;
        }
    }
}