
using System;
using BookReViewGenNHibernate.EN.BookReview;

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int usuarioID
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



int New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (int usuarioID
              );






UsuarioEN ReadOID (int usuarioID
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);


void AnyadirClub (int p_Usuario_OID, System.Collections.Generic.IList<int> p_clubs_OIDs);

void AnyadirLibro (int p_Usuario_OID, System.Collections.Generic.IList<int> p_libros_OIDs);

System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.UsuarioEN> ReadFilter ();


System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.UsuarioEN> GetUsuarioByEmail (string p_mail);
}
}
