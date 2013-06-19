using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP001.Comun.BO
{
    public class Ubicacion
    {
       public long? UbicacionID { get; set; }
       public DateTime FechaRegistro { get; set; }
       public bool Activo {get; set;}
       public Person Person { get; set; }
       public Pais Pais { get; set; }
       public Estado Estado { get; set; }
       public Ciudad Ciudad { get; set; }
       public Localidad Localidad { get; set; }

    }
}
