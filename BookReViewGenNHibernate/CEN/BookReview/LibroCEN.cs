

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using BookReViewGenNHibernate.Exceptions;

using BookReViewGenNHibernate.EN.BookReview;
using BookReViewGenNHibernate.CAD.BookReview;


namespace BookReViewGenNHibernate.CEN.BookReview
{
/*
 *      Definition of the class LibroCEN
 *
 */
public partial class LibroCEN
{
private ILibroCAD _ILibroCAD;

public LibroCEN()
{
        this._ILibroCAD = new LibroCAD ();
}

public LibroCEN(ILibroCAD _ILibroCAD)
{
        this._ILibroCAD = _ILibroCAD;
}

public ILibroCAD get_ILibroCAD ()
{
        return this._ILibroCAD;
}

public void Modify (int p_Libro_OID, string p_nombre, string p_genero, Nullable<DateTime> p_fechapubli, string p_idioma, string p_portada, double p_puntuacion, string p_enlacedecompra, int p_paginas, double p_precio, int p_compras)
{
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

        _ILibroCAD.Modify (libroEN);
}

public void BorrarLibro (int libroID
                         )
{
        _ILibroCAD.BorrarLibro (libroID);
}

public int PublicarLibro (string p_nombre, string p_genero, Nullable<DateTime> p_fechapubli, string p_idioma, string p_portada, double p_puntuacion, string p_enlacedecompra, int p_paginas, double p_precio, int p_creador, int p_compras, int p_aut_lib)
{
        LibroEN libroEN = null;
        int oid;

        //Initialized LibroEN
        libroEN = new LibroEN ();
        libroEN.Nombre = p_nombre;

        libroEN.Genero = p_genero;

        libroEN.Fechapubli = p_fechapubli;

        libroEN.Idioma = p_idioma;

        libroEN.Portada = p_portada;

        libroEN.Puntuacion = p_puntuacion;

        libroEN.Enlacedecompra = p_enlacedecompra;

        libroEN.Paginas = p_paginas;

        libroEN.Precio = p_precio;


        if (p_creador != -1) {
                // El argumento p_creador -> Property creador es oid = false
                // Lista de oids libroID
                libroEN.Creador = new BookReViewGenNHibernate.EN.BookReview.UsuarioEN ();
                libroEN.Creador.UsuarioID = p_creador;
        }

        libroEN.Compras = p_compras;


        if (p_aut_lib != -1) {
                // El argumento p_aut_lib -> Property aut_lib es oid = false
                // Lista de oids libroID
                libroEN.Aut_lib = new BookReViewGenNHibernate.EN.BookReview.AutorEN ();
                libroEN.Aut_lib.AutorID = p_aut_lib;
        }

        //Call to LibroCAD

        oid = _ILibroCAD.PublicarLibro (libroEN);
        return oid;
}

public void PuntuarLibro (int p_Libro_OID, string p_nombre, string p_genero, Nullable<DateTime> p_fechapubli, string p_idioma, string p_portada, double p_puntuacion, string p_enlacedecompra, int p_paginas, double p_precio, int p_compras)
{
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

        _ILibroCAD.PuntuarLibro (libroEN);
}

public LibroEN ReadOID (int libroID
                        )
{
        LibroEN libroEN = null;

        libroEN = _ILibroCAD.ReadOID (libroID);
        return libroEN;
}

public System.Collections.Generic.IList<LibroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LibroEN> list = null;

        list = _ILibroCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> ReadFilter (double ? p_precio)
{
        return _ILibroCAD.ReadFilter (p_precio);
}
public System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> FiltroBestSeller (string p_mail)
{
        return _ILibroCAD.FiltroBestSeller (p_mail);
}
}
}
