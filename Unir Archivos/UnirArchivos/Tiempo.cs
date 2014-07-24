using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnirArchivos
{
    class Tiempo
    {

        public static String ObtenerFecha()

        {

            String dia = DateTime.Today.ToString().Substring(0, 2);
            String mes = DateTime.Today.ToString().Substring(3, 2);
            String año = DateTime.Today.ToString().Substring(6, 4);

            return año+mes+dia;
        
        }
    }
}
