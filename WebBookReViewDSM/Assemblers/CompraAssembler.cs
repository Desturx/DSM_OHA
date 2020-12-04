using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReViewGenNHibernate.En.BookReView;
using WebBookReViewDSM.models;


namespace WebBookReViewDSM.Assemblers
{
    public class CompraAssembler
    {
        public CompraViewModel ConvertEnToModelUI(CompraEn en)
        {
            CompraViewModel compra = new CompraViewModel();
            compra.CompraID = en.CompraID;
            compra.Fecha = en.Fechaped;
            compra.Comercio = en.Comercio;
            compra.Tipo_pago = en.Tipo_pago;

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