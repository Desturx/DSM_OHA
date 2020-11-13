

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
 *      Definition of the class PuntuacionCEN
 *
 */
public partial class PuntuacionCEN
{
private IPuntuacionCAD _IPuntuacionCAD;

public PuntuacionCEN()
{
        this._IPuntuacionCAD = new PuntuacionCAD ();
}

public PuntuacionCEN(IPuntuacionCAD _IPuntuacionCAD)
{
        this._IPuntuacionCAD = _IPuntuacionCAD;
}

public IPuntuacionCAD get_IPuntuacionCAD ()
{
        return this._IPuntuacionCAD;
}

public int New_ (int p_puntuacion, int p_usuario, int p_libro)
{
        PuntuacionEN puntuacionEN = null;
        int oid;

        //Initialized PuntuacionEN
        puntuacionEN = new PuntuacionEN ();
        puntuacionEN.Puntuacion = p_puntuacion;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                puntuacionEN.Usuario = new BookReViewGenNHibernate.EN.BookReview.UsuarioEN ();
                puntuacionEN.Usuario.UsuarioID = p_usuario;
        }


        if (p_libro != -1) {
                // El argumento p_libro -> Property libro es oid = false
                // Lista de oids id
                puntuacionEN.Libro = new BookReViewGenNHibernate.EN.BookReview.LibroEN ();
                puntuacionEN.Libro.LibroID = p_libro;
        }

        //Call to PuntuacionCAD

        oid = _IPuntuacionCAD.New_ (puntuacionEN);
        return oid;
}

public void Modify (int p_puntuacion_OID)
{
        PuntuacionEN puntuacionEN = null;

        //Initialized PuntuacionEN
        puntuacionEN = new PuntuacionEN ();
        puntuacionEN.Id = p_puntuacion_OID;
        //Call to PuntuacionCAD

        _IPuntuacionCAD.Modify (puntuacionEN);
}

public void Destroy (int id
                     )
{
        _IPuntuacionCAD.Destroy (id);
}
}
}
