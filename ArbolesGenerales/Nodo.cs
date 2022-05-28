using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesGenerales
{
    public class Nodo
    {
        public string Dato { get; set; }
        public Nodo Hijo { get; set; }
        public Nodo Hermano { get; set; }

        public Nodo(string dato, Nodo hijo = null, Nodo hermano = null)
        {
            Dato = dato;
            Hijo = hijo;
            Hermano = hermano;
        }

    }
}
