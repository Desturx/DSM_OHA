
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

LibroEN ReadOID (int libroID
                 );


System.Collections.Generic.IList<LibroEN> ReadAll (int first, int size);


System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> ReadFilter (double ? p_precio);


System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> FiltroBestSeller (string p_mail);
}
}
