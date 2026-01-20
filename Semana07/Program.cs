using System;
using System.Collections.Generic;
using System.Threading;

#nullable enable
class ProgramaInteractivo
{
    static void Main()
    {
        while (true)
        {
            Console.Clear(); // Limpiar pantalla antes de mostrar el menú
            MostrarMenuPrincipal();

            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuParentesis(); // Submenú, no dibuja el menú principal
                    break;
                case "2":
                    ResolverHanoiVisual(); // Submenú, no dibuja el menú principal
                    break;
                case "3":
                    Console.WriteLine("\nSaliendo del programa... Hasta luego.");
                    Thread.Sleep(1500);
                    return;
                default:
                    Console.WriteLine("\nOpción no válida. Presione Enter para intentar de nuevo.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    // ================================
    // MENÚ PRINCIPAL
    // ================================
    static void MostrarMenuPrincipal()
    {
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║          MENÚ PRINCIPAL                ║");
        Console.WriteLine("╠════════════════════════════════════════╣");
        Console.WriteLine("║ 1. Verificación de paréntesis         ║");
        Console.WriteLine("║ 2. Resolver Torres de Hanoi (visual)  ║");
        Console.WriteLine("║ 3. Salir                              ║");
        Console.WriteLine("╚════════════════════════════════════════╝\n");
    }

    // ================================
    // OPCIÓN 1: PARÉNTESIS
    // ================================
    static void MenuParentesis()
    {
        Console.Clear(); // Limpiar pantalla solo al entrar al submenú
        Console.WriteLine("=== Verificación de Paréntesis Balanceados ===");

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nEscriba su fórmula matemática (o '0' para regresar al menú):");
            Console.Write("→ ");
            string formula = Console.ReadLine() ?? "";

            if (formula == "0")
                break;

            if (EstaBalanceada(formula))
                Console.WriteLine("\n✅ Fórmula balanceada.");
            else
                Console.WriteLine("\n❌ Fórmula NO balanceada.");

            Console.Write("\n¿Desea probar otra fórmula? (S / N): ");
            string respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (respuesta != "S" && respuesta != "SI")
                continuar = false; // Salir del bucle y volver al menú principal
        }
    }

    static bool EstaBalanceada(string expr)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expr)
        {
            if (c == '(' || c == '{' || c == '[')
                pila.Push(c);
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0) return false;

                char top = pila.Pop();
                if ((c == ')' && top != '(') ||
                    (c == '}' && top != '{') ||
                    (c == ']' && top != '['))
                    return false;
            }
        }
        return pila.Count == 0;
    }

    // ================================
    // OPCIÓN 2: TORRES DE HANOI VISUAL
    // ================================
    static void ResolverHanoiVisual()
    {
        Console.Clear();
        Console.WriteLine("=== Torres de Hanoi Visual ===");
        Console.Write("Ingrese número de discos (máx 10): ");

        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0 || n > 10)
        {
            Console.WriteLine("Número inválido. Presione Enter para regresar al menú.");
            Console.ReadLine();
            return;
        }

        Stack<int> A = new Stack<int>();
        Stack<int> B = new Stack<int>();
        Stack<int> C = new Stack<int>();

        for (int i = n; i >= 1; i--)
            A.Push(i);

        // Dibujar torres iniciales
        Console.Clear();
        Console.WriteLine("=== Torres de Hanoi Visual ===\n");
        DibujarTorres(A, B, C, n);

        int delay = n <= 5 ? 800 : n <= 8 ? 200 : 50;

        // Mover discos correctamente
        MoverHanoiVisual(n, A, C, B, "A", "C", "B", n, delay);

        Console.WriteLine("\n¡Proceso completado! Presione Enter para regresar al menú.");
        Console.ReadLine();
    }

    static void MoverHanoiVisual(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                                 string o, string d, string a, int altura, int delay)
    {
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);

            // Limpiar pantalla y mostrar título
            Console.Clear();
            Console.WriteLine("=== Torres de Hanoi Visual ===\n");
            Console.WriteLine($"Mover disco {disco} de {o} a {d}\n");

            // Dibujar las torres con su estado real
            DibujarTorres(origen, auxiliar, destino, altura);

            Thread.Sleep(delay);
        }
        else
        {
            MoverHanoiVisual(n - 1, origen, auxiliar, destino, o, a, d, altura, delay);
            MoverHanoiVisual(1, origen, destino, auxiliar, o, d, a, altura, delay);
            MoverHanoiVisual(n - 1, auxiliar, destino, origen, a, d, o, altura, delay);
        }
    }

    static void DibujarTorres(Stack<int> A, Stack<int> B, Stack<int> C, int altura)
    {
        Stack<int>[] torres = { A, B, C };

        for (int nivel = altura - 1; nivel >= 0; nivel--)
        {
            foreach (var torre in torres)
            {
                var arr = torre.ToArray();
                if (nivel < arr.Length)
                    DibujarDisco(arr[nivel]);
                else
                    Console.Write("│".PadLeft(altura + 1).PadRight(altura * 2 + 3));
            }
            Console.WriteLine();
        }

        Console.WriteLine(new string('─', altura * 6));
        Console.WriteLine("   A".PadRight(altura * 2 + 3) +
                          "   B".PadRight(altura * 2 + 3) +
                          "   C\n");
    }

    static void DibujarDisco(int t)
    {
        ConsoleColor[] colores =
        {
            ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow,
            ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.Cyan
        };

        Console.BackgroundColor = colores[(t - 1) % colores.Length];
        Console.Write(new string(' ', t * 2).PadLeft(10).PadRight(23));
        Console.ResetColor();
    }
}
