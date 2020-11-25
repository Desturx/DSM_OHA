
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using BookReViewGenNHibernate.Exceptions;
using BookReViewGenNHibernate.EN.BookReview;
using BookReViewGenNHibernate.CAD.BookReview;
using BookReViewGenNHibernate.Enumerated.BookReview;


/*PROTECTED REGION ID(usingBookReViewGenNHibernate.CEN.BookReview_Solicitud_aceptar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace BookReViewGenNHibernate.CEN.BookReview
{
public partial class SolicitudCEN
{
public void Aceptar (int p_oid)
{
        /*PROTECTED REGION ID(BookReViewGenNHibernate.CEN.BookReview_Solicitud_aceptar) ENABLED START*/

        SolicitudEN sol = _ISolicitudCAD.ReadOIDDefault (p_oid);

        sol.Estado = TiposolicitudEnum.aceptado;
        _ISolicitudCAD.ModifyDefault (sol);
        /*PROTECTED REGION END*/
}
}
}
