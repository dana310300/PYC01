using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REP001.Comun.WebAPI.MVC.Controllers
{
   public class HttpResponseMessage<T>
    {
        private Models.Person person;
        private System.Net.HttpStatusCode httpStatusCode;

       public HttpResponseMessage(Models.Person person, System.Net.HttpStatusCode httpStatusCode)
       {
           // TODO: Complete member initialization
           this.person = person;
           this.httpStatusCode = httpStatusCode;
       }
    }
}
