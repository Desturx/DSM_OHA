
using System;
// Definición clase AutorEN
namespace BookReViewGenNHibernate.EN.BookReview
{
public partial class AutorEN
{
/**
 *	Atributo autorID
 */
private int autorID;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo numLibros
 */
private int numLibros;



/**
 *	Atributo nacimiento
 */
private Nullable<DateTime> nacimiento;



/**
 *	Atributo fotoautor
 */
private string fotoautor;



/**
 *	Atributo obra
 */
private System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> obra;






public virtual int AutorID {
        get { return autorID; } set { autorID = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual int NumLibros {
        get { return numLibros; } set { numLibros = value;  }
}



public virtual Nullable<DateTime> Nacimiento {
        get { return nacimiento; } set { nacimiento = value;  }
}



public virtual string Fotoautor {
        get { return fotoautor; } set { fotoautor = value;  }
}



public virtual System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> Obra {
        get { return obra; } set { obra = value;  }
}





public AutorEN()
{
        obra = new System.Collections.Generic.List<BookReViewGenNHibernate.EN.BookReview.LibroEN>();
}



public AutorEN(int autorID, string nombre, int numLibros, Nullable<DateTime> nacimiento, string fotoautor, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> obra
               )
{
        this.init (AutorID, nombre, numLibros, nacimiento, fotoautor, obra);
}


public AutorEN(AutorEN autor)
{
        this.init (AutorID, autor.Nombre, autor.NumLibros, autor.Nacimiento, autor.Fotoautor, autor.Obra);
}

private void init (int autorID
                   , string nombre, int numLibros, Nullable<DateTime> nacimiento, string fotoautor, System.Collections.Generic.IList<BookReViewGenNHibernate.EN.BookReview.LibroEN> obra)
{
        this.AutorID = autorID;


        this.Nombre = nombre;

        this.NumLibros = numLibros;

        this.Nacimiento = nacimiento;

        this.Fotoautor = fotoautor;

        this.Obra = obra;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AutorEN t = obj as AutorEN;
        if (t == null)
                return false;
        if (AutorID.Equals (t.AutorID))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.AutorID.GetHashCode ();
        return hash;
}
}
}
