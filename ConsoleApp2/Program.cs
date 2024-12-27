using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Hemos creado un programa que genere una estructura de filas y columnas
 * donde podamos introducir el nombre de los campos de cada columna y posteriormente
 * escribir datos asociados en cada fila
 */

namespace Ciclismo10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //vamos a escribir el nombre del archivo a crear
            Console.WriteLine("Escribe el nombre del archivo que vas a crear");
            string nombreArchivo = Console.ReadLine();
            //le tenemos asignada ya una ruta, a espera del nombre, con su formato
            string ruta = @"C:\Users\picap\Desktop\"+nombreArchivo+".txt";
            //iniciamos variables
            bool salida = false;
            int dorsal = 1;
            //llamamos a la función que nos crea el archivo
            Crear(ruta);
            Console.WriteLine("¿Qué tipo de vehiculo utilizan?");
            string vehiculo = Console.ReadLine();
            //llamamos función que nos crea el contenido del archivo
            CrearEstructura(ruta, vehiculo);
            //con un do/while hacemos un menú que nos permita escribir o salir
            do
            {
            Console.WriteLine("introduce una OPCIÓN:");
            Console.WriteLine("s para INTRODUCIR datos de corredor");
            Console.WriteLine("n para SALIR");
            string opcion = Console.ReadLine();
            switch (opcion) {
                case "s":
                        //llamamos al metodo que nos escribe los datos de los participantes
                    IntroducirDatos(ruta, dorsal, vehiculo);
                        dorsal++;
                    break;
                case "n":
                        //con el bool controlamos la salida del bucle
                    salida = true;
                    break;
                 
            }
            }
            while (!salida);

        }

        //este método crea el archivo y controla si está ya creado o no
        static void Crear(string ruta)
            {
            if (File.Exists(ruta)){ 
            Console.WriteLine("esta creado");
            }
            else
            {
            FileStream fs = File.Create(ruta);
                Console.WriteLine("creado!!!");
                fs.Close();
            }
           
            }
        //método que genera la estructura del contenido
        static void CrearEstructura(string ruta, string vehiculo) {
            //iniciamos un FileStream para controlar el archivo y qué podemos hacer con él
            FileStream F1 = new FileStream(ruta, FileMode.Open, FileAccess.Write);
            //iniciamos StreamWriter ya que vamos a escribir en el archivo
            StreamWriter f1StreamWriter = new StreamWriter(F1);
            
            f1StreamWriter.WriteLine("Nombre; Modelo "+vehiculo+"; Dorsal");

            f1StreamWriter.Close();
            F1.Close();   
        }
        //método que usamos para introducir datos de los participantes
        static void IntroducirDatos(string ruta, int dorsal, string vehiculo)
        {
            FileStream F2 = new FileStream(ruta, FileMode.Append);
            StreamWriter f2StreamWriter = new StreamWriter(F2);
            //metemos en variables los datos
            Console.WriteLine("Introduce Nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Introduce Modelo del "+vehiculo+":");
            string modelo = Console.ReadLine();     
            //usamos el StreamWriter para pintar los datos, usando ; como separadores y poder trabajar con los mismos
            f2StreamWriter.WriteLine(dorsal + ";" + nombre + ";" + modelo + ";");

            f2StreamWriter.Close();
            F2.Close();
        }
    }
}
