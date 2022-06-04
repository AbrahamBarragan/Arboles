using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesGenerales
{
    internal class ArbolGeneral
    {
        private readonly Nodo raiz;

        //public Nodo Raiz => raiz; (Hace expresiones landa)
        public Nodo Raiz { get { return raiz; } }

        public ArbolGeneral(string dato)
        {
            raiz = new Nodo(dato);
        }

        public Nodo InsertarHijo(Nodo padre, string dato)
        {
            if (string.IsNullOrWhiteSpace(dato))
            {
                throw new Exception("El dato esta vacio");
            }

            if (padre is null)
            {
                throw new Exception("El padre no puede ser nulo");
            }

            if (padre.Hijo is null)
            {
                padre.Hijo = new Nodo(dato);
                return padre.Hijo;
            }
            else
            {
                Nodo hijoActual = padre.Hijo;
                while (hijoActual.Hermano is not null)
                {
                    hijoActual = hijoActual.Hermano;
                }
                hijoActual.Hermano = new Nodo(dato);
                return hijoActual.Hermano;
            }
        }
        private void Recorrer(Nodo nodo, ref int posicion, ref string datos)
        {
            if(nodo is not null)
            {
                string dato = nodo.Dato;
                int CantidadGuiones = dato.Length + posicion;
                string DatoConGuines = dato.PadLeft(CantidadGuiones, '-');
                datos += $"{DatoConGuines}\n";

                if (nodo.Hijo is not null)
                {
                    posicion++;
                    Recorrer(nodo.Hijo, ref posicion, ref datos);
                    posicion--;

                }
                if(nodo.Hermano is not null && posicion != 0)
                {
                    Recorrer(nodo.Hermano, ref posicion, ref datos);
                }
            }
        }
        public string ObtenerArbol(Nodo nodo = null)
        {
            if(nodo is null)
            {
                nodo = raiz;
            }
            int posicion = 0;
            string datos = "";
            Recorrer(nodo, ref posicion, ref datos);
            return datos;
        }
        public Nodo Buscar(string dato, Nodo nodoBusqueda = null)
        {
            if(nodoBusqueda is null)
            {
                nodoBusqueda = raiz;
            }
            if(nodoBusqueda.Dato.ToUpper() == dato.ToUpper())
            {
                return nodoBusqueda;
            }
            if(nodoBusqueda.Hijo is not null)
            {
                Nodo nodoEncontrado = Buscar(dato, nodoBusqueda.Hijo);
                if(nodoEncontrado is not null)
                {
                    return nodoEncontrado;
                }
            }
            if(nodoBusqueda.Hermano is not null)
            {
                Nodo nodoEncontrado = Buscar(dato, nodoBusqueda.Hermano);
                if(nodoEncontrado is not null)
                {
                    return nodoEncontrado;
                }
            }
            return null;
        }
    }
    //investigar inmutavilidad
}
