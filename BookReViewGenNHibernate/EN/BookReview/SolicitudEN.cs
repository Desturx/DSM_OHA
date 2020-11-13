
using System;
// Definición clase SolicitudEN
namespace BookReViewGenNHibernate.EN.BookReview
{
public partial class SolicitudEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estado
 */
private BookReViewGenNHibernate.Enumerated.BookReview.TiposolicitudEnum estado;



/**
 *	Atributo solicitante
 */
private BookReViewGenNHibernate.EN.BookReview.UsuarioEN solicitante;



/**
 *	Atributo solicitado
 */
private BookReViewGenNHibernate.EN.BookReview.UsuarioEN solicitado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual BookReViewGenNHibernate.Enumerated.BookReview.TiposolicitudEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual BookReViewGenNHibernate.EN.BookReview.UsuarioEN Solicitante {
        get { return solicitante; } set { solicitante = value;  }
}



public virtual BookReViewGenNHibernate.EN.BookReview.UsuarioEN Solicitado {
        get { return solicitado; } set { solicitado = value;  }
}





public SolicitudEN()
{
}



public SolicitudEN(int id, BookReViewGenNHibernate.Enumerated.BookReview.TiposolicitudEnum estado, BookReViewGenNHibernate.EN.BookReview.UsuarioEN solicitante, BookReViewGenNHibernate.EN.BookReview.UsuarioEN solicitado
                   )
{
        this.init (Id, estado, solicitante, solicitado);
}


public SolicitudEN(SolicitudEN solicitud)
{
        this.init (Id, solicitud.Estado, solicitud.Solicitante, solicitud.Solicitado);
}

private void init (int id
                   , BookReViewGenNHibernate.Enumerated.BookReview.TiposolicitudEnum estado, BookReViewGenNHibernate.EN.BookReview.UsuarioEN solicitante, BookReViewGenNHibernate.EN.BookReview.UsuarioEN solicitado)
{
        this.Id = id;


        this.Estado = estado;

        this.Solicitante = solicitante;

        this.Solicitado = solicitado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SolicitudEN t = obj as SolicitudEN;
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
