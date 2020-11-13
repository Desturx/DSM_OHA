
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
 * Clase Admin:
 *
 */

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial class AdminCAD : BasicCAD, IAdminCAD
{
public AdminCAD() : base ()
{
}

public AdminCAD(ISession sessionAux) : base (sessionAux)
{
}



public AdminEN ReadOIDDefault (int usuarioID
                               )
{
        AdminEN adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Get (typeof(AdminEN), usuarioID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AdminEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AdminEN>();
                        else
                                result = session.CreateCriteria (typeof(AdminEN)).List<AdminEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), admin.UsuarioID);
                session.Update (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (admin);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return admin.UsuarioID;
}

public void Modify (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), admin.UsuarioID);

                adminEN.Password = admin.Password;


                adminEN.Mail = admin.Mail;


                adminEN.Fotoperfil = admin.Fotoperfil;


                adminEN.Nombre = admin.Nombre;


                adminEN.Dineroventa = admin.Dineroventa;

                session.Update (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int usuarioID
                     )
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), usuarioID);
                session.Delete (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarAdmin (int usuarioID
                         )
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), usuarioID);
                session.Delete (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void ReportarUsuario (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), admin.UsuarioID);

                adminEN.Password = admin.Password;


                adminEN.Mail = admin.Mail;


                adminEN.Fotoperfil = admin.Fotoperfil;


                adminEN.Nombre = admin.Nombre;


                adminEN.Dineroventa = admin.Dineroventa;

                session.Update (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: AdminEN
public AdminEN ReadOID (int usuarioID
                        )
{
        AdminEN adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Get (typeof(AdminEN), usuarioID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AdminEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AdminEN>();
                else
                        result = session.CreateCriteria (typeof(AdminEN)).List<AdminEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is BookReViewGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new BookReViewGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
