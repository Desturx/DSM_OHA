
using System;
using BookReViewGenNHibernate.EN.BookReview;

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial interface IPuntuacionCAD
{
PuntuacionEN ReadOIDDefault (int id
                             );

void ModifyDefault (PuntuacionEN puntuacion);

System.Collections.Generic.IList<PuntuacionEN> ReadAllDefault (int first, int size);



int New_ (PuntuacionEN puntuacion);

void Modify (PuntuacionEN puntuacion);


void Destroy (int id
              );
}
}
