using System;

namespace RegistroEstudiante
{
    // ===============================
    // Clase Estudiante
    // ===============================
    public class Estudiante
    {
        // Propiedades del estudiante
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; }

        // Constructor que valida que haya exactamente 3 teléfonos
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            ID = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;

            if (telefonos.Length == 3)
                Telefonos = telefonos;
            else
                throw new ArgumentException("Debe proporcionar exactamente 3 números de teléfono.");
        }

        // Método para mostrar la información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("\n===== INFORMACIÓN DEL ESTUDIANTE =====");
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Nombres: " + Nombres);
            Console.WriteLine("Apellidos: " + Apellidos);
            Console.WriteLine("Dirección: " + Direccion);
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine("  Teléfono " + (i + 1) + ": " + Telefonos[i]);
            }
            Console.WriteLine("======================================");
        }
    }

    // ===============================
    // Clase principal Program
    // ===============================
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== REGISTRO DE ESTUDIANTE ===");

            // Datos predefinidos del estudiante
            string[] telefonos = { "099-123-4567", "098-765-4321", "097-555-6789" };
            Estudiante estudiante = new Estudiante(
                id: 1,
                nombres: "Aquiles",
                apellidos: "Tandazo",
                direccion: "Av. Amazonas 456",
                telefonos: telefonos
            );

            // Mostrar información del estudiante
            estudiante.MostrarInformacion();

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
