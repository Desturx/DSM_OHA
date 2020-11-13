
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
 * Clase puntuacion:
 *
 */

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial class PuntuacionCAD : BasicCAD, IPuntuacionCAD
{
public PuntuacionCAD() : base ()
{
}

public PuntuacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public PuntuacionEN ReadOIDDefault (int id
                                    )
{
        PuntuacionEN puntuacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                puntuacionEN = (PuntuacionEN)session.Get (typeof(PuntuacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in PuntuacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return puntuacionEN;
}

public System.Collections.Generic.IList<PuntuacionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PuntuacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PuntuacionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PuntuacionEN>();
                        else
                                result = session.CreateCriteria (typeof(PuntuacionEN)).List<PuntuacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in PuntuacionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PuntuacionEN puntuacion)
{
        try
        {
                SessionInitializeTransaction ();
                PuntuacionEN puntuacionEN = (PuntuacionEN)session.Load (typeof(PuntuacionEN), puntuacion.Id);

                puntuacionEN.Puntuacion = puntuacion.Puntuacion;



                session.Update (puntuacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in PuntuacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PuntuacionEN puntuacion)
{
        try
        {
                SessionInitializeTransaction ();
                if (puntuacion.Usuario != null) {
                        // Argumento OID y no colección.
                        puntuacion.Usuario = (BookReViewGenNHibernate.EN.BookReview.UsuarioEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.UsuarioEN), puntuacion.Usuario.UsuarioID);

                        puntuacion.Usuario.Puntuacion
                        .Add (puntuacion);
                }
                if (puntuacion.Libro != null) {
                        // Argumento OID y no colección.
                        puntuacion.Libro = (BookReViewGenNHibernate.EN.BookReview.LibroEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.LibroEN), puntuacion.Libro.LibroID);

                        puntuacion.Libro.Puntuacion_0
                        .Add (puntuacion);
                }

                session.Save (puntuacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in PuntuacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return puntuacion.Id;
}

public void Modify (PuntuacionEN puntuacion)
{
        try
        {
                SessionInitializeTransaction ();
                PuntuacionEN puntuacionEN = (PuntuacionEN)session.Load (typeof(PuntuacionEN), puntuacion.Id);
                session.Update (puntuacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in PuntuacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                PuntuacionEN puntuacionEN = (PuntuacionEN)session.Load (typeof(PuntuacionEN), id);
                session.Delete (puntuacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in PuntuacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
