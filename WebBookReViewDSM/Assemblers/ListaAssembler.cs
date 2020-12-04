using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReViewGenNHibernate.En.BookReView;
using WebBookReViewDSM.models;

namespace WebBookReViewDSM.Assemblers
{
    public class ListaAssembler
    {
        public ListaViewModel ConvertEnToModelUI(ListaEn en)
        {
            ListaViewModel lista = new ListaViewModel();
            lista.id = en.id;
            compra.Tipolista = en.tipo;

            return lista;
        }

        public IList<ListaViewModel> ConvertListENToModel(IList<ListaEN> ens)
        {
            IList<ListaViewModel> listas = new List<ListaViewModel>();
            foreach (ListaEN cp in ens)
            {
                listas.Add(ConvertEnToModelUI(cp));
            }

            return listas;
        }
    }
}