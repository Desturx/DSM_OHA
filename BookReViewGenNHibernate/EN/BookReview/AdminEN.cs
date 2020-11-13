
using System;
// Definición clase AdminEN
namespace BookReViewGenNHibernate.EN.BookReview
{
public partial class AdminEN                                                                        : BookReViewGenNHibernate.EN.BookReview.UsuarioEN


{
public AdminEN() : base ()
{
}



public AdminEN(int usuarioID,
               String password, string mail, string fotoperfil, string nombre, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.SolicitudEN> solicitudesRealizadas, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.SolicitudEN> solicitudesRecibidas, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> clubs, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.CompraEN> pasarelaPago, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> comentario, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> libros, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> librosCreado, double dineroventa, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.PuntuacionEN> puntuacion, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ListaEN> listaTipo
               )
{
        this.init (UsuarioID, password, mail, fotoperfil, nombre, solicitudesRealizadas, solicitudesRecibidas, clubs, pasarelaPago, comentario, libros, librosCreado, dineroventa, puntuacion, listaTipo);
}


public AdminEN(AdminEN admin)
{
        this.init (UsuarioID, admin.Password, admin.Mail, admin.Fotoperfil, admin.Nombre, admin.SolicitudesRealizadas, admin.SolicitudesRecibidas, admin.Clubs, admin.PasarelaPago, admin.Comentario, admin.Libros, admin.LibrosCreado, admin.Dineroventa, admin.Puntuacion, admin.ListaTipo);
}

private void init (int usuarioID
                   , String password, string mail, string fotoperfil, string nombre, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.SolicitudEN> solicitudesRealizadas, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.SolicitudEN> solicitudesRecibidas, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> clubs, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.CompraEN> pasarelaPago, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> comentario, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> libros, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> librosCreado, double dineroventa, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.PuntuacionEN> puntuacion, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ListaEN> listaTipo)
{
        this.UsuarioID = usuarioID;


        this.Password = password;

        this.Mail = mail;

        this.Fotoperfil = fotoperfil;

        this.Nombre = nombre;

        this.SolicitudesRealizadas = solicitudesRealizadas;

        this.SolicitudesRecibidas = solicitudesRecibidas;

        this.Clubs = clubs;

        this.PasarelaPago = pasarelaPago;

        this.Comentario = comentario;

        this.Libros = libros;

        this.LibrosCreado = librosCreado;

        this.Dineroventa = dineroventa;

        this.Puntuacion = puntuacion;

        this.ListaTipo = listaTipo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
        if (t == null)
                return false;
        if (UsuarioID.Equals (t.UsuarioID))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.UsuarioID.GetHashCode ();
        return hash;
}
}
}
