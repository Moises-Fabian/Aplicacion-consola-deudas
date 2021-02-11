using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDeudas
{
    public class DeudasBancarias:DeudasGenericas
    {
        public  byte cuotas { get; set; }

        public int montoCuota {get; set;}

        public int montoPagado { get; set; }
    }
}
