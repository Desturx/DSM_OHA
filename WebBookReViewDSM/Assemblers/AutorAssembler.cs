using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReViewGenNHibernate.EN.BookReview;
using WebBookReViewDSM.Models;

namespace WebBookReViewDSM.Assemblers
{
    public class AutorAssembler
    {
        public AutorViewModel ConvertEnToModelUI(AutorEN en)
        {
            AutorViewModel aut = new AutorViewModel();
            aut.autorID = en.AutorID;
            aut.nombre = en.Nombre;
            aut.numlibros = en.NumLibros;
            aut.nacimiento = (DateTime)en.Nacimiento;
            aut.fotoautor = en.Fotoautor;
            return aut;
        }

        public IList<AutorViewModel> ConvertListENToModel(IList<AutorEN> ens)
        {
            IList<AutorViewModel> auts = new List<AutorViewModel>();
            foreach (AutorEN cp in ens)
            {
                auts.Add(ConvertEnToModelUI(cp));
            }

            return auts;
        }
    }
}