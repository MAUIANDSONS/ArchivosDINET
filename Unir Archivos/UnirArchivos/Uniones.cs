using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnirArchivos
{
    class Uniones
    {
        private String dia;
        private String mes;
        private String año;
        public void CalcularDia()

        {
            dia = DateTime.Today.ToString().Substring(0, 2);
            mes = DateTime.Today.ToString().Substring(3, 2);
            año = DateTime.Today.ToString().Substring(6, 4);
        
        }

        public void UnirOrden()

        {
        //UNIONES
            
            String lineaordencab;
            String lineaordendet;

            
            //UNION ORDEN COMPRA
             String nombreordencab = "ORDEN_COMPRA_CAB"+año+mes+dia+"00miss.txt";
             String nombreordendet = "ORDEN_COMPRA_DET" + año + mes + dia + "00miss.txt";
            
             if (File.Exists("Output\\" + nombreordencab))
             {
                 try
                 {
                     StreamWriter ordenjunta = new StreamWriter("Output\\WCI1052" + año + mes + dia + "00miss.txt");
                     //Pass the file path and file name to the StreamReader constructor
                     StreamReader ordencab = new StreamReader("Output\\" + nombreordencab);
                     //Read the first line of text
                     lineaordencab = ordencab.ReadLine();
                     //Continue to read until you reach end of file
                     while (lineaordencab != null)
                     {
                         lineaordencab = lineaordencab.Replace("\"", "");
                         //copiar linea cab
                         ordenjunta.WriteLine(lineaordencab);
                         String aprobada = lineaordencab.Substring(69, 2);
                         if (File.Exists("Output\\" + nombreordendet)&aprobada.Equals("AP"))
                         {
                             int i = 1;
                             StreamReader ordendet = new StreamReader("Output\\" + nombreordendet);

                             //Borrar comillas

                             string numeroordencab = lineaordencab.Substring(45, 10);

                             lineaordendet = ordendet.ReadLine();
                             lineaordendet = lineaordendet.Replace(",", ".");
                             while (lineaordendet != null)
                             {

                                 lineaordendet = lineaordendet.Replace("\"", "");
                                 string numeroordendet = lineaordendet.Substring(35, 10);

                                 if (numeroordencab.Equals(numeroordendet))
                                 {

                                     lineaordendet = lineaordendet.Substring(0, 35) + (i.ToString() + ".00000").PadRight(16, ' ') + lineaordendet.Substring(35);
                                     ordenjunta.WriteLine(lineaordendet);
                                     i++;

                                 }
                                 lineaordendet = ordendet.ReadLine();

                             }

                             ordendet.Close();
                         }
                                lineaordencab = ordencab.ReadLine(); 
                                
                             }
           
                             ordenjunta.Close();
                            //close the file
                            ordencab.Close();
 
                        }
 
                 catch (Exception e)
                 {
                     Console.WriteLine("Exception: " + e.Message);
                 }
                 finally
                 {
                     Console.WriteLine("Executing finally block.");
                 }
             }
        
        
        }

        public void UnirArticulo()

        {
            //UNION ARTICULO

            String lineaarticulocab;
            String lineaarticulodet;
            String nombrearticulocab = "ARTICULOS_CAB" + año + mes + dia + "00miss.txt";
            String nombrearticulodet = "ARTICULOS_DET" + año + mes + dia + "00miss.txt";
            if (File.Exists("Output\\" + nombrearticulocab) && File.Exists("Output\\" + nombrearticulodet))
            {
                try
                {

                    StreamWriter articulojunta = new StreamWriter("Output\\WAI1052" + Tiempo.ObtenerFecha() + "00miss.txt");


                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader articulocab = new StreamReader("Output\\" + nombrearticulocab);


                    //Read the first line of text
                    lineaarticulocab = articulocab.ReadLine();


                    //Continue to read until you reach end of file
                    while (lineaarticulocab != null)
                    {

                        StreamReader articulodet = new StreamReader("Output\\" + nombrearticulodet);

                        //Borrar comillas
                        lineaarticulocab = lineaarticulocab.Replace("\"", "");
                        //copiar linea cab
                        articulojunta.WriteLine(lineaarticulocab);

                        string numeroarticulocab = lineaarticulocab.Substring(1, 20);

                        lineaarticulodet = articulodet.ReadLine();

                        while (lineaarticulodet != null)
                        {

                            lineaarticulodet = lineaarticulodet.Replace("\"", "");
                            string numeroarticulodet = lineaarticulodet.Substring(1, 20);
                            if (numeroarticulocab.Equals(numeroarticulodet))
                            {
                                //copiar todos los det



                                articulojunta.WriteLine(lineaarticulodet);

                                if (lineaarticulodet.Substring(21, 3).Equals("CJ "))
                                {
                                    //Considerando COD_BARRAS largo 20
                                    articulojunta.WriteLine(lineaarticulodet.Substring(0, 21) + "UND" + lineaarticulodet.Substring(24, 43) + "SSS1         " + lineaarticulodet.Substring(80));

                                }

                                break;
                            }

                            lineaarticulodet = articulodet.ReadLine();
                        }

                        articulodet.Close();

                        lineaarticulocab = articulocab.ReadLine();

                        if (lineaarticulocab != null)
                        {
                            string nuevoarticulocab = lineaarticulocab.Substring(1, 20);
                            while (numeroarticulocab.Equals(nuevoarticulocab))
                            {
                                lineaarticulocab = articulocab.ReadLine();
                                nuevoarticulocab = lineaarticulocab.Substring(1, 20);
                            }
                        }

                    }

                    articulojunta.Close();
                    //close the file
                    articulocab.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        
        
        }


        public void UnirPedido()

        {
            //UNION PEDIDO

            String lineapedidocab;
            String lineapedidodet;
            String nombrepedidocab = "PEDIDOS_CAB" + año + mes + dia + "00miss.txt";
            String nombrepedidodet = "PEDIDOS_DET" + año + mes + dia + "00miss.txt";

            if (File.Exists("Output\\" + nombrepedidocab) && File.Exists("Output\\" + nombrepedidodet))
            {
                try
                {

                    StreamWriter pedidojunta = new StreamWriter("Output\\WPI1052" + Tiempo.ObtenerFecha() + "00miss.txt");
                    StreamWriter pedidorevisar = new StreamWriter("Output\\RevisarPedidos" + Tiempo.ObtenerFecha() + ".txt");

                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader pedidocab = new StreamReader("Output\\" + nombrepedidocab);


                    //Read the first line of text
                    lineapedidocab = pedidocab.ReadLine();


                    //Continue to read until you reach end of file
                    while (lineapedidocab != null)
                    {
                        int i = 1;
                        StreamReader pedidodet = new StreamReader("Output\\" + nombrepedidodet);
                        StreamReader pedidodet2 = new StreamReader("Output\\" + nombrepedidodet);
                        //Borrar comillas
                        lineapedidocab = lineapedidocab.Replace("\"", "");

                        string numeropedidocab = lineapedidocab.Substring(1, 10);
                        Multiplos multiplos = new Multiplos();

                        if (multiplos.Comprobar(numeropedidocab, pedidodet2))
                        {
                            //copiar linea cab
                            pedidojunta.WriteLine(lineapedidocab);
                            lineapedidodet = pedidodet.ReadLine();
                            while (lineapedidodet != null)
                            {
                                lineapedidodet = lineapedidodet.Replace("\"", "");
                                lineapedidodet = lineapedidodet.Replace(",", ".");
                                string numeropedidodet = lineapedidodet.Substring(1, 10);
                                if (numeropedidocab.Equals(numeropedidodet))
                                {
                                    pedidojunta.WriteLine(lineapedidodet.Substring(0, 131) + i.ToString().PadRight(5, ' ') + lineapedidodet.Substring(131));
                                    i++;
                                }
                                lineapedidodet = pedidodet.ReadLine();
                            }
                            pedidodet.Close();
                        }
                        else
                        {
                            pedidorevisar.WriteLine(lineapedidocab);
                        }
                        lineapedidocab = pedidocab.ReadLine();
                    }
                    pedidojunta.Close();
                    pedidorevisar.Close();
                    //close the file
                    pedidocab.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        }

    }
}
