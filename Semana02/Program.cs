using System;

namespace FigurasGeometricas
{
    // Clase Circulo: encapsula el radio y proporciona métodos para calcular área y perímetro
    class Circulo
    {
        // Campo privado para almacenar el radio del círculo
        private double radio;

        // Constructor de la clase Circulo, requiere como argumento el radio del círculo
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // Propiedad para obtener o establecer el radio del círculo
        public double Radio
        {
            get { return radio; }
            set { radio = value; }
        }

        // CalcularArea es una función que devuelve un valor double, 
        // se utiliza para calcular el área de un círculo, requiere como argumento el radio del círculo
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // CalcularPerimetro es una función que devuelve un valor double, 
        // se utiliza para calcular el perímetro de un círculo, requiere como argumento el radio del círculo
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase Cuadrado: encapsula el lado y proporciona métodos para calcular área y perímetro
    class Cuadrado
    {
        // Campo privado para almacenar el lado del cuadrado
        private double lado;

        // Constructor de la clase Cuadrado, requiere como argumento el lado del cuadrado
        public Cuadrado(double lado)
        {
            this.lado = lado;
        }

        // Propiedad para obtener o establecer el lado del cuadrado
        public double Lado
        {
            get { return lado; }
            set { lado = value; }
        }

        // CalcularArea es una función que devuelve un valor double, 
        // se utiliza para calcular el área de un cuadrado, requiere como argumento el lado del cuadrado
        public double CalcularArea()
        {
            return lado * lado;
        }

        // CalcularPerimetro es una función que devuelve un valor double, 
        // se utiliza para calcular el perímetro de un cuadrado, requiere como argumento el lado del cuadrado
        public double CalcularPerimetro()
        {
            return 4 * lado;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear un círculo con radio 8
            Circulo miCirculo = new Circulo(8);
            Console.WriteLine("Círculo:");
            Console.WriteLine("Radio: " + miCirculo.Radio);
            Console.WriteLine("Área: " + miCirculo.CalcularArea());
            Console.WriteLine("Perímetro: " + miCirculo.CalcularPerimetro());
            Console.WriteLine();

            // Crear un cuadrado con lado 3
            Cuadrado miCuadrado = new Cuadrado(3);
            Console.WriteLine("Cuadrado:");
            Console.WriteLine("Lado: " + miCuadrado.Lado);
            Console.WriteLine("Área: " + miCuadrado.CalcularArea());
            Console.WriteLine("Perímetro: " + miCuadrado.CalcularPerimetro());

            Console.ReadLine(); // Espera que el usuario presione Enter antes de cerrar
        }
    }
}
