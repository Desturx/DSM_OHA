
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using BookReViewGenNHibernate.Exceptions;
using BookReViewGenNHibernate.EN.BookReview;
using BookReViewGenNHibernate.CAD.BookReview;


/*PROTECTED REGION ID(usingBookReViewGenNHibernate.CEN.BookReview_Comentario_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace BookReViewGenNHibernate.CEN.BookReview
{
public partial class ComentarioCEN
{
public int New_ (string p_titulo, string p_contenido, int p_lectura, int p_comentador, int p_paginasLeidas)
{
        /*PROTECTED REGION ID(BookReViewGenNHibernate.CEN.BookReview_Comentario_new__customized) START*/

        ComentarioEN comentarioEN = null;

        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Titulo = p_titulo;

        comentarioEN.Contenido = p_contenido;


        if (p_lectura != -1) {
                comentarioEN.Lectura = new BookReViewGenNHibernate.EN.BookReview.LibroEN ();
                comentarioEN.Lectura.LibroID = p_lectura;
        }


        if (p_comentador != -1) {
                comentarioEN.Comentador = new BookReViewGenNHibernate.EN.BookReview.UsuarioEN ();
                comentarioEN.Comentador.UsuarioID = p_comentador;
        }

        comentarioEN.PaginasLeidas = p_paginasLeidas;

        //Call to ComentarioCAD

        oid = _IComentarioCAD.New_ (comentarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
