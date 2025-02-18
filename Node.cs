using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaInteractiva
{
        internal class Nodo
        {
            public object dato;
            public Nodo next;
            public Nodo prev;

            public Nodo(object dato, Nodo prev, Nodo next)
            {
                this.prev = prev;
                this.dato = dato;
                this.next = next;
            }

            public Nodo(object dato, Nodo prev)
            {
                this.dato = dato;
                this.prev = prev;
            }

            public Nodo(object dato)
            {
                this.dato = dato;
                this.next = null;
                this.prev = null;
            }

            public Nodo()
            {
                this.dato = "";
                this.next = null;
                this.prev = null;
            }
        }
    }
