using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ListaInteractiva
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List lista = new List();
            string opcion;

            do
            {
                Console.WriteLine("\n  ----- Menú -----");
                Console.WriteLine(" 1 Agregar elemento");
                Console.WriteLine(" 2 Eliminar elemento");
                Console.WriteLine(" 3 Mostrar Lista");
                Console.WriteLine(" 4 Cerrar Programa");
                Console.WriteLine("  ----------------");
                Console.Write("-> Elige una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {

                    case "1":
                        Console.Write("Ingresa el nombre del cliente: ");
                        string nombre = Console.ReadLine();
                        if (lista.ListIsEmpty())
                        {
                            lista.AddToList(nombre, 0);
                            break;
                        }
                        Console.WriteLine("¿Enfrente de que número de la lista desea insertar su elemento?\n");
                        lista.ShowList();
                        lista.AddToList(nombre, Convert.ToInt16(Console.ReadLine()));
                        Console.WriteLine($"Cliente {nombre} agregado a la cola.");

                        break;
                    case "2":
                        lista.ShowList();
                        Console.Write("¿Cuál es la posición del elemento que desea borrar?: ");
                        Console.WriteLine("Se ha eliminado el elemento: " + lista.DeleteFromList(Convert.ToInt16(Console.ReadLine()))+ " de la lista");
                        
                        break;
                    case "3":
                        lista.ShowList();
                        break;
                    case "4":
                        Console.WriteLine("Cerrando el sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida, intenta de nuevo.");
                        break;
                }
            } while (opcion != "4");
        }
    }
}
