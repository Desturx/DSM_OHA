
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
 * Clase Libro:
 *
 */

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial class LibroCAD : BasicCAD, ILibroCAD
{
public LibroCAD() : base ()
{
}

public LibroCAD(ISession sessionAux) : base (sessionAux)
{
}



public LibroEN ReadOIDDefault (int libroID
                               )
{
        LibroEN libroEN = null;

        try
        {
                SessionInitializeTransaction ();
                libroEN = (LibroEN)session.Get (typeof(LibroEN), libroID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return libroEN;
}

public System.Collections.Generic.IList<LibroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LibroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LibroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LibroEN>();
                        else
                                result = session.CreateCriteria (typeof(LibroEN)).List<LibroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.LibroID);

                libroEN.Autor = libro.Autor;


                libroEN.Nombre = libro.Nombre;


                libroEN.Genero = libro.Genero;


                libroEN.Fechapubli = libro.Fechapubli;


                libroEN.Idioma = libro.Idioma;


                libroEN.Portada = libro.Portada;


                libroEN.Puntuacion = libro.Puntuacion;


                libroEN.Enlacedecompra = libro.Enlacedecompra;


                libroEN.Paginas = libro.Paginas;


                libroEN.Precio = libro.Precio;









                libroEN.Compras = libro.Compras;

                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modify (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.LibroID);

                libroEN.Autor = libro.Autor;


                libroEN.Nombre = libro.Nombre;


                libroEN.Genero = libro.Genero;


                libroEN.Fechapubli = libro.Fechapubli;


                libroEN.Idioma = libro.Idioma;


                libroEN.Portada = libro.Portada;


                libroEN.Puntuacion = libro.Puntuacion;


                libroEN.Enlacedecompra = libro.Enlacedecompra;


                libroEN.Paginas = libro.Paginas;


                libroEN.Precio = libro.Precio;


                libroEN.Compras = libro.Compras;

                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarLibro (int libroID
                         )
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libroID);
                session.Delete (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int PublicarLibro (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                if (libro.Creador != null) {
                        // Argumento OID y no colección.
                        libro.Creador = (BookReViewGenNHibernate.EN.BookReview.UsuarioEN)session.Load (typeof(BookReViewGenNHibernate.EN.BookReview.UsuarioEN), libro.Creador.UsuarioID);

                        libro.Creador.LibrosCreado
                        .Add (libro);
                }

                session.Save (libro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return libro.LibroID;
}

public void PuntuarLibro (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.LibroID);

                libroEN.Autor = libro.Autor;


                libroEN.Nombre = libro.Nombre;


                libroEN.Genero = libro.Genero;


                libroEN.Fechapubli = libro.Fechapubli;


                libroEN.Idioma = libro.Idioma;


                libroEN.Portada = libro.Portada;


                libroEN.Puntuacion = libro.Puntuacion;


                libroEN.Enlacedecompra = libro.Enlacedecompra;


                libroEN.Paginas = libro.Paginas;


                libroEN.Precio = libro.Precio;


                libroEN.Compras = libro.Compras;

                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> FiltrarListaLectura ()
{
        System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM LibroEN self where  select lib FROM LibroEN as lib inner join lib.Usuario as us where us.Club.LibroActual = lib.Nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("LibroENfiltrarListaLecturaHQL");

                result = query.List<BookReViewGenNHibernate.EN.BookReview.LibroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: ReadOID
//Con e: LibroEN
public LibroEN ReadOID (int libroID
                        )
{
        LibroEN libroEN = null;

        try
        {
                SessionInitializeTransaction ();
                libroEN = (LibroEN)session.Get (typeof(LibroEN), libroID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return libroEN;
}

public System.Collections.Generic.IList<LibroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LibroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LibroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LibroEN>();
                else
                        result = session.CreateCriteria (typeof(LibroEN)).List<LibroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
