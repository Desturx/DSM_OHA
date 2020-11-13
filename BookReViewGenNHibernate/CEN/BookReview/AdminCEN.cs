

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
 *      Definition of the class AdminCEN
 *
 */
public partial class AdminCEN
{
private IAdminCAD _IAdminCAD;

public AdminCEN()
{
        this._IAdminCAD = new AdminCAD ();
}

public AdminCEN(IAdminCAD _IAdminCAD)
{
        this._IAdminCAD = _IAdminCAD;
}

public IAdminCAD get_IAdminCAD ()
{
        return this._IAdminCAD;
}

public int New_ (String p_password, string p_mail, string p_fotoperfil, string p_nombre, double p_dineroventa)
{
        AdminEN adminEN = null;
        int oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        adminEN.Mail = p_mail;

        adminEN.Fotoperfil = p_fotoperfil;

        adminEN.Nombre = p_nombre;

        adminEN.Dineroventa = p_dineroventa;

        //Call to AdminCAD

        oid = _IAdminCAD.New_ (adminEN);
        return oid;
}

public void Modify (int p_Admin_OID, String p_password, string p_mail, string p_fotoperfil, string p_nombre, double p_dineroventa)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.UsuarioID = p_Admin_OID;
        adminEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        adminEN.Mail = p_mail;
        adminEN.Fotoperfil = p_fotoperfil;
        adminEN.Nombre = p_nombre;
        adminEN.Dineroventa = p_dineroventa;
        //Call to AdminCAD

        _IAdminCAD.Modify (adminEN);
}

public void Destroy (int usuarioID
                     )
{
        _IAdminCAD.Destroy (usuarioID);
}

public void BorrarAdmin (int usuarioID
                         )
{
        _IAdminCAD.BorrarAdmin (usuarioID);
}

public void ReportarUsuario (int p_Admin_OID, String p_password, string p_mail, string p_fotoperfil, string p_nombre, double p_dineroventa)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.UsuarioID = p_Admin_OID;
        adminEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        adminEN.Mail = p_mail;
        adminEN.Fotoperfil = p_fotoperfil;
        adminEN.Nombre = p_nombre;
        adminEN.Dineroventa = p_dineroventa;
        //Call to AdminCAD

        _IAdminCAD.ReportarUsuario (adminEN);
}

public AdminEN ReadOID (int usuarioID
                        )
{
        AdminEN adminEN = null;

        adminEN = _IAdminCAD.ReadOID (usuarioID);
        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> list = null;

        list = _IAdminCAD.ReadAll (first, size);
        return list;
}
}
}
