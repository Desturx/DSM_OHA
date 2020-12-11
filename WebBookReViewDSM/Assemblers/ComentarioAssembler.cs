using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReViewGenNHibernate.EN.BookReview;
using WebBookReViewDSM.Models;

namespace WebBookReViewDSM.Assemblers
{
    public class ComentarioAssembler
    {
        public ComentarioViewModel ConvertEnToModelUI(ComentarioEN en)
        {
            ComentarioViewModel com = new ComentarioViewModel();
            com.comentario = en.Comentario;
            com.fecha = (DateTime)en.Fecha;
            com.titulo = en.Titulo;
            com.contenido = en.Contenido;
            com.paginasLeidas = en.PaginasLeidas;

            return com;
        }


        public IList<ComentarioViewModel> ConvertListENToModel(IList<ComentarioEN> ens)
        {
            IList<ComentarioViewModel> coms = new List<ComentarioViewModel>();
            foreach (ComentarioEN cp in ens)
            {
                coms.Add(ConvertEnToModelUI(cp));
            }

            return coms;
        }
    }
}
