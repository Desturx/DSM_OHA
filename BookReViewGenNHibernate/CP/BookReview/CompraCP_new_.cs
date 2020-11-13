
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using BookReViewGenNHibernate.EN.BookReview;
using BookReViewGenNHibernate.CAD.BookReview;
using BookReViewGenNHibernate.CEN.BookReview;



/*PROTECTED REGION ID(usingBookReViewGenNHibernate.CP.BookReview_Compra_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace BookReViewGenNHibernate.CP.BookReview
{
public partial class CompraCP : BasicCP
{
public BookReViewGenNHibernate.EN.BookReview.CompraEN New_ (int p_comprador, int p_solicitante, string p_tipo_pago, string p_infotarjeta, Nullable<DateTime> p_fechaped, string p_terminal, string p_comercio)
{
        /*PROTECTED REGION ID(BookReViewGenNHibernate.CP.BookReview_Compra_new_) ENABLED START*/

        ICompraCAD compraCAD = null;
        CompraCEN compraCEN = null;
        UsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;
        LibroCAD libroCAD = null;
        LibroCEN libroCEN = null;

        BookReViewGenNHibernate.EN.BookReview.CompraEN result = null;


        try
        {
                SessionInitializeTransaction ();
                compraCAD = new CompraCAD (session);
                compraCEN = new  CompraCEN (compraCAD);

                // Para modificar el usuario y el libro
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioCAD);

                libroCAD = new LibroCAD (session);
                libroCEN = new LibroCEN (libroCAD);

                int oid;
                //Initialized CompraEN
                CompraEN compraEN;
                compraEN = new CompraEN ();

                if (p_comprador != -1) {
                        compraEN.Comprador = new BookReViewGenNHibernate.EN.BookReview.UsuarioEN ();
                        compraEN.Comprador.UsuarioID = p_comprador;
                }


                if (p_solicitante != -1) {
                        compraEN.Solicitante = new BookReViewGenNHibernate.EN.BookReview.LibroEN ();
                        compraEN.Solicitante.LibroID = p_solicitante;
                }

                compraEN.Tipo_pago = p_tipo_pago;

                compraEN.Infotarjeta = p_infotarjeta;

                compraEN.Fechaped = p_fechaped;

                compraEN.Terminal = p_terminal;

                compraEN.Comercio = p_comercio;

                //Call to CompraCAD

                oid = compraCAD.New_ (compraEN);

                // Ahora modificamos los valores
                // Primero el del usuario. (sumarle el precio del libro al total que ha ganado
                // Para eso recuperamos el usuario actual primero
                LibroEN libroEN = libroCEN.ReadOID (compraEN.Solicitante.LibroID); // Para eso recuperamos el libro actual primero
                UsuarioEN usuEN = usuarioCEN.ReadOID (libroEN.Creador.UsuarioID);

                usuEN.Dineroventa += libroEN.Precio;

                usuarioCAD.ModifyDefault (usuEN);


                // Ahora el del libro (saber la cantidad de compras que se han realidado para ese libro)

                // libroEN = libroCEN.ReadOID(compraEN.Solicitante.LibroID); // Para eso recuperamos el libro actual primero
                libroEN.Compras += 1; // le sumamos 1 a la cantidad de compras.
                libroCAD.ModifyDefault (libroEN);
                result = compraCAD.ReadOIDDefault (oid);




                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
