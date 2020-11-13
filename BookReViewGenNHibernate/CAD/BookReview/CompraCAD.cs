
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
 * Clase Compra:
 *
 */

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial class CompraCAD : BasicCAD, ICompraCAD
{
public CompraCAD() : base ()
{
}

public CompraCAD(ISession sessionAux) : base (sessionAux)
{
}



public CompraEN ReadOIDDefault (int compraID
                                )
{
        CompraEN compraEN = null;

        try
        {
                SessionInitializeTransaction ();
                compraEN = (CompraEN)session.Get (typeof(CompraEN), compraID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return compraEN;
}

public System.Collections.Generic.IList<CompraEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CompraEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CompraEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CompraEN>();
                        else
                                result = session.CreateCriteria (typeof(CompraEN)).List<CompraEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CompraEN compra)
{
        try
        {
                SessionInitializeTransaction ();
                CompraEN compraEN = (CompraEN)session.Load (typeof(CompraEN), compra.CompraID);



                compraEN.Tipo_pago = compra.Tipo_pago;


                compraEN.Infotarjeta = compra.Infotarjeta;


                compraEN.Fechaped = compra.Fechaped;


                compraEN.Terminal = compra.Terminal;


                compraEN.Comercio = compra.Comercio;

                session.Update (compraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CompraEN compra)
{
        try
        {
                SessionInitializeTransaction ();
                if (compra.Comprador != null) {
                        // Argumento OID y no colección.
                        compra.Comprador = (BookReViewGenNHibernate.EN.BookReview.UsuarioEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.UsuarioEN), compra.Comprador.UsuarioID);

                        compra.Comprador.PasarelaPago
                        .Add (compra);
                }
                if (compra.Solicitante != null) {
                        // Argumento OID y no colección.
                        compra.Solicitante = (BookReViewGenNHibernate.EN.BookReview.LibroEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.LibroEN), compra.Solicitante.LibroID);

                        compra.Solicitante.SolicitudesRealizada
                        .Add (compra);
                }

                session.Save (compra);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return compra.CompraID;
}

public void Modify (CompraEN compra)
{
        try
        {
                SessionInitializeTransaction ();
                CompraEN compraEN = (CompraEN)session.Load (typeof(CompraEN), compra.CompraID);

                compraEN.Tipo_pago = compra.Tipo_pago;


                compraEN.Infotarjeta = compra.Infotarjeta;


                compraEN.Fechaped = compra.Fechaped;


                compraEN.Terminal = compra.Terminal;


                compraEN.Comercio = compra.Comercio;

                session.Update (compraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int compraID
                     )
{
        try
        {
                SessionInitializeTransaction ();
                CompraEN compraEN = (CompraEN)session.Load (typeof(CompraEN), compraID);
                session.Delete (compraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CompraEN
public CompraEN ReadOID (int compraID
                         )
{
        CompraEN compraEN = null;

        try
        {
                SessionInitializeTransaction ();
                compraEN = (CompraEN)session.Get (typeof(CompraEN), compraID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return compraEN;
}

public System.Collections.Generic.IList<CompraEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CompraEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CompraEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CompraEN>();
                else
                        result = session.CreateCriteria (typeof(CompraEN)).List<CompraEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int CreaCompra (CompraEN compra)
{
        try
        {
                SessionInitializeTransaction ();
                if (compra.Comprador != null) {
                        // Argumento OID y no colección.
                        compra.Comprador = (BookReViewGenNHibernate.EN.BookReview.UsuarioEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.UsuarioEN), compra.Comprador.UsuarioID);

                        compra.Comprador.PasarelaPago
                        .Add (compra);
                }
                if (compra.Solicitante != null) {
                        // Argumento OID y no colección.
                        compra.Solicitante = (BookReViewGenNHibernate.EN.BookReview.LibroEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.LibroEN), compra.Solicitante.LibroID);

                        compra.Solicitante.SolicitudesRealizada
                        .Add (compra);
                }

                session.Save (compra);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return compra.CompraID;
}
}
}
