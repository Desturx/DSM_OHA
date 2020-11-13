
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using BookReViewGenNHibernate.Exceptions;
using BookReViewGenNHibernate.EN.BookReview;
using BookReViewGenNHibernate.CAD.BookReview;
using BookReViewGenNHibernate.CEN.BookReview;



namespace BookReViewGenNHibernate.CP.BookReview
{
public partial class LibroCP : BasicCP
{
public LibroCP() : base ()
{
}

public LibroCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
