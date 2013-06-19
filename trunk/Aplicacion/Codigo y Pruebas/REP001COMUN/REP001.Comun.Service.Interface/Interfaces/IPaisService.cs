using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REP001.Comun.BO;



namespace REP001.Comun.Service.Interface
{
   public interface IPaisService
    {
      Pais Create(Pais p);

       void Delete(Pais p);

       Pais Retrieve(Pais p);

       void Edit(Pais p);

       void Dispose();

       List<Pais> RetrievePaises();

       List<Pais> RetrievePaises(Pais p);
    }
}
