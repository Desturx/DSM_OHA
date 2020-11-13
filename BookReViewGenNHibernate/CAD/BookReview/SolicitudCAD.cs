
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
 * Clase Solicitud:
 *
 */

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial class SolicitudCAD : BasicCAD, ISolicitudCAD
{
public SolicitudCAD() : base ()
{
}

public SolicitudCAD(ISession sessionAux) : base (sessionAux)
{
}



public SolicitudEN ReadOIDDefault (int id
                                   )
{
        SolicitudEN solicitudEN = null;

        try
        {
                SessionInitializeTransaction ();
                solicitudEN = (SolicitudEN)session.Get (typeof(SolicitudEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitudEN;
}

public System.Collections.Generic.IList<SolicitudEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SolicitudEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SolicitudEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SolicitudEN>();
                        else
                                result = session.CreateCriteria (typeof(SolicitudEN)).List<SolicitudEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SolicitudEN solicitud)
{
        try
        {
                SessionInitializeTransaction ();
                SolicitudEN solicitudEN = (SolicitudEN)session.Load (typeof(SolicitudEN), solicitud.Id);

                solicitudEN.Estado = solicitud.Estado;



                session.Update (solicitudEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearSolicitud (SolicitudEN solicitud)
{
        try
        {
                SessionInitializeTransaction ();
                if (solicitud.Solicitante != null) {
                        // Argumento OID y no colección.
                        solicitud.Solicitante = (BookReViewGenNHibernate.EN.BookReview.UsuarioEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.UsuarioEN), solicitud.Solicitante.UsuarioID);

                        solicitud.Solicitante.SolicitudesRealizadas
                        .Add (solicitud);
                }
                if (solicitud.Solicitado != null) {
                        // Argumento OID y no colección.
                        solicitud.Solicitado = (BookReViewGenNHibernate.EN.BookReview.UsuarioEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.UsuarioEN), solicitud.Solicitado.UsuarioID);

                        solicitud.Solicitado.SolicitudesRecibidas
                        .Add (solicitud);
                }

                session.Save (solicitud);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitud.Id;
}

public void Modify (SolicitudEN solicitud)
{
        try
        {
                SessionInitializeTransaction ();
                SolicitudEN solicitudEN = (SolicitudEN)session.Load (typeof(SolicitudEN), solicitud.Id);

                solicitudEN.Estado = solicitud.Estado;

                session.Update (solicitudEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
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
                SolicitudEN solicitudEN = (SolicitudEN)session.Load (typeof(SolicitudEN), id);
                session.Delete (solicitudEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: SolicitudEN
public SolicitudEN ReadOID (int id
                            )
{
        SolicitudEN solicitudEN = null;

        try
        {
                SessionInitializeTransaction ();
                solicitudEN = (SolicitudEN)session.Get (typeof(SolicitudEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitudEN;
}

public System.Collections.Generic.IList<SolicitudEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SolicitudEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SolicitudEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SolicitudEN>();
                else
                        result = session.CreateCriteria (typeof(SolicitudEN)).List<SolicitudEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
