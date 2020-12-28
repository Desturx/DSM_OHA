
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
 * Clase Autor:
 *
 */

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial class AutorCAD : BasicCAD, IAutorCAD
{
public AutorCAD() : base ()
{
}

public AutorCAD(ISession sessionAux) : base (sessionAux)
{
}



public AutorEN ReadOIDDefault (int autorID
                               )
{
        AutorEN autorEN = null;

        try
        {
                SessionInitializeTransaction ();
                autorEN = (AutorEN)session.Get (typeof(AutorEN), autorID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AutorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return autorEN;
}

public System.Collections.Generic.IList<AutorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AutorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AutorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AutorEN>();
                        else
                                result = session.CreateCriteria (typeof(AutorEN)).List<AutorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AutorCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AutorEN autor)
{
        try
        {
                SessionInitializeTransaction ();
                AutorEN autorEN = (AutorEN)session.Load (typeof(AutorEN), autor.AutorID);

                autorEN.Nombre = autor.Nombre;


                autorEN.NumLibros = autor.NumLibros;


                autorEN.Nacimiento = autor.Nacimiento;


                autorEN.Fotoautor = autor.Fotoautor;


                session.Update (autorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AutorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (AutorEN autor)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (autor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AutorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return autor.AutorID;
}

public void Destroy (int autorID
                     )
{
        try
        {
                SessionInitializeTransaction ();
                AutorEN autorEN = (AutorEN)session.Load (typeof(AutorEN), autorID);
                session.Delete (autorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AutorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (AutorEN autor)
{
        try
        {
                SessionInitializeTransaction ();
                AutorEN autorEN = (AutorEN)session.Load (typeof(AutorEN), autor.AutorID);

                autorEN.Nombre = autor.Nombre;


                autorEN.NumLibros = autor.NumLibros;


                autorEN.Nacimiento = autor.Nacimiento;


                autorEN.Fotoautor = autor.Fotoautor;

                session.Update (autorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AutorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: AutorEN
public AutorEN ReadOID (int autorID
                        )
{
        AutorEN autorEN = null;

        try
        {
                SessionInitializeTransaction ();
                autorEN = (AutorEN)session.Get (typeof(AutorEN), autorID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AutorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return autorEN;
}

public System.Collections.Generic.IList<AutorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AutorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AutorEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AutorEN>();
                else
                        result = session.CreateCriteria (typeof(AutorEN)).List<AutorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AutorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
