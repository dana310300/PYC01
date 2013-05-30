using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace REP001.Comun.BO
{
  public static  class Personas
    {
     

      public static async Task<List<REP001.Comun.BO.Person>> GetPersons(){
          await Task.Delay(5000);
          return _GetPersons();
      }

      public static List<Person> _GetPersons() {
          Thread.Sleep(5000);
          return _GetAllPersons();
      }

      private static List<Person> _GetAllPersons()
      {
           List<Person> _people;
             _people = new List<Person>();
            _people.AddRange(new Person[]{
            new Person{ID=1,Name="Danielaaaaaaaaaaaaaaaaaaaaa",LastName="Avila",DateBird=DateTime.Today.AddDays(-27)},
            new Person{ID=2,Name="Angelina",LastName="Avila",DateBird=DateTime.Today.AddDays(-29)},
            new Person{ID=3,Name="Angelina",LastName="Avila",DateBird=DateTime.Today.AddDays(-21)}

            });
          return _people;
      }
     
    }
}
