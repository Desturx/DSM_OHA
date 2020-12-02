using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReViewGenNHibernate.EN.BookReview;
using WebBookReViewDSM.Models;

namespace WebBookReViewDSM.Assemblers
{
    public class LibroAssembler
    {

        public LibroViewModel ConvertENToModelUI(LibroEN en) { //individual

            LibroViewModel lib = new LibroViewModel();
            lib.libroID = en.LibroID; //de aqui se va al viewmodel y pues saca las cosas que se le pidan con las instrucciones
            lib.autor = en.Autor;
            lib.paginas = en.Paginas;
            lib.precio = en.Precio;

            return lib;
        }

        public IList<LibroViewModel> ConvertListENToModel(IList<LibroEN> ens) {

            IList<LibroViewModel> libros = new List<LibroViewModel>();
            foreach (LibroEN en in ens) {
                libros.Add(ConvertENToModelUI(en));
            
            }
            return libros;
        }
    }
}