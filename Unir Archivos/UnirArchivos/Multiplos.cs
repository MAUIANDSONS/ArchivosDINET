using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnirArchivos
{
    class Multiplos
    {

        public bool Comprobar(string numeroorden, StreamReader pedidodet)

        {
            bool multiplo;
            string lineaordendet = pedidodet.ReadLine();
            lineaordendet = lineaordendet.Replace(",", ".");

            while (lineaordendet != null)
            {

                string cajas;
                lineaordendet = lineaordendet.Replace("\"", "");
                string numeroordendet = lineaordendet.Substring(1, 10);
                string decimales;
                if (numeroorden.Equals(numeroordendet))
                {
                    
                    cajas = lineaordendet.Substring(31, 14);
                    int indice = cajas.IndexOf(".")+1;
                    

                    decimales = cajas.Substring(indice).Trim();
                    if (decimales.Equals("00"))
                    
                    {

                        multiplo = true;
                    }

                    else 
                    
                    {
                        return false;
                    }

                    
                }
                lineaordendet = pedidodet.ReadLine();

            }

            pedidodet.Close();
            return true ;
        
        
        
        }


    }
}
