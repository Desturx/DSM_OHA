
using System;
using BookReViewGenNHibernate.EN.BookReview;

namespace BookReViewGenNHibernate.CAD.BookReview
{
public partial interface ICompraCAD
{
CompraEN ReadOIDDefault (int compraID
                         );

void ModifyDefault (CompraEN compra);

System.Collections.Generic.IList<CompraEN> ReadAllDefault (int first, int size);



int New_ (CompraEN compra);

void Modify (CompraEN compra);


void Destroy (int compraID
              );




CompraEN ReadOID (int compraID
                  );


System.Collections.Generic.IList<CompraEN> ReadAll (int first, int size);


int CreaCompra (CompraEN compra);
}
}
