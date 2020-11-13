
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
 * Clase Lista:
 *
 */

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial class ListaCAD : BasicCAD, IListaCAD
{
public ListaCAD() : base ()
{
}

public ListaCAD(ISession sessionAux) : base (sessionAux)
{
}



public ListaEN ReadOIDDefault (int id
                               )
{
        ListaEN listaEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Get (typeof(ListaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaEN;
}

public System.Collections.Generic.IList<ListaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ListaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ListaEN>();
                        else
                                result = session.CreateCriteria (typeof(ListaEN)).List<ListaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaEN listaEN = (ListaEN)session.Load (typeof(ListaEN), lista.Id);


                listaEN.Tipo = lista.Tipo;


                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                if (lista.DuenyoLista != null) {
                        // Argumento OID y no colección.
                        lista.DuenyoLista = (BookReViewGenNHibernate.EN.BookReview.UsuarioEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.UsuarioEN), lista.DuenyoLista.UsuarioID);

                        lista.DuenyoLista.ListaTipo
                        .Add (lista);
                }

                session.Save (lista);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lista.Id;
}

public void Modify (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaEN listaEN = (ListaEN)session.Load (typeof(ListaEN), lista.Id);

                listaEN.Tipo = lista.Tipo;

                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
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
                ListaEN listaEN = (ListaEN)session.Load (typeof(ListaEN), id);
                session.Delete (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirToLista (int p_Lista_OID, System.Collections.Generic.IList<int> p_enlistado_OIDs)
{
        BookReViewGenNHibernate.EN.BookReview.ListaEN listaEN = null;
        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Load (typeof(ListaEN), p_Lista_OID);
                BookReViewGenNHibernate.EN.BookReview.LibroEN enlistadoENAux = null;
                if (listaEN.Enlistado == null) {
                        listaEN.Enlistado = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.LibroEN>();
                }

                foreach (int item in p_enlistado_OIDs) {
                        enlistadoENAux = new BookReViewGenNHibernate.EN.BookReview.LibroEN ();
                        enlistadoENAux = (BookReViewGenNHibernate.EN.BookReview.LibroEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.LibroEN), item);
                        enlistadoENAux.Listainfo.Add (listaEN);

                        listaEN.Enlistado.Add (enlistadoENAux);
                }


                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ListaEN
public ListaEN ReadOID (int id
                        )
{
        ListaEN listaEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Get (typeof(ListaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaEN;
}

public System.Collections.Generic.IList<ListaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ListaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ListaEN>();
                else
                        result = session.CreateCriteria (typeof(ListaEN)).List<ListaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
