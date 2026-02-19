using System;
using System.Collections.Generic;
using System.Linq;

namespace CampaniaVacunacionCOVID
{
    class Program
    {
        static void Main(string[] args)
        {
            // ==========================================================
            // 1. CREACIÓN DEL CONJUNTO TOTAL DE CIUDADANOS
            // ==========================================================
            HashSet<string> ciudadanos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
            {
                ciudadanos.Add($"Ciudadano {i}");
            }

            // ==========================================================
            // 2. CREACIÓN DE CONJUNTOS DE VACUNADOS
            // ==========================================================
            HashSet<string> vacunadosPfizer = new HashSet<string>();
            for (int i = 1; i <= 75; i++)
            {
                vacunadosPfizer.Add($"Ciudadano {i}");
            }

            HashSet<string> vacunadosAstraZeneca = new HashSet<string>();
            for (int i = 51; i <= 125; i++)
            {
                vacunadosAstraZeneca.Add($"Ciudadano {i}");
            }

            // ==========================================================
            // 3. OPERACIONES DE TEORÍA DE CONJUNTOS
            // ==========================================================
            HashSet<string> ambasDosis = new HashSet<string>(vacunadosPfizer);
            ambasDosis.IntersectWith(vacunadosAstraZeneca);

            HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
            soloPfizer.ExceptWith(vacunadosAstraZeneca);

            HashSet<string> soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
            soloAstraZeneca.ExceptWith(vacunadosPfizer);

            HashSet<string> vacunadosTotales = new HashSet<string>(vacunadosPfizer);
            vacunadosTotales.UnionWith(vacunadosAstraZeneca);

            HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
            noVacunados.ExceptWith(vacunadosTotales);

            // ==========================================================
            // 4. PRESENTACIÓN DE RESULTADOS EN CUADROS
            // ==========================================================
            MostrarCuadro("CIUDADANOS QUE NO SE HAN VACUNADO", noVacunados);
            MostrarCuadro("CIUDADANOS CON AMBAS DOSIS (PFIZER + ASTRAZENECA)", ambasDosis);
            MostrarCuadro("CIUDADANOS QUE SOLO HAN RECIBIDO PFIZER", soloPfizer);
            MostrarCuadro("CIUDADANOS QUE SOLO HAN RECIBIDO ASTRAZENECA", soloAstraZeneca);

            Console.WriteLine("\n=== FIN DEL PROCESO DE VACUNACIÓN ===");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // ==========================================================
        // MÉTODO AUXILIAR: Muestra los resultados en un "cuadro"
        // ==========================================================
        static void MostrarCuadro(string titulo, HashSet<string> conjunto)
        {
            int total = conjunto.Count;
            int columnas = 5; // número de columnas en la tabla

            // Convertimos el HashSet a lista para poder indexar
            List<string> lista = conjunto.ToList();

            // Cabecera del cuadro
            string lineaSuperior = new string('═', 70);
            Console.WriteLine($"\n╔{lineaSuperior}╗");
            Console.WriteLine($"║ {titulo.PadRight(68)} ║");
            Console.WriteLine($"║ Total de ciudadanos: {total}".PadRight(69) + "║");
            Console.WriteLine($"╠{lineaSuperior}╣");

            // Contenido en filas y columnas
            for (int i = 0; i < lista.Count; i++)
            {
                if (i % columnas == 0)
                    Console.Write("║ "); // inicio de fila

                Console.Write($"{lista[i].PadRight(13)} "); // espacio entre columnas

                if ((i + 1) % columnas == 0 || i == lista.Count - 1)
                    Console.WriteLine("║"); // fin de fila
            }

            // Pie del cuadro
            Console.WriteLine($"╚{lineaSuperior}╝");
        }
    }
}
