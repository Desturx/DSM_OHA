
using System;
// Definición clase UsuarioEN
namespace BookReViewGenNHibernate.EN.BookReview
{
public partial class UsuarioEN
{
/**
 *	Atributo usuarioID
 */
private int usuarioID;



/**
 *	Atributo password
 */
private String password;



/**
 *	Atributo mail
 */
private string mail;



/**
 *	Atributo fotoperfil
 */
private string fotoperfil;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo solicitudesRealizadas
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.SolicitudEN> solicitudesRealizadas;



/**
 *	Atributo solicitudesRecibidas
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.SolicitudEN> solicitudesRecibidas;



/**
 *	Atributo clubs
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> clubs;



/**
 *	Atributo pasarelaPago
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.CompraEN> pasarelaPago;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> comentario;



/**
 *	Atributo libros
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> libros;



/**
 *	Atributo librosCreado
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> librosCreado;



/**
 *	Atributo dineroventa
 */
private double dineroventa;



/**
 *	Atributo puntuacion
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.PuntuacionEN> puntuacion;



/**
 *	Atributo listaTipo
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ListaEN> listaTipo;






public virtual int UsuarioID {
        get { return usuarioID; } set { usuarioID = value;  }
}



public virtual String Password {
        get { return password; } set { password = value;  }
}



public virtual string Mail {
        get { return mail; } set { mail = value;  }
}



public virtual string Fotoperfil {
        get { return fotoperfil; } set { fotoperfil = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.SolicitudEN> SolicitudesRealizadas {
        get { return solicitudesRealizadas; } set { solicitudesRealizadas = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.SolicitudEN> SolicitudesRecibidas {
        get { return solicitudesRecibidas; } set { solicitudesRecibidas = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> Clubs {
        get { return clubs; } set { clubs = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.CompraEN> PasarelaPago {
        get { return pasarelaPago; } set { pasarelaPago = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> Libros {
        get { return libros; } set { libros = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> LibrosCreado {
        get { return librosCreado; } set { librosCreado = value;  }
}



public virtual double Dineroventa {
        get { return dineroventa; } set { dineroventa = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.PuntuacionEN> Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ListaEN> ListaTipo {
        get { return listaTipo; } set { listaTipo = value;  }
}





public UsuarioEN()
{
        solicitudesRealizadas = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.SolicitudEN>();
        solicitudesRecibidas = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.SolicitudEN>();
        clubs = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.Club_lecEN>();
        pasarelaPago = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.CompraEN>();
        comentario = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.ComentarioEN>();
        libros = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.LibroEN>();
        librosCreado = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.LibroEN>();
        puntuacion = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.PuntuacionEN>();
        listaTipo = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.ListaEN>();
}



public UsuarioEN(int usuarioID, String password, string mail, string fotoperfil, string nombre, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.SolicitudEN> solicitudesRealizadas, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.SolicitudEN> solicitudesRecibidas, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> clubs, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.CompraEN> pasarelaPago, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> comentario, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> libros, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> librosCreado, double dineroventa, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.PuntuacionEN> puntuacion, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ListaEN> listaTipo
                 )
{
        this.init (UsuarioID, password, mail, fotoperfil, nombre, solicitudesRealizadas, solicitudesRecibidas, clubs, pasarelaPago, comentario, libros, librosCreado, dineroventa, puntuacion, listaTipo);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (UsuarioID, usuario.Password, usuario.Mail, usuario.Fotoperfil, usuario.Nombre, usuario.SolicitudesRealizadas, usuario.SolicitudesRecibidas, usuario.Clubs, usuario.PasarelaPago, usuario.Comentario, usuario.Libros, usuario.LibrosCreado, usuario.Dineroventa, usuario.Puntuacion, usuario.ListaTipo);
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
        UsuarioEN t = obj as UsuarioEN;
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
