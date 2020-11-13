

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
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public int New_ (String p_password, string p_mail, string p_fotoperfil, string p_nombre)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        usuarioEN.Mail = p_mail;

        usuarioEN.Fotoperfil = p_fotoperfil;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Dineroventa = 0;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (int p_Usuario_OID, String p_password, string p_mail, string p_fotoperfil, string p_nombre, double p_dineroventa)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.UsuarioID = p_Usuario_OID;
        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        usuarioEN.Mail = p_mail;
        usuarioEN.Fotoperfil = p_fotoperfil;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Dineroventa = p_dineroventa;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (int usuarioID
                     )
{
        _IUsuarioCAD.Destroy (usuarioID);
}

public int Registro (String p_password, string p_mail, string p_fotoperfil, string p_nombre, double p_dineroventa)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        usuarioEN.Mail = p_mail;

        usuarioEN.Fotoperfil = p_fotoperfil;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Dineroventa = p_dineroventa;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.Registro (usuarioEN);
        return oid;
}

public string Login (int p_mail, string p_password)
{
        string result = null;
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (p_mail);

        if (en != null && en.Password.Equals (Utils.Util.GetEncondeMD5 (p_password)))
                result = this.GetToken (en.UsuarioID);

        return result;
}

private string GetToken(int usuarioID)
{
    UsuarioEN en = _IUsuarioCAD.ReadOIDDefault(usuarioID);
    string token = Encode(en.Mail);

    return token;
}

private string Encode(string mail)
{
     var payload = new Dictionary<string, object>()
    {
        { "mail", mail }
    };
    string token = Jose.JWT.Encode(payload, Utils.Util.getKey(), Jose.JwsAlgorithm.HS256);

    return token;
}

public UsuarioEN ReadOID (int usuarioID)
{
UsuarioEN usuarioEN = null;

usuarioEN = _IUsuarioCAD.ReadOID (usuarioID);
return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
public void AnyadirClub (int p_Usuario_OID, System.Collections.Generic.IList<int> p_clubs_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AnyadirClub (p_Usuario_OID, p_clubs_OIDs);
}
public void AnyadirLibro (int p_Usuario_OID, System.Collections.Generic.IList<int> p_libros_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AnyadirLibro (p_Usuario_OID, p_libros_OIDs);
}
}
}
