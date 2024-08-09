using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Enums
{
    public class Enums
    {
        public enum EstadoOperacion
        {
         
            [Description("PENDIENTE DE ANOTACIÓN")]
            Estado15 = 15,
            [Description("PENDIENTE DE TRANSFERENCIA")]
            Estado16 = 16,
        }
    }
}
