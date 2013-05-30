using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP001.Comun.BO
{
   public class Estado
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public Pais Pais { get; set; }
    }
}
