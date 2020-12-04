using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReViewGenNHibernate.EN.BookReview;
using WebBookReViewDSM.Models;

namespace WebBookReViewDSM.Assemblers
{
    public class ListaAssembler
    {
        public ListaViewModel ConvertENToModelUI(ListaEN en)
        {
            ListaViewModel lista = new ListaViewModel();
           // lista.id = en.id;
            //lista.Tipolista = en.tipo;

            return lista;
        }

        public IList<ListaViewModel> ConvertListENToModel(IList<ListaEN> ens)
        {
            IList<ListaViewModel> listas = new List<ListaViewModel>();
            foreach (ListaEN cp in ens)
            {
                //listas.Add(ConvertEnToModelUI(cp));
            }

            return listas;
        }
    }
}