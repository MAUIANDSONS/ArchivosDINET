using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Tamir.SharpSsh;
using System.Collections;
using System.Threading;
using System.IO;
using Tamir.Streams;

namespace UnirArchivos
{
    class SFTP
    {
        private SshTransferProtocolBase sftp;
        public void SubirArchivo(String desde, String hasta)
        {
            //subir archivo
            sftp.Put(desde, hasta);
            Console.WriteLine("archivo publicado");
            Console.ReadLine();
        }   
        public void Conectar()
        {
            Sftp sftpcliente = new Sftp("200.48.15.199", "MAUI", "VRA63BFV");
            sftpcliente.Connect(22);
            Console.WriteLine("Conectado al servidor");
            Console.ReadLine();
            sftp = sftpcliente;
        }

        public void CerrarConexion()
        {
            sftp.Close();
        }
    }
}
