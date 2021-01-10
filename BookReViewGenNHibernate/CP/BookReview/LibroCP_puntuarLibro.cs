
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using BookReViewGenNHibernate.EN.BookReview;
using BookReViewGenNHibernate.CAD.BookReview;
using BookReViewGenNHibernate.CEN.BookReview;



/*PROTECTED REGION ID(usingBookReViewGenNHibernate.CP.BookReview_Libro_puntuarLibro) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace BookReViewGenNHibernate.CP.BookReview
{
public partial class LibroCP : BasicCP
{
public void PuntuarLibro (int p_Libro_OID, string p_nombre, string p_genero, Nullable<DateTime> p_fechapubli, string p_idioma, string p_portada, double p_puntuacion, string p_enlacedecompra, int p_paginas, double p_precio, int p_compras)
{
        /*PROTECTED REGION ID(BookReViewGenNHibernate.CP.BookReview_Libro_puntuarLibro) ENABLED START*/

        ILibroCAD libroCAD = null;
        LibroCEN libroCEN = null;



        try
        {
                SessionInitializeTransaction ();
                libroCAD = new LibroCAD (session);
                libroCEN = new  LibroCEN (libroCAD);




                LibroEN libroEN = null;
                //Initialized LibroEN
                libroEN = new LibroEN ();
                libroEN.LibroID = p_Libro_OID;
                libroEN.Nombre = p_nombre;
                libroEN.Genero = p_genero;
                libroEN.Fechapubli = p_fechapubli;
                libroEN.Idioma = p_idioma;
                libroEN.Portada = p_portada;
                libroEN.Puntuacion = p_puntuacion;
                libroEN.Enlacedecompra = p_enlacedecompra;
                libroEN.Paginas = p_paginas;
                libroEN.Precio = p_precio;
                libroEN.Compras = p_compras;
                //Call to LibroCAD

                libroCAD.PuntuarLibro (libroEN);


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
