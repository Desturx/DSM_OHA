

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
 *      Definition of the class SolicitudCEN
 *
 */
public partial class SolicitudCEN
{
private ISolicitudCAD _ISolicitudCAD;

public SolicitudCEN()
{
        this._ISolicitudCAD = new SolicitudCAD ();
}

public SolicitudCEN(ISolicitudCAD _ISolicitudCAD)
{
        this._ISolicitudCAD = _ISolicitudCAD;
}

public ISolicitudCAD get_ISolicitudCAD ()
{
        return this._ISolicitudCAD;
}

public int CrearSolicitud (BookReViewGenNHibernate.Enumerated.BookReview.TiposolicitudEnum p_estado, int p_solicitante, int p_solicitado)
{
        SolicitudEN solicitudEN = null;
        int oid;

        //Initialized SolicitudEN
        solicitudEN = new SolicitudEN ();
        solicitudEN.Estado = p_estado;


        if (p_solicitante != -1) {
                // El argumento p_solicitante -> Property solicitante es oid = false
                // Lista de oids id
                solicitudEN.Solicitante = new BookReViewGenNHibernate.EN.BookReview.UsuarioEN ();
                solicitudEN.Solicitante.UsuarioID = p_solicitante;
        }


        if (p_solicitado != -1) {
                // El argumento p_solicitado -> Property solicitado es oid = false
                // Lista de oids id
                solicitudEN.Solicitado = new BookReViewGenNHibernate.EN.BookReview.UsuarioEN ();
                solicitudEN.Solicitado.UsuarioID = p_solicitado;
        }

        //Call to SolicitudCAD

        oid = _ISolicitudCAD.CrearSolicitud (solicitudEN);
        return oid;
}

public void Modify (int p_Solicitud_OID, BookReViewGenNHibernate.Enumerated.BookReview.TiposolicitudEnum p_estado)
{
        SolicitudEN solicitudEN = null;

        //Initialized SolicitudEN
        solicitudEN = new SolicitudEN ();
        solicitudEN.Id = p_Solicitud_OID;
        solicitudEN.Estado = p_estado;
        //Call to SolicitudCAD

        _ISolicitudCAD.Modify (solicitudEN);
}

public void Destroy (int id
                     )
{
        _ISolicitudCAD.Destroy (id);
}

public SolicitudEN ReadOID (int id
                            )
{
        SolicitudEN solicitudEN = null;

        solicitudEN = _ISolicitudCAD.ReadOID (id);
        return solicitudEN;
}

public System.Collections.Generic.IList<SolicitudEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SolicitudEN> list = null;

        list = _ISolicitudCAD.ReadAll (first, size);
        return list;
}
}
}
