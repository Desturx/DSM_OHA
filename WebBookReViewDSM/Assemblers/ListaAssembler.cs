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
                    
            lista.id = en.Id;
            // fav 1, pendiente 2, acabado 3
            lista.Tipolista = en.Tipo;
            
            lista.duenyoLista = en.DuenyoLista.UsuarioID;
            lista.nombreduenyo = en.DuenyoLista.Nombre;
            return lista;
        }

        public IList<ListaViewModel> ConvertListENToModel(IList<ListaEN> ens)
        {
            IList<ListaViewModel> listas = new List<ListaViewModel>();
            foreach (ListaEN cp in ens)
            {
                listas.Add(ConvertENToModelUI(cp));
            }

            return listas;
        }
    }
}