
using System;
using BookReViewGenNHibernate.EN.BookReview;

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial interface ILibroCAD
{
LibroEN ReadOIDDefault (int libroID
                        );

void ModifyDefault (LibroEN libro);

System.Collections.Generic.IList<LibroEN> ReadAllDefault (int first, int size);



void Modify (LibroEN libro);


void BorrarLibro (int libroID
                  );


int PublicarLibro (LibroEN libro);

void PuntuarLibro (LibroEN libro);


System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> FiltrarListaLectura ();


LibroEN ReadOID (int libroID
                 );


System.Collections.Generic.IList<LibroEN> ReadAll (int first, int size);
}
}
