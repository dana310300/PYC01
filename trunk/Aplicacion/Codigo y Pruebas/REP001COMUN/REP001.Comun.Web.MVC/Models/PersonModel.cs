using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REP001.Comun.Web.MVC.Models
{
    public class PersonModel
    {
        public int ID { get; set; }

        [Required]
        [Display (Name="Nombre")]
        [StringLength(100,ErrorMessage="El nombre {0} debe ser al menos de {2} caracteres.",MinimumLength=6)]
        public string Name { get; set; }

        [Required]
        [Display(DateBird="FechaNacimiento")]
        public DateTime DateBird { get; set; }

        
        public int Age { get { return ((int)((DateBird - DateTime.Today).TotalDays / 365) - 1); } }
        public string Email { get; set; }
    }
}