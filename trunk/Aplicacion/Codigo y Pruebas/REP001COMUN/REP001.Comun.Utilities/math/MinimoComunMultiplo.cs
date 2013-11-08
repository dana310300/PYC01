using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP001.Comun.Utilities.math
{
    public class MinimoComunMultiplo
    {
        public Hashtable CalcularMinimos(List<int> numbers)
        {

            var results = new Hashtable();

            foreach ( var number in numbers ) {
                int count = 2;
                int numberAux = number;
                var minimos = new Dictionary<int, int>();

                while ( numberAux > 1 ) {
                    if ( (numberAux % count) == 0 ) {
                       // Console.WriteLine(string.Format("min {0}={1}", numberAux, count));
                        numberAux = numberAux / count;
                        if ( minimos.ContainsKey(count) ) {
                            minimos[count]++;
                        }
                        else {
                            minimos[count] = 1;
                        }
                    }
                    else {
                        count++;
                    }
                }
                results.Add(number.ToString(),minimos);
            }

            return results;
        }

        public double CalcularMinimoComunMultiplo(List<int> numbers)
        {
            Hashtable minimos = CalcularMinimos(numbers);
            var result = new Dictionary<int, int>();
            foreach ( DictionaryEntry min in minimos ) 
            {
                var dic = (Dictionary<int, int>)min.Value;
                foreach ( KeyValuePair<int, int> i in dic ) 
                {
                    int max = i.Value;
                    if ( !result.ContainsKey(i.Key) ) { result[i.Key] = i.Value; }
                    else {
                        var aux = (int)result[i.Key];
                        if ( max > aux ) { result[i.Key] = max; }
                    }
                }
            }
            double total = 1;
            foreach( KeyValuePair<int, int> entry in result) {
                int index = entry.Value;
                int val = entry.Key;
                //Console.WriteLine(string.Format("{0} {1}", val, index));
                var mul = Math.Pow(val, index);
                total = total * mul;
            }
           // Console.WriteLine(total);
            return total;
        }
    }
}
