
using System;
using System.Text;
using BookReViewGenNHibernate.CEN.BookReview;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using BookReViewGenNHibernate.EN.BookReview;
using BookReViewGenNHibernate.Exceptions;


/*
 * Clase Comentario:
 *
 */

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial class ComentarioCAD : BasicCAD, IComentarioCAD
{
public ComentarioCAD() : base ()
{
}

public ComentarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComentarioEN ReadOIDDefault (int comentario
                                    )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioEN), comentario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentarioEN)).List<ComentarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), comentario.Comentario);

                comentarioEN.Titulo = comentario.Titulo;


                comentarioEN.Fecha = comentario.Fecha;


                comentarioEN.Contenido = comentario.Contenido;




                comentarioEN.AutorID = comentario.AutorID;


                comentarioEN.PaginasLeidas = comentario.PaginasLeidas;

                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                if (comentario.Lectura != null) {
                        // Argumento OID y no colección.
                        comentario.Lectura = (BookReViewGenNHibernate.EN.BookReview.LibroEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.LibroEN), comentario.Lectura.LibroID);

                        comentario.Lectura.Opinion
                        .Add (comentario);
                }
                if (comentario.Comentador != null) {
                        // Argumento OID y no colección.
                        comentario.Comentador = (BookReViewGenNHibernate.EN.BookReview.UsuarioEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.UsuarioEN), comentario.Comentador.UsuarioID);

                        comentario.Comentador.Comentario
                        .Add (comentario);
                }

                session.Save (comentario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentario.Comentario;
}

public void Modify (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), comentario.Comentario);

                comentarioEN.Titulo = comentario.Titulo;


                comentarioEN.Fecha = comentario.Fecha;


                comentarioEN.Contenido = comentario.Contenido;


                comentarioEN.AutorID = comentario.AutorID;


                comentarioEN.PaginasLeidas = comentario.PaginasLeidas;

                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int comentario
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), comentario);
                session.Delete (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarComentario (int comentario
                              )
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), comentario);
                session.Delete (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int PublicarComentario (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                if (comentario.Lectura != null) {
                        // Argumento OID y no colección.
                        comentario.Lectura = (BookReViewGenNHibernate.EN.BookReview.LibroEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.LibroEN), comentario.Lectura.LibroID);

                        comentario.Lectura.Opinion
                        .Add (comentario);
                }
                if (comentario.Comentador != null) {
                        // Argumento OID y no colección.
                        comentario.Comentador = (BookReViewGenNHibernate.EN.BookReview.UsuarioEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.UsuarioEN), comentario.Comentador.UsuarioID);

                        comentario.Comentador.Comentario
                        .Add (comentario);
                }

                session.Save (comentario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentario.Comentario;
}

public System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> FiltrarAmigos ()
{
        System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ComentarioEN self where  select com FROM Comentario as com inner join com.Comentador.SolicitudesRecibidas as lista where lista.Solicitante.UsuarioID = com.autorID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ComentarioENfiltrarAmigosHQL");

                result = query.List<BookReViewGenNHibernate.EN.BookReview.ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: ReadOID
//Con e: ComentarioEN
public ComentarioEN ReadOID (int comentario
                             )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioEN), comentario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComentarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                else
                        result = session.CreateCriteria (typeof(ComentarioEN)).List<ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
