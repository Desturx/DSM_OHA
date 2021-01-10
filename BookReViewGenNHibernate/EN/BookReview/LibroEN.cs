
using System;
// Definición clase LibroEN
namespace BookReViewGenNHibernate.EN.BookReview
{
public partial class LibroEN
{
/**
 *	Atributo libroID
 */
private int libroID;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo genero
 */
private string genero;



/**
 *	Atributo fechapubli
 */
private Nullable<DateTime> fechapubli;



/**
 *	Atributo idioma
 */
private string idioma;



/**
 *	Atributo portada
 */
private string portada;



/**
 *	Atributo puntuacion
 */
private double puntuacion;



/**
 *	Atributo enlacedecompra
 */
private string enlacedecompra;



/**
 *	Atributo paginas
 */
private int paginas;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo solicitudesRealizada
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.CompraEN> solicitudesRealizada;



/**
 *	Atributo listainfo
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ListaEN> listainfo;



/**
 *	Atributo opinion
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> opinion;



/**
 *	Atributo usuarios
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.UsuarioEN> usuarios;



/**
 *	Atributo creador
 */
private BookReViewGenNHibernate.EN.BookReview.UsuarioEN creador;



/**
 *	Atributo clublibro
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> clublibro;



/**
 *	Atributo puntuacion_0
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.PuntuacionEN> puntuacion_0;



/**
 *	Atributo compras
 */
private int compras;



/**
 *	Atributo aut_lib
 */
private BookReViewGenNHibernate.EN.BookReview.AutorEN aut_lib;






public virtual int LibroID {
        get { return libroID; } set { libroID = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Genero {
        get { return genero; } set { genero = value;  }
}



public virtual Nullable<DateTime> Fechapubli {
        get { return fechapubli; } set { fechapubli = value;  }
}



public virtual string Idioma {
        get { return idioma; } set { idioma = value;  }
}



public virtual string Portada {
        get { return portada; } set { portada = value;  }
}



public virtual double Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual string Enlacedecompra {
        get { return enlacedecompra; } set { enlacedecompra = value;  }
}



public virtual int Paginas {
        get { return paginas; } set { paginas = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.CompraEN> SolicitudesRealizada {
        get { return solicitudesRealizada; } set { solicitudesRealizada = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ListaEN> Listainfo {
        get { return listainfo; } set { listainfo = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> Opinion {
        get { return opinion; } set { opinion = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.UsuarioEN> Usuarios {
        get { return usuarios; } set { usuarios = value;  }
}



public virtual BookReViewGenNHibernate.EN.BookReview.UsuarioEN Creador {
        get { return creador; } set { creador = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> Clublibro {
        get { return clublibro; } set { clublibro = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.PuntuacionEN> Puntuacion_0 {
        get { return puntuacion_0; } set { puntuacion_0 = value;  }
}



public virtual int Compras {
        get { return compras; } set { compras = value;  }
}



public virtual BookReViewGenNHibernate.EN.BookReview.AutorEN Aut_lib {
        get { return aut_lib; } set { aut_lib = value;  }
}





public LibroEN()
{
        solicitudesRealizada = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.CompraEN>();
        listainfo = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.ListaEN>();
        opinion = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.ComentarioEN>();
        usuarios = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.UsuarioEN>();
        clublibro = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.Club_lecEN>();
        puntuacion_0 = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.PuntuacionEN>();
}



public LibroEN(int libroID, string nombre, string genero, Nullable<DateTime> fechapubli, string idioma, string portada, double puntuacion, string enlacedecompra, int paginas, double precio, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.CompraEN> solicitudesRealizada, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ListaEN> listainfo, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> opinion, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.UsuarioEN> usuarios, BookReViewGenNHibernate.EN.BookReview.UsuarioEN creador, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> clublibro, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.PuntuacionEN> puntuacion_0, int compras, BookReViewGenNHibernate.EN.BookReview.AutorEN aut_lib
               )
{
        this.init (LibroID, nombre, genero, fechapubli, idioma, portada, puntuacion, enlacedecompra, paginas, precio, solicitudesRealizada, listainfo, opinion, usuarios, creador, clublibro, puntuacion_0, compras, aut_lib);
}


public LibroEN(LibroEN libro)
{
        this.init (LibroID, libro.Nombre, libro.Genero, libro.Fechapubli, libro.Idioma, libro.Portada, libro.Puntuacion, libro.Enlacedecompra, libro.Paginas, libro.Precio, libro.SolicitudesRealizada, libro.Listainfo, libro.Opinion, libro.Usuarios, libro.Creador, libro.Clublibro, libro.Puntuacion_0, libro.Compras, libro.Aut_lib);
}

private void init (int libroID
                   , string nombre, string genero, Nullable<DateTime> fechapubli, string idioma, string portada, double puntuacion, string enlacedecompra, int paginas, double precio, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.CompraEN> solicitudesRealizada, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ListaEN> listainfo, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.ComentarioEN> opinion, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.UsuarioEN> usuarios, BookReViewGenNHibernate.EN.BookReview.UsuarioEN creador, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.Club_lecEN> clublibro, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.PuntuacionEN> puntuacion_0, int compras, BookReViewGenNHibernate.EN.BookReview.AutorEN aut_lib)
{
        this.LibroID = libroID;


        this.Nombre = nombre;

        this.Genero = genero;

        this.Fechapubli = fechapubli;

        this.Idioma = idioma;

        this.Portada = portada;

        this.Puntuacion = puntuacion;

        this.Enlacedecompra = enlacedecompra;

        this.Paginas = paginas;

        this.Precio = precio;

        this.SolicitudesRealizada = solicitudesRealizada;

        this.Listainfo = listainfo;

        this.Opinion = opinion;

        this.Usuarios = usuarios;

        this.Creador = creador;

        this.Clublibro = clublibro;

        this.Puntuacion_0 = puntuacion_0;

        this.Compras = compras;

        this.Aut_lib = aut_lib;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LibroEN t = obj as LibroEN;
        if (t == null)
                return false;
        if (LibroID.Equals (t.LibroID))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.LibroID.GetHashCode ();
        return hash;
}
}
}
