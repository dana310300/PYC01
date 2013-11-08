using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP001.Comun.AplicacionConsola
{
   public class CalculoMatematicos
    {

       public int NumeroCiclosEnEspirales(int espirales)
       {
           int index = 3;
           int numciclos = 0;
           while (index<=espirales)
           {
               numciclos++;
               index++;
               index++;
           }

           return numciclos;
       }

       public List<long> CalcularSumaDiagonales(int espirales)
       {
           int numciclos = NumeroCiclosEnEspirales(espirales);
           int indexbreak=0;
           const int incrementos = 8;
           List<long> results = null;
           long? lastNumber = null;
           for (int i = 1; i <= numciclos; i++)
           {
               indexbreak = indexbreak + 2;
               int totalNumeros = incrementos*i;


               lastNumber = lastNumber ?? 2;
               //Console.WriteLine(lastNumber);

               List<long> resultsAux = null;
               int indexbreakAux = 0;
               for (int j = 0; j <= totalNumeros; j++)
               {
                   if(resultsAux==null)
                       resultsAux=new List<long>();
                   else
                   {
                       indexbreakAux++;
                       if (indexbreakAux == indexbreak)
                       {
                           
                           resultsAux.Add((long) lastNumber);
                           //Console.WriteLine(lastNumber);
                           indexbreakAux = 0;
                           lastNumber++;
                       }
                       else
                       {
                           lastNumber++;
                       }
                   }
               }
               if(resultsAux!=null)
               foreach (long l in resultsAux)
               {
                   if (results == null) results = new List<long>();
                   results.Add(l);
               }
            

           }

           return results;
       }
    }
}
