

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
 *      Definition of the class Club_lecCEN
 *
 */
public partial class Club_lecCEN
{
private IClub_lecCAD _IClub_lecCAD;

public Club_lecCEN()
{
        this._IClub_lecCAD = new Club_lecCAD ();
}

public Club_lecCEN(IClub_lecCAD _IClub_lecCAD)
{
        this._IClub_lecCAD = _IClub_lecCAD;
}

public IClub_lecCAD get_IClub_lecCAD ()
{
        return this._IClub_lecCAD;
}

public int New_ (Nullable<DateTime> p_mensualidad, int p_paginaActual, bool p_estado, int p_lectura)
{
        Club_lecEN club_lecEN = null;
        int oid;

        //Initialized Club_lecEN
        club_lecEN = new Club_lecEN ();
        club_lecEN.Mensualidad = p_mensualidad;

        club_lecEN.PaginaActual = p_paginaActual;

        club_lecEN.Estado = p_estado;


        if (p_lectura != -1) {
                // El argumento p_lectura -> Property lectura es oid = false
                // Lista de oids clubID
                club_lecEN.Lectura = new BookReViewGenNHibernate.EN.BookReview.LibroEN ();
                club_lecEN.Lectura.LibroID = p_lectura;
        }

        //Call to Club_lecCAD

        oid = _IClub_lecCAD.New_ (club_lecEN);
        return oid;
}

public void Modify (int p_Club_lec_OID, Nullable<DateTime> p_mensualidad, int p_paginaActual, bool p_estado)
{
        Club_lecEN club_lecEN = null;

        //Initialized Club_lecEN
        club_lecEN = new Club_lecEN ();
        club_lecEN.ClubID = p_Club_lec_OID;
        club_lecEN.Mensualidad = p_mensualidad;
        club_lecEN.PaginaActual = p_paginaActual;
        club_lecEN.Estado = p_estado;
        //Call to Club_lecCAD

        _IClub_lecCAD.Modify (club_lecEN);
}

public void Destroy (int clubID
                     )
{
        _IClub_lecCAD.Destroy (clubID);
}

public System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> FiltraPagsLeidas ()
{
        return _IClub_lecCAD.FiltraPagsLeidas ();
}
public Club_lecEN ReadOID (int clubID
                           )
{
        Club_lecEN club_lecEN = null;

        club_lecEN = _IClub_lecCAD.ReadOID (clubID);
        return club_lecEN;
}

public System.Collections.Generic.IList<Club_lecEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Club_lecEN> list = null;

        list = _IClub_lecCAD.ReadAll (first, size);
        return list;
}
}
}
