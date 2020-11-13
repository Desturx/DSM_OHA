
using System;
using BookReViewGenNHibernate.EN.BookReview;

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial interface ISolicitudCAD
{
SolicitudEN ReadOIDDefault (int id
                            );

void ModifyDefault (SolicitudEN solicitud);

System.Collections.Generic.IList<SolicitudEN> ReadAllDefault (int first, int size);



int CrearSolicitud (SolicitudEN solicitud);

void Modify (SolicitudEN solicitud);


void Destroy (int id
              );


SolicitudEN ReadOID (int id
                     );


System.Collections.Generic.IList<SolicitudEN> ReadAll (int first, int size);
}
}
