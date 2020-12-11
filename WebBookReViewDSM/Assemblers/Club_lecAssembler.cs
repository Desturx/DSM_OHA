using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReViewGenNHibernate.EN.BookReview;
using WebBookReViewDSM.Models;

namespace WebBookReViewDSM.Assemblers
{
    public class Club_lecAssembler
    {

        public Club_lecViewModel ConvertEnToModelUI(Club_lecEN en)
        {
            Club_lecViewModel club = new Club_lecViewModel();
            club.clubID = en.ClubID;
            club.mensualidad = (DateTime)en.Mensualidad;
            club.paginaActual = en.PaginaActual;
            club.estado = en.Estado;
            return club;
        }


        public IList<Club_lecViewModel> ConvertListENToModel(IList<Club_lecEN> ens)
        {
            IList<Club_lecViewModel> clubs = new List<Club_lecViewModel>();
            foreach (Club_lecEN cp in ens)
            {
                clubs.Add(ConvertEnToModelUI(cp));
            }

            return clubs;
        }
    }
}