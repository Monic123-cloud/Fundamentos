using System;

public class Program
{
    public static void Main(string[] args)
    {
        GestorTareas gestor = new GestorTareas();

        while (true)
        {
            Console.WriteLine("Menú Gestor de Tareas Personales");
            Console.WriteLine("1. Crear tarea");
            Console.WriteLine("2. Buscar tareas por tipo");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("4. Exportar tareas");
            Console.WriteLine("5. Importar tareas");
            Console.WriteLine("6. Salir");

            Console.WriteLine("Elige una opción:");
            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        gestor.CrearTarea();
                        break;
                    case 2:
                        gestor.BuscarTareasPorTipo();
                        break;
                    case 3:
                        gestor.EliminarTarea();
                        break;
                    case 4:
                        gestor.ExportarTareas();
                        break;
                    case 5:
                        gestor.ImportarTareas();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }
    }
}