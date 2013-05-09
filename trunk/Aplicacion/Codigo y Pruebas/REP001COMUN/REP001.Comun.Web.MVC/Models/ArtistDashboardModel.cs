using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REP001.Comun.Web.MVC.Models
{
    public class ArtistDashboardModel
    {
        public List<Alert> NewsFeed { get; set; }
        public List<CollaborationSpace> CollaborationSpace { get; set; }
        public List<PlayListItem> ArtistSongs { get; set; }
        public List<Tast> Tasks { get; set; }

        [Display(Name="Member Since")]
        public DateTime AccountCreateDate { get; set; }
        [Display(Name = "Profile Last Viewed")]
        public DateTime ProfileLastViewedDate { get; set; }
        [Display(Name = "Profile Bookmark")]
        public string ProfileBookmark { get; set; }
        public string AvatarURL { get; set; }
        public string ArtistName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Tast {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
    public class PlayListItem {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Autor { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class Alert {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
    public class CollaborationSpace {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}