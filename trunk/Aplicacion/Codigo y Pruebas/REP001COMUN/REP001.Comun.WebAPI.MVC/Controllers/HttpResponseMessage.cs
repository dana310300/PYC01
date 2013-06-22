using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using REP001.Comun.BO;

namespace REP001.Comun.WebAPI.MVC.Controllers
{
   public class HttpResponseMessage<T>
    {
        private Person person;
        private System.Net.HttpStatusCode httpStatusCode;
        //private Person person1;

       public HttpResponseMessage(Person person, System.Net.HttpStatusCode httpStatusCode)
       {
           // TODO: Complete member initialization
           this.person = person;
           this.httpStatusCode = httpStatusCode;
       }

       //public HttpResponseMessage(Person person1, System.Net.HttpStatusCode httpStatusCode)
       //{
       //    // TODO: Complete member initialization
       //    this.person1 = person1;
       //    this.httpStatusCode = httpStatusCode;
       //}
    }
}
