
using System;
using BookReViewGenNHibernate.EN.BookReview;

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial interface IAutorCAD
{
AutorEN ReadOIDDefault (int autorID
                        );

void ModifyDefault (AutorEN autor);

System.Collections.Generic.IList<AutorEN> ReadAllDefault (int first, int size);



int New_ (AutorEN autor);

void Modify (AutorEN autor);


void Destroy (int autorID
              );


AutorEN ReadOID (int autorID
                 );


System.Collections.Generic.IList<AutorEN> ReadAll (int first, int size);
}
}
