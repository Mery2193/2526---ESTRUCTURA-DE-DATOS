using System;
using System.Collections.Generic;

class Traductor
{
    static void Main()
    {
        // Diccionario inicial
        Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            {"time", "tiempo"},
            {"person", "persona"},
            {"year", "año"},
            {"way", "camino"},
            {"day", "día"},
            {"thing", "cosa"},
            {"man", "hombre"},
            {"world", "mundo"},
            {"life", "vida"},
            {"hand", "mano"},
            {"part", "parte"},
            {"child", "niño"},
            {"eye", "ojo"},
            {"woman", "mujer"},
            {"place", "lugar"},
            {"work", "trabajo"},
            {"week", "semana"},
            {"case", "caso"},
            {"point", "punto"},
            {"government", "gobierno"},
            {"company", "empresa"},
            {"love", "amor"},       // Nueva palabra para tu frase hermosa
            {"family", "familia"},  // Nueva palabra
            {"play", "jugar"}       // Nueva palabra
        };

        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.WriteLine("=============================================");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    TraducirFraseColores(diccionario);
                    break;
                case 2:
                    AgregarPalabra(diccionario);
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                Console.ReadKey();
            }

        } while (opcion != 0);

        Console.ResetColor();
    }

    // Método de traducción con palabras resaltadas en rosa
    static void TraducirFraseColores(Dictionary<string, string> dic)
    {
        Console.WriteLine("\nIngrese la frase en inglés para traducir:");
        string frase = Console.ReadLine();

        string[] palabras = frase.Split(' ');

        Console.WriteLine("\n==================== TRADUCCIÓN ====================");

        foreach (string palabra in palabras)
        {
            // Limpiar signos de puntuación para buscar en el diccionario
            string palabraLimpia = palabra.ToLower().Trim(new char[] { '.', ',', ';', '!', '?' });
            string signoPuntuacion = palabra.Substring(palabraLimpia.Length);

            if (dic.ContainsKey(palabraLimpia))
            {
                Console.ForegroundColor = ConsoleColor.Magenta; // Palabra traducida → rosa
                Console.Write(dic[palabraLimpia] + signoPuntuacion + " ");
            }
            else
            {
                Console.ResetColor(); // Palabra no traducida → color normal
                Console.Write(palabra + " ");
            }
        }

        Console.ResetColor();
        Console.WriteLine("\n==================================================");
    }

    // Método para agregar palabras nuevas al diccionario
    static void AgregarPalabra(Dictionary<string, string> dic)
    {
        Console.Write("\nIngrese la palabra en inglés: ");
        string ingles = Console.ReadLine().ToLower();

        Console.Write("Ingrese su traducción al español: ");
        string espanol = Console.ReadLine().ToLower();

        if (!dic.ContainsKey(ingles))
        {
            dic.Add(ingles, espanol);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nPalabra agregada correctamente: {ingles} — {espanol}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nLa palabra ya existe en el diccionario.");
            Console.ResetColor();
        }
    }
}
