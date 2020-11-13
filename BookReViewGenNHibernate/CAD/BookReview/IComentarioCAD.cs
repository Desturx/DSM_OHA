
using System;
using BookReViewGenNHibernate.EN.BookReview;

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int comentario
                             );

void ModifyDefault (ComentarioEN comentario);

System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size);



int New_ (ComentarioEN comentario);

void Modify (ComentarioEN comentario);


void Destroy (int comentario
              );


void BorrarComentario (int comentario
                       );


int PublicarComentario (ComentarioEN comentario);

System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> FiltrarAmigos ();


ComentarioEN ReadOID (int comentario
                      );


System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size);
}
}
