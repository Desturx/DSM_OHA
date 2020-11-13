
using System;
// Definición clase CompraEN
namespace BookReViewGenNHibernate.EN.BookReview
{
public partial class CompraEN
{
/**
 *	Atributo compraID
 */
private int compraID;



/**
 *	Atributo comprador
 */
private BookReViewGenNHibernate.EN.BookReview.UsuarioEN comprador;



/**
 *	Atributo solicitante
 */
private BookReViewGenNHibernate.EN.BookReview.LibroEN solicitante;



/**
 *	Atributo tipo_pago
 */
private string tipo_pago;



/**
 *	Atributo infotarjeta
 */
private string infotarjeta;



/**
 *	Atributo fechaped
 */
private Nullable<DateTime> fechaped;



/**
 *	Atributo terminal
 */
private string terminal;



/**
 *	Atributo comercio
 */
private string comercio;






public virtual int CompraID {
        get { return compraID; } set { compraID = value;  }
}



public virtual BookReViewGenNHibernate.EN.BookReview.UsuarioEN Comprador {
        get { return comprador; } set { comprador = value;  }
}



public virtual BookReViewGenNHibernate.EN.BookReview.LibroEN Solicitante {
        get { return solicitante; } set { solicitante = value;  }
}



public virtual string Tipo_pago {
        get { return tipo_pago; } set { tipo_pago = value;  }
}



public virtual string Infotarjeta {
        get { return infotarjeta; } set { infotarjeta = value;  }
}



public virtual Nullable<DateTime> Fechaped {
        get { return fechaped; } set { fechaped = value;  }
}



public virtual string Terminal {
        get { return terminal; } set { terminal = value;  }
}



public virtual string Comercio {
        get { return comercio; } set { comercio = value;  }
}





public CompraEN()
{
}



public CompraEN(int compraID, BookReViewGenNHibernate.EN.BookReview.UsuarioEN comprador, BookReViewGenNHibernate.EN.BookReview.LibroEN solicitante, string tipo_pago, string infotarjeta, Nullable<DateTime> fechaped, string terminal, string comercio
                )
{
        this.init (CompraID, comprador, solicitante, tipo_pago, infotarjeta, fechaped, terminal, comercio);
}


public CompraEN(CompraEN compra)
{
        this.init (CompraID, compra.Comprador, compra.Solicitante, compra.Tipo_pago, compra.Infotarjeta, compra.Fechaped, compra.Terminal, compra.Comercio);
}

private void init (int compraID
                   , BookReViewGenNHibernate.EN.BookReview.UsuarioEN comprador, BookReViewGenNHibernate.EN.BookReview.LibroEN solicitante, string tipo_pago, string infotarjeta, Nullable<DateTime> fechaped, string terminal, string comercio)
{
        this.CompraID = compraID;


        this.Comprador = comprador;

        this.Solicitante = solicitante;

        this.Tipo_pago = tipo_pago;

        this.Infotarjeta = infotarjeta;

        this.Fechaped = fechaped;

        this.Terminal = terminal;

        this.Comercio = comercio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CompraEN t = obj as CompraEN;
        if (t == null)
                return false;
        if (CompraID.Equals (t.CompraID))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.CompraID.GetHashCode ();
        return hash;
}
}
}
