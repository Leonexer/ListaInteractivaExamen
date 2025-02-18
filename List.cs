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
        private Nodo Head;
        private Nodo Tail;
        private int Counter; //Para el ciclo, acuerdate

        public bool ListIsEmpty()
        {
            return Head == null && Tail == null;
        }
        public void Prepend(Object Dato)
        {
            if (ListIsEmpty())
            {
                Head = Tail = new Nodo(Dato);
                Counter++;
            }
            else
            {
                Head = Head.prev = new Nodo(Dato, Tail, Head);
                Counter++;
            }
        }

        public void AddToList(Object Dato, int Posicion)
        {
            if (Posicion == 0)
            {
                Append(Dato);
                Counter++;
                return;
            }

            if (Posicion == Counter)
            {
                Prepend(Dato);
                Counter++;
                return;
            }

            Nodo Current = Head;
            for (int i = 1; i < Posicion; i++)
            {
                Current = Current.next;
            }
            Current.next = new Nodo(Dato, Current, Current.next);
            Counter++;
        }

        public object DeleteFromList(int Posicion)
        {
            if (ListIsEmpty() || Posicion == 0)
            {
                return null;
            }

            Object DeletedDato;

            if (Posicion == 1)
            {
                DeletedDato = Head.dato;
                if (Head == Tail)
                {
                    Head = Tail = null;
                }
                else
                {
                    Head = Head.next;
                    Head.prev = Tail;
                }
                Counter--;
                return DeletedDato;
            }

            if (Posicion == Counter)
            {
                DeletedDato = Tail.dato;
                if (Head == Tail)
                {
                    Head = Tail = null;
                }
                else
                {
                    Tail = Tail.prev;
                    Tail.next = Head;
                }
                Counter--;
                return DeletedDato;
            }

            Nodo Current = Head;
            for (int i = 1; i < Posicion; i++)
            {
                Current = Current.next;
            }
            DeletedDato = Current.dato;
            Current.prev.next = Current.next;
            Current.next.prev = Current.prev;
            Counter--;
            return DeletedDato;
        }

        public void Append(Object Dato)
        {
            if (ListIsEmpty())
            {
                Tail = Head = new Nodo(Dato);
                Counter++;
            }
            else
            {
                Tail = Tail.next = new Nodo(Dato, Tail, Head);
                Counter++;
            }
        }

        public void ShowList()
        {
            Nodo Actual = Head;
            int i = 1;
            while (Actual != null) {
                Console.WriteLine((i++) + ".- "+Actual.dato);
                Actual = Actual.next;
            }
            Console.WriteLine("  ----------------");
        }
        public void ShowListBackwards()
        {
            Nodo Actual = Tail;
            for (int i = 0; i < Counter; i++)
            {
                Console.WriteLine(Actual.dato);
                Actual = Actual.prev;
            }
        }

        public object DeleteHead()
        {
            if (ListIsEmpty())
            {
                throw new EmptyListException();
            }

            object DeletedObj = Head.dato;

            if (Head == Tail)
            {
                Head = Tail = null;
            }
            else
            {
                Head = Head.next;
                Head.prev = null;
            }

            Counter--;
            return DeletedObj;
        }

        public object DeleteTail()
        {
            if (ListIsEmpty())
            {
                throw new EmptyListException();
            }
            object DeletedObj = Tail.dato;
            if (Head == Tail)
            {
                Head = Tail = null;
            }
            else
            {
                Tail = Tail.prev;
                Tail.prev = null;
            }
            Counter--;
            return DeletedObj;
        }
    }
}
