
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


/*PROTECTED REGION ID(usingBookReViewGenNHibernate.CEN.BookReview_Libro_puntuarLibro) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace BookReViewGenNHibernate.CEN.BookReview
{
public partial class LibroCEN
{
public void PuntuarLibro (int p_oid, int p_puntos)
{
        /*PROTECTED REGION ID(BookReViewGenNHibernate.CEN.BookReview_Libro_puntuarLibro) ENABLED START*/

        LibroEN en = _ILibroCAD.ReadOIDDefault (p_oid);

        en.Puntuacion += p_puntos;

        _ILibroCAD.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
