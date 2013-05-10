using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using REP001.Comun.Web.MVC.Models;

namespace REP001.Comun.Web.MVC.Controllers
{
    public class ArtistDashboardController : Controller
    {
        //
        // GET: /ArtistDashboard/
        List<ArtistDashboardModel> ls;
        public ArtistDashboardController() { 
        ls = new List<ArtistDashboardModel>();

        ArtistDashboardModel artistdashboardModel = new ArtistDashboardModel();
        artistdashboardModel.ArtistName = "Artist";
        artistdashboardModel.ArtistSongs = new List<PlayListItem>();
        artistdashboardModel.AvatarURL = "../Images/orderedList0.png";
        artistdashboardModel.ProfileBookmark = "BOOKMARK1";
        artistdashboardModel.ArtistFullName = "Robiiieee Williams";
        artistdashboardModel.ArtistID = Guid.NewGuid();
        for (int i = 0; i < 10; i++)
        {
            artistdashboardModel.ArtistSongs.Add(new PlayListItem
            {
                ID = i,
                Name = "Escapologie" + i,
                FechaRegistro = DateTime.Now,
                Song = new Song { ID = i, Name = "Love Supreme" + i, Autor = "Robbie W." + 1, FechaRegistro = DateTime.Now }
            });
        }

        ls.Add(artistdashboardModel);

        }

        public ActionResult Index()
        {

            //ArtistDashboardModel artistdashboardModel2 = new ArtistDashboardModel();
            //artistdashboardModel2.ArtistName = "Artist";
            //artistdashboardModel2.ArtistSongs = new List<PlayListItem>();
            //artistdashboardModel2.AvatarURL = "../Images/orderedList0.png";
            //artistdashboardModel2.ProfileBookmark = "BOOKMARK1";
            //artistdashboardModel2.ArtistFullName = "Robiiieee Williams2";
            //for (int i = 0; i < 10; i++)
            //{
            //    artistdashboardModel2.ArtistSongs.Add(new PlayListItem
            //    {
            //        ID = i,
            //        Name = "Escapologie" + i,
            //        FechaRegistro = DateTime.Now,
            //        Song = new Song { ID = i, Name = "Love Supreme" + i, Autor = "Robbie W." + 1, FechaRegistro = DateTime.Now }
            //    });
            //}
            //ls.Add(artistdashboardModel2);
            return View(ls);
        }

        public ActionResult ArtistInfo() {
            return PartialView("_ArtistInfoPartial", ls);
        }
    }
}
