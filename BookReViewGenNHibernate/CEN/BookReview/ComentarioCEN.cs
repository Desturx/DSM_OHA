

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
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public void Modify (int p_Comentario_OID, string p_titulo, Nullable<DateTime> p_fecha, string p_contenido, int p_autorID, int p_paginasLeidas)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Comentario = p_Comentario_OID;
        comentarioEN.Titulo = p_titulo;
        comentarioEN.Fecha = p_fecha;
        comentarioEN.Contenido = p_contenido;
        comentarioEN.AutorID = p_autorID;
        comentarioEN.PaginasLeidas = p_paginasLeidas;
        //Call to ComentarioCAD

        _IComentarioCAD.Modify (comentarioEN);
}

public void Destroy (int comentario
                     )
{
        _IComentarioCAD.Destroy (comentario);
}

public void BorrarComentario (int comentario
                              )
{
        _IComentarioCAD.BorrarComentario (comentario);
}

public int PublicarComentario (string p_titulo, Nullable<DateTime> p_fecha, string p_contenido, int p_lectura, int p_comentador, int p_paginasLeidas)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Titulo = p_titulo;

        comentarioEN.Fecha = p_fecha;

        comentarioEN.Contenido = p_contenido;


        if (p_lectura != -1) {
                // El argumento p_lectura -> Property lectura es oid = false
                // Lista de oids comentario
                comentarioEN.Lectura = new BookReViewGenNHibernate.EN.BookReview.LibroEN ();
                comentarioEN.Lectura.LibroID = p_lectura;
        }


        if (p_comentador != -1) {
                // El argumento p_comentador -> Property comentador es oid = false
                // Lista de oids comentario
                comentarioEN.Comentador = new BookReViewGenNHibernate.EN.BookReview.UsuarioEN ();
                comentarioEN.Comentador.UsuarioID = p_comentador;
        }

        comentarioEN.PaginasLeidas = p_paginasLeidas;

        //Call to ComentarioCAD

        oid = _IComentarioCAD.PublicarComentario (comentarioEN);
        return oid;
}

public System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> FiltrarAmigos ()
{
        return _IComentarioCAD.FiltrarAmigos ();
}
public ComentarioEN ReadOID (int comentario
                             )
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioCAD.ReadOID (comentario);
        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioCAD.ReadAll (first, size);
        return list;
}
}
}
