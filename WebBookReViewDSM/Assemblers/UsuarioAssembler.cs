using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReViewGenNHibernate.EN.BookReview;
using WebBookReViewDSM.Models;

namespace WebBookReViewDSM.Assemblers
{
    public class UsuarioAssembler
    {

        public UsuarioViewModel ConvertENToModelUI(UsuarioEN en)
        {
            UsuarioViewModel usu = new UsuarioViewModel();
            usu.libros = en.Libros;
            usu.usuarioID = en.UsuarioID;
            usu.password = en.Password;
            usu.fotoperfil = en.Fotoperfil;
            usu.mail = en.Mail;
            usu.nombre = en.Nombre;

            return usu;
        }

        public IList<UsuarioViewModel> ConvertListENToModel(IList<UsuarioEN> ens)
        {

            IList<UsuarioViewModel> usuarios = new List<UsuarioViewModel>();
            foreach (UsuarioEN en in ens)
            {
                usuarios.Add(ConvertENToModelUI(en));

            }
            return usuarios;
        }

    }
}