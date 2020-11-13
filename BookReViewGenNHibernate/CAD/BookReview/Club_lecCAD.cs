
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
 * Clase Club_lec:
 *
 */

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial class Club_lecCAD : BasicCAD, IClub_lecCAD
{
public Club_lecCAD() : base ()
{
}

public Club_lecCAD(ISession sessionAux) : base (sessionAux)
{
}



public Club_lecEN ReadOIDDefault (int clubID
                                  )
{
        Club_lecEN club_lecEN = null;

        try
        {
                SessionInitializeTransaction ();
                club_lecEN = (Club_lecEN)session.Get (typeof(Club_lecEN), clubID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in Club_lecCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return club_lecEN;
}

public System.Collections.Generic.IList<Club_lecEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<Club_lecEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(Club_lecEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<Club_lecEN>();
                        else
                                result = session.CreateCriteria (typeof(Club_lecEN)).List<Club_lecEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in Club_lecCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (Club_lecEN club_lec)
{
        try
        {
                SessionInitializeTransaction ();
                Club_lecEN club_lecEN = (Club_lecEN)session.Load (typeof(Club_lecEN), club_lec.ClubID);

                club_lecEN.Mensualidad = club_lec.Mensualidad;


                club_lecEN.PaginaActual = club_lec.PaginaActual;


                club_lecEN.Estado = club_lec.Estado;



                session.Update (club_lecEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in Club_lecCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (Club_lecEN club_lec)
{
        try
        {
                SessionInitializeTransaction ();
                if (club_lec.Lectura != null) {
                        // Argumento OID y no colección.
                        club_lec.Lectura = (BookReViewGenNHibernate.EN.BookReview.LibroEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.LibroEN), club_lec.Lectura.LibroID);

                        club_lec.Lectura.Clublibro
                        .Add (club_lec);
                }

                session.Save (club_lec);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in Club_lecCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return club_lec.ClubID;
}

public void Modify (Club_lecEN club_lec)
{
        try
        {
                SessionInitializeTransaction ();
                Club_lecEN club_lecEN = (Club_lecEN)session.Load (typeof(Club_lecEN), club_lec.ClubID);

                club_lecEN.Mensualidad = club_lec.Mensualidad;


                club_lecEN.PaginaActual = club_lec.PaginaActual;


                club_lecEN.Estado = club_lec.Estado;

                session.Update (club_lecEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in Club_lecCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int clubID
                     )
{
        try
        {
                SessionInitializeTransaction ();
                Club_lecEN club_lecEN = (Club_lecEN)session.Load (typeof(Club_lecEN), clubID);
                session.Delete (club_lecEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in Club_lecCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> FiltraPagsLeidas ()
{
        System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM Club_lecEN self where  select com FROM Comentario as com where com.Comentador.Club.paginaActual >= com.paginasLeidas";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("Club_lecENfiltraPagsLeidasHQL");

                result = query.List<BookReViewGenNHibernate.EN.BookReview.Club_lecEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in Club_lecCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: ReadOID
//Con e: Club_lecEN
public Club_lecEN ReadOID (int clubID
                           )
{
        Club_lecEN club_lecEN = null;

        try
        {
                SessionInitializeTransaction ();
                club_lecEN = (Club_lecEN)session.Get (typeof(Club_lecEN), clubID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in Club_lecCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return club_lecEN;
}

public System.Collections.Generic.IList<Club_lecEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Club_lecEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(Club_lecEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<Club_lecEN>();
                else
                        result = session.CreateCriteria (typeof(Club_lecEN)).List<Club_lecEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in Club_lecCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
