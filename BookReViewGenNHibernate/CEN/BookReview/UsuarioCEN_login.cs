
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using BookReViewGenNHibernate.Exceptions;
using BookReViewGenNHibernate.EN.BookReview;
using BookReViewGenNHibernate.CAD.BookReview;


/*PROTECTED REGION ID(usingBookReViewGenNHibernate.CEN.BookReview_Usuario_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace BookReViewGenNHibernate.CEN.BookReview
{
public partial class UsuarioCEN
{
public string Login (string p_mail, string p_password)
{
        /*PROTECTED REGION ID(BookReViewGenNHibernate.CEN.BookReview_Usuario_login) ENABLED START*/
        string result = null;

        IList<UsuarioEN> listaEn = GetUsuarioByEmail (p_mail);

        if (listaEn.Count > 0) {
                UsuarioEN en = listaEn [0];
                if (en.Password.Equals (Utils.Util.GetEncondeMD5 (p_password)))
                        result = this.GetToken (en.UsuarioID);
        }



        return result;
        /*PROTECTED REGION END*/
}
}
}
