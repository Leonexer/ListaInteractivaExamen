using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaInteractiva
{
    internal class List
    {
        private Nodo Head; //El valor primero de la lista
        private Nodo Tail; //El valor último de la lista
        private int Counter = 0; //El tamaño de la lista

        public bool ListIsEmpty() //Devuelve true si la lista está vacía
        {
            return Head == null;
        }

        public void Prepend(object Dato) //Añadir al inicio
        {
            Nodo newNode = new Nodo(Dato); //Un nodo que almacena el dato
            if (ListIsEmpty())
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.next = Head; //Se establecen las referencias del nodo temporal
                Head.prev = newNode; 
                Head = newNode; //Se actualiza la Head
            }
            Counter++;
        }

        public void Append(object Dato) //Añadir al final
        {
            Nodo newNode = new Nodo(Dato); //Un nodo temporal que almacena el dato
            if (ListIsEmpty())
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.prev = Tail; //Se establecen las referencias del nodo temporal
                Tail.next = newNode;
                Tail = newNode; //Se actualiza la Tail
            }
            Counter++;
        }

        public void AddToList(object Dato, int Posicion) //Añadir después de una posición
        {
            if (Posicion < 0 || Posicion > Counter) return;
            if (Posicion == 0) //Si la posición es 0 se añade al principio
            {
                Prepend(Dato);
                return;
            }
            if (Posicion == Counter) //Si la posición es igual al tamaño de la lista se añade el elemnto al final.
            {
                Append(Dato);
                return;
            }

            Nodo Current = Head; //El nodo que se recorrerá al indice dado por el usuario
            for (int i = 0; i < Posicion; i++)
            {
                Current = Current.next;
            }

            Nodo newNode = new Nodo(Dato, Current.prev, Current); //Se crea un nuevo nodo con el dato a almacenar
            Current.prev.next = newNode; //Se actualizan las referencias del nodo anterior
            Current.prev = newNode; //Se actualizan las referencias del nodo actual para apuntar al nuevo nodo
            Counter++;
        }

        public object DeleteFromList(int Posicion) //Borrar dependiendo del indice
        {
            if (ListIsEmpty() || Posicion < 0 || Posicion > Counter) //Valores inválidos
            {
                return null;
            }

            object DeletedDato;

            if (Posicion == 1)
            {
                DeletedDato = Head.dato; //Se almacena el dato borrado
                if (Head == Tail) //En caso de que la lista tenga solo un elemento
                {
                    Head = Tail = null;
                }
                else
                {
                    Head = Head.next; //Se actualizan las referencias del siguiente nodo
                    Head.prev = null;
                }
                Counter--;
                return DeletedDato;
            }

            if (Posicion == Counter)
            {
                DeletedDato = Tail.dato; //Se almacena el dato borrado para retornarlo
                if (Head == Tail) //En caso de que la lista tenga un solo dato
                {
                    Head = Tail = null;
                }
                else
                {
                    Tail = Tail.prev;   //Se actualizan las referencias del nodo anterior
                    Tail.next = null;
                }
                Counter--;
                return DeletedDato;
            }

            Nodo Current = Head;
            for (int i = 1; i < Posicion; i++) //Recorrer la lista al dato a ser borrado
            {
                Current = Current.next;
            }
            DeletedDato = Current.dato; //Se guarda el dato borrado para retornarlo
            Current.next.prev = Current.prev; //Se actualizan las referencias del nodo siguiente
            Current.prev.next = Current.next; //Se actualizan las referencias del nodo anterior
            Counter--;          //Disminuyo el contador de elemtos por 1
            return DeletedDato;
        }

        public void ShowList() //Mostrar la lista
        {
            Console.WriteLine("  ------ Lista -----");
            int i = 1;
            Nodo Actual = Head;
            while (Actual != null)
            {
                Console.WriteLine(i + ".- " + Actual.dato);
                Actual = Actual.next;
                i++;
            }
            Console.WriteLine("  ----------------");
        }
    }
}