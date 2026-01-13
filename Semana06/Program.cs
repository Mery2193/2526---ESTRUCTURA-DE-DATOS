using System;

namespace ListasEnlazadas
{
    // ============================
    // NODO PARA DATOS REALES
    // ============================
    class NodoReal
    {
        public double Dato;
        public NodoReal Siguiente;

        public NodoReal(double dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // ============================
    // LISTA ENLAZADA DE REALES
    // ============================
    class ListaReal
    {
        public NodoReal Inicio;

        public void Insertar(double dato)
        {
            NodoReal nuevo = new NodoReal(dato);

            if (Inicio == null)
                Inicio = nuevo;
            else
            {
                NodoReal aux = Inicio;
                while (aux.Siguiente != null)
                    aux = aux.Siguiente;
                aux.Siguiente = nuevo;
            }
        }

        public void Mostrar()
        {
            NodoReal aux = Inicio;
            while (aux != null)
            {
                Console.Write(aux.Dato + "  ");
                aux = aux.Siguiente;
            }
            Console.WriteLine();
        }

        public double CalcularPromedio()
        {
            double suma = 0;
            int contador = 0;
            NodoReal aux = Inicio;

            while (aux != null)
            {
                suma += aux.Dato;
                contador++;
                aux = aux.Siguiente;
            }
            return suma / contador;
        }
    }

    // ============================
    // NODO PARA DATOS ENTEROS
    // ============================
    class NodoEntero
    {
        public int Dato;
        public NodoEntero Siguiente;

        public NodoEntero(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // ============================
    // LISTA ENLAZADA DE ENTEROS
    // ============================
    class ListaEntero
    {
        public NodoEntero Inicio;

        public void InsertarInicio(int dato)
        {
            NodoEntero nuevo = new NodoEntero(dato);
            nuevo.Siguiente = Inicio;
            Inicio = nuevo;
        }

        public void Mostrar()
        {
            NodoEntero aux = Inicio;
            while (aux != null)
            {
                Console.Write(aux.Dato + "  ");
                aux = aux.Siguiente;
            }
            Console.WriteLine();
        }

        public int Contar()
        {
            int contador = 0;
            NodoEntero aux = Inicio;
            while (aux != null)
            {
                contador++;
                aux = aux.Siguiente;
            }
            return contador;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ==================================================
            // EJERCICIO 1
            // ==================================================
            Console.WriteLine("==================================================");
            Console.WriteLine("EJERCICIO 1");
            Console.WriteLine("==================================================");
            Console.WriteLine("Crear un programa que maneje N cantidad de datos de tipo real en una lista.");
            Console.WriteLine("Una vez cargados los datos, el programa debe calcular el promedio.");
            Console.WriteLine("Luego, cargar los datos menores o iguales al promedio en una segunda lista,");
            Console.WriteLine("y los mayores en una tercera lista.");
            Console.WriteLine("El programa debe mostrar:");
            Console.WriteLine("a) Lista principal");
            Console.WriteLine("b) Promedio");
            Console.WriteLine("c) Datos menores o iguales al promedio");
            Console.WriteLine("d) Datos mayores al promedio");
            Console.WriteLine("--------------------------------------------------");

            ListaReal listaPrincipal = new ListaReal();
            ListaReal menoresIguales = new ListaReal();
            ListaReal mayores = new ListaReal();

            Console.Write("Ingrese la cantidad de datos reales: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Ingrese el dato " + (i + 1) + ": ");
                listaPrincipal.Insertar(double.Parse(Console.ReadLine()));
            }

            double promedio = listaPrincipal.CalcularPromedio();

            NodoReal aux = listaPrincipal.Inicio;
            while (aux != null)
            {
                if (aux.Dato <= promedio)
                    menoresIguales.Insertar(aux.Dato);
                else
                    mayores.Insertar(aux.Dato);

                aux = aux.Siguiente;
            }

            Console.WriteLine("\nLista principal:");
            listaPrincipal.Mostrar();

            Console.WriteLine("Promedio: " + promedio);

            Console.WriteLine("Lista con datos menores o iguales al promedio:");
            menoresIguales.Mostrar();

            Console.WriteLine("Lista con datos mayores al promedio:");
            mayores.Mostrar();

            // ==================================================
            // EJERCICIO 2
            // ==================================================
            Console.WriteLine("\n==================================================");
            Console.WriteLine("EJERCICIO 2");
            Console.WriteLine("==================================================");
            Console.WriteLine("Crear un programa que maneje N cantidad de datos enteros en dos listas enlazadas por el inicio.");
            Console.WriteLine("Debe existir un ciclo de carga para cada lista.");
            Console.WriteLine("El programa debe comparar las listas y mostrar:");
            Console.WriteLine("a) Si son iguales en tamaño y contenido");
            Console.WriteLine("b) Si son iguales en tamaño pero no en contenido");
            Console.WriteLine("c) Si no tienen el mismo tamaño ni contenido");
            Console.WriteLine("--------------------------------------------------");

            ListaEntero lista1 = new ListaEntero();
            ListaEntero lista2 = new ListaEntero();

            Console.Write("Cantidad de datos de la lista 1: ");
            int n1 = int.Parse(Console.ReadLine());

            for (int i = 0; i < n1; i++)
            {
                Console.Write("Ingrese el dato: ");
                lista1.InsertarInicio(int.Parse(Console.ReadLine()));
            }

            Console.Write("Cantidad de datos de la lista 2: ");
            int n2 = int.Parse(Console.ReadLine());

            for (int i = 0; i < n2; i++)
            {
                Console.Write("Ingrese el dato: ");
                lista2.InsertarInicio(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine("\nLista 1:");
            lista1.Mostrar();

            Console.WriteLine("Lista 2:");
            lista2.Mostrar();

            if (lista1.Contar() == lista2.Contar())
            {
                NodoEntero a = lista1.Inicio;
                NodoEntero b = lista2.Inicio;
                bool iguales = true;

                while (a != null)
                {
                    if (a.Dato != b.Dato)
                    {
                        iguales = false;
                        break;
                    }
                    a = a.Siguiente;
                    b = b.Siguiente;
                }

                if (iguales)
                    Console.WriteLine("RESULTADO: Las listas son iguales en tamaño y contenido.");
                else
                    Console.WriteLine("RESULTADO: Las listas son iguales en tamaño pero no en contenido.");
            }
            else
            {
                Console.WriteLine("RESULTADO: Las listas no tienen el mismo tamaño ni contenido.");
            }

            Console.ReadKey();
        }
    }
}
