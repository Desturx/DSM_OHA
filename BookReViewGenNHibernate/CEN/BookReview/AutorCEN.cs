

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
 *      Definition of the class AutorCEN
 *
 */
public partial class AutorCEN
{
private IAutorCAD _IAutorCAD;

public AutorCEN()
{
        this._IAutorCAD = new AutorCAD ();
}

public AutorCEN(IAutorCAD _IAutorCAD)
{
        this._IAutorCAD = _IAutorCAD;
}

public IAutorCAD get_IAutorCAD ()
{
        return this._IAutorCAD;
}

public int New_ (string p_nombre, int p_numLibros, Nullable<DateTime> p_nacimiento, string p_fotoautor)
{
        AutorEN autorEN = null;
        int oid;

        //Initialized AutorEN
        autorEN = new AutorEN ();
        autorEN.Nombre = p_nombre;

        autorEN.NumLibros = p_numLibros;

        autorEN.Nacimiento = p_nacimiento;

        autorEN.Fotoautor = p_fotoautor;

        //Call to AutorCAD

        oid = _IAutorCAD.New_ (autorEN);
        return oid;
}

public void Modify (int p_Autor_OID, string p_nombre, int p_numLibros, Nullable<DateTime> p_nacimiento, string p_fotoautor)
{
        AutorEN autorEN = null;

        //Initialized AutorEN
        autorEN = new AutorEN ();
        autorEN.AutorID = p_Autor_OID;
        autorEN.Nombre = p_nombre;
        autorEN.NumLibros = p_numLibros;
        autorEN.Nacimiento = p_nacimiento;
        autorEN.Fotoautor = p_fotoautor;
        //Call to AutorCAD

        _IAutorCAD.Modify (autorEN);
}

public void Destroy (int autorID
                     )
{
        _IAutorCAD.Destroy (autorID);
}

public AutorEN ReadOID (int autorID
                        )
{
        AutorEN autorEN = null;

        autorEN = _IAutorCAD.ReadOID (autorID);
        return autorEN;
}

public System.Collections.Generic.IList<AutorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AutorEN> list = null;

        list = _IAutorCAD.ReadAll (first, size);
        return list;
}
}
}
