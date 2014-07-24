using System;
using Tamir.SharpSsh;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Configuration;

namespace UnirArchivos
{
    class Program
    {
        static void Main(string[] args)
        {

            Uniones union = new Uniones();
            union.CalcularDia();
            
            union.UnirArticulo();
            union.UnirOrden();
            union.UnirPedido();
            
            
            //SUBIR ARCHIVOS A FTP


            SFTP sftp = new SFTP();
            sftp.Conectar();

            if (File.Exists("Output\\WAI1052" + Tiempo.ObtenerFecha() + "00miss.txt"))
            {
                sftp.SubirArchivo("Output\\WAI1052" + Tiempo.ObtenerFecha() + "00miss.txt", "/ENTRADA/WAI1052" + Tiempo.ObtenerFecha() + "00miss.txt");
            }
            if (File.Exists("Output\\WPI1052" + Tiempo.ObtenerFecha() + "00miss.txt"))
            {
                sftp.SubirArchivo("Output\\WPI1052" + Tiempo.ObtenerFecha() + "00miss.txt", "/ENTRADA/WPI1052" + Tiempo.ObtenerFecha() + "00miss.txt");
            }
            if (File.Exists("Output\\WCI1052" + Tiempo.ObtenerFecha() + "00miss.txt"))
            {
                sftp.SubirArchivo("Output\\WCI1052" + Tiempo.ObtenerFecha() + "00miss.txt", "/ENTRADA/WCI1052" + Tiempo.ObtenerFecha() + "00miss.txt");
            }
            if (File.Exists("Output\\WDI1052" + Tiempo.ObtenerFecha() + "00miss.txt"))
            {
                sftp.SubirArchivo("Output\\WDI1052" + Tiempo.ObtenerFecha() + "00miss.txt", "/ENTRADA/WDI1052" + Tiempo.ObtenerFecha() + "00miss.txt");
            }
            if (File.Exists("Output\\WSI1052" + Tiempo.ObtenerFecha() + "00miss.txt"))
            {
                sftp.SubirArchivo("Output\\WSI1052" + Tiempo.ObtenerFecha() + "00miss.txt", "/ENTRADA/WSI1052" + Tiempo.ObtenerFecha() + "00miss.txt");
            }
            if (File.Exists("Output\\LPNI1052" + Tiempo.ObtenerFecha() + "00.txt"))
            {
                sftp.SubirArchivo("Output\\LPNI1052" + Tiempo.ObtenerFecha() + "00.txt", "/ENTRADA/LPNI1052" + Tiempo.ObtenerFecha() + "00.txt");
            }
            if (File.Exists("Output\\WVI1052" + Tiempo.ObtenerFecha() + "00miss.txt"))
            {
                sftp.SubirArchivo("Output\\WVI1052" + Tiempo.ObtenerFecha() + "00miss.txt", "/ENTRADA/WVI1052" + Tiempo.ObtenerFecha() + "00miss.txt");
            }
            
            sftp.CerrarConexion();
        }
    }
}
