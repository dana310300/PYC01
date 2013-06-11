using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace REP001.Comun.BO
{
    public class Person:IValidatableObject
    {
        public long? ID { get; set; }

        [Required]
        [StringLength(100,MinimumLength=2)]
        public string Name { get; set; }

        [DataType(DataType.DateTime,ErrorMessage="Fecha de nacimiento incorrecta")]
        public DateTime? DateBird { get; set; }

        public int? Age { get { return ((int)((DateTime.Today.AddYears(1) - (DateTime)DateBird).TotalDays/ 365) - 1); } }

        [Required]
        [StringLength(100,MinimumLength=2,ErrorMessage="El apellido debe tener longitud minuma de dos caracteres")]
        public string LastName { get; set; }

        [Required]
        public string ImgDir { get; set; }

        public byte[] Img { get; set; }

        [RegularExpression (@"(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})")]
        public string Email { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name == Email) { 
                yield return new ValidationResult("Error",new[] {"Name","Email"});
            }
        }
    }
}
