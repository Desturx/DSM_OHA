
using System;
// Definición clase ListaEN
namespace BookReViewGenNHibernate.EN.BookReview
{
public partial class ListaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo enlistado
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> enlistado;



/**
 *	Atributo tipo
 */
private BookReViewGenNHibernate.Enumerated.BookReview.TipolistaEnum tipo;



/**
 *	Atributo duenyoLista
 */
private BookReViewGenNHibernate.EN.BookReview.UsuarioEN duenyoLista;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> Enlistado {
        get { return enlistado; } set { enlistado = value;  }
}



public virtual BookReViewGenNHibernate.Enumerated.BookReview.TipolistaEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual BookReViewGenNHibernate.EN.BookReview.UsuarioEN DuenyoLista {
        get { return duenyoLista; } set { duenyoLista = value;  }
}





public ListaEN()
{
        enlistado = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.LibroEN>();
}



public ListaEN(int id, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> enlistado, BookReViewGenNHibernate.Enumerated.BookReview.TipolistaEnum tipo, BookReViewGenNHibernate.EN.BookReview.UsuarioEN duenyoLista
               )
{
        this.init (Id, enlistado, tipo, duenyoLista);
}


public ListaEN(ListaEN lista)
{
        this.init (Id, lista.Enlistado, lista.Tipo, lista.DuenyoLista);
}

private void init (int id
                   , System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> enlistado, BookReViewGenNHibernate.Enumerated.BookReview.TipolistaEnum tipo, BookReViewGenNHibernate.EN.BookReview.UsuarioEN duenyoLista)
{
        this.Id = id;


        this.Enlistado = enlistado;

        this.Tipo = tipo;

        this.DuenyoLista = duenyoLista;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ListaEN t = obj as ListaEN;
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
