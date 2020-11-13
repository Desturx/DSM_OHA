
using System;
// Definición clase PuntuacionEN
namespace BookReViewGenNHibernate.EN.BookReview
{
public partial class PuntuacionEN
{
/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private BookReViewGenNHibernate.EN.BookReview.UsuarioEN usuario;



/**
 *	Atributo libro
 */
private BookReViewGenNHibernate.EN.BookReview.LibroEN libro;






public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual BookReViewGenNHibernate.EN.BookReview.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual BookReViewGenNHibernate.EN.BookReview.LibroEN Libro {
        get { return libro; } set { libro = value;  }
}





public PuntuacionEN()
{
}



public PuntuacionEN(int id, int puntuacion, BookReViewGenNHibernate.EN.BookReview.UsuarioEN usuario, BookReViewGenNHibernate.EN.BookReview.LibroEN libro
                    )
{
        this.init (Id, puntuacion, usuario, libro);
}


public PuntuacionEN(PuntuacionEN puntuacion)
{
        this.init (Id, puntuacion.Puntuacion, puntuacion.Usuario, puntuacion.Libro);
}

private void init (int id
                   , int puntuacion, BookReViewGenNHibernate.EN.BookReview.UsuarioEN usuario, BookReViewGenNHibernate.EN.BookReview.LibroEN libro)
{
        this.Id = id;


        this.Puntuacion = puntuacion;

        this.Usuario = usuario;

        this.Libro = libro;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PuntuacionEN t = obj as PuntuacionEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
