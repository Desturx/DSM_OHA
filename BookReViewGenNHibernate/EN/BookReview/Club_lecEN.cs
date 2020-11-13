
using System;
// Definición clase Club_lecEN
namespace BookReViewGenNHibernate.EN.BookReview
{
public partial class Club_lecEN
{
/**
 *	Atributo clubID
 */
private int clubID;



/**
 *	Atributo mensualidad
 */
private Nullable<DateTime> mensualidad;



/**
 *	Atributo paginaActual
 */
private int paginaActual;



/**
 *	Atributo estado
 */
private bool estado;



/**
 *	Atributo lectores
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.UsuarioEN> lectores;



/**
 *	Atributo lectura
 */
private BookReViewGenNHibernate.EN.BookReview.LibroEN lectura;






public virtual int ClubID {
        get { return clubID; } set { clubID = value;  }
}



public virtual Nullable<DateTime> Mensualidad {
        get { return mensualidad; } set { mensualidad = value;  }
}



public virtual int PaginaActual {
        get { return paginaActual; } set { paginaActual = value;  }
}



public virtual bool Estado {
        get { return estado; } set { estado = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.UsuarioEN> Lectores {
        get { return lectores; } set { lectores = value;  }
}



public virtual BookReViewGenNHibernate.EN.BookReview.LibroEN Lectura {
        get { return lectura; } set { lectura = value;  }
}





public Club_lecEN()
{
        lectores = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.UsuarioEN>();
}



public Club_lecEN(int clubID, Nullable<DateTime> mensualidad, int paginaActual, bool estado, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.UsuarioEN> lectores, BookReViewGenNHibernate.EN.BookReview.LibroEN lectura
                  )
{
        this.init (ClubID, mensualidad, paginaActual, estado, lectores, lectura);
}


public Club_lecEN(Club_lecEN club_lec)
{
        this.init (ClubID, club_lec.Mensualidad, club_lec.PaginaActual, club_lec.Estado, club_lec.Lectores, club_lec.Lectura);
}

private void init (int clubID
                   , Nullable<DateTime> mensualidad, int paginaActual, bool estado, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.UsuarioEN> lectores, BookReViewGenNHibernate.EN.BookReview.LibroEN lectura)
{
        this.ClubID = clubID;


        this.Mensualidad = mensualidad;

        this.PaginaActual = paginaActual;

        this.Estado = estado;

        this.Lectores = lectores;

        this.Lectura = lectura;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        Club_lecEN t = obj as Club_lecEN;
        if (t == null)
                return false;
        if (ClubID.Equals (t.ClubID))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.ClubID.GetHashCode ();
        return hash;
}
}
}
