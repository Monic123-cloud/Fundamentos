using System;
using System.Collections.Generic;
using System.IO;

public class GestorTareas
{
    private List<Tarea> tareas = new List<Tarea>();
    private int ultimoId = 0;

    public void CrearTarea()
    {
        Console.WriteLine("Nombre de la tarea:");
        string? nombre = Console.ReadLine();

        Console.WriteLine("Descripción de la tarea:");
        string? descripcion = Console.ReadLine();

        Console.WriteLine("Tipo de tarea (Personal, Trabajo, Ocio):");
        TipoTarea tipo;
        while (!Enum.TryParse(Console.ReadLine(), out tipo))
        {
            Console.WriteLine("Tipo de tarea no válido. Inténtalo de nuevo.");
        }

        Console.WriteLine("¿Tiene prioridad? (true/false):");
        bool prioridad;
        while (!bool.TryParse(Console.ReadLine(), out prioridad))
        {
            Console.WriteLine("Prioridad no válida. Inténtalo de nuevo.");
        }

        Tarea nuevaTarea = new Tarea
        {
            Id = ++ultimoId,
            Nombre = nombre,
            Descripcion = descripcion,
            Tipo = tipo,
            Prioridad = prioridad
        };

        tareas.Add(nuevaTarea);
        Console.WriteLine("Tarea creada con éxito.");
    }

    public void BuscarTareasPorTipo()
    {
        Console.WriteLine("Tipo de tarea a buscar (Personal, Trabajo, Ocio):");
        TipoTarea tipo;
        while (!Enum.TryParse(Console.ReadLine(), out tipo))
        {
            Console.WriteLine("Tipo de tarea no válido. Inténtalo de nuevo.");
        }

        List<Tarea> tareasEncontradas = tareas.FindAll(tarea => tarea.Tipo == tipo);

        if (tareasEncontradas.Count > 0)
        {
            Console.WriteLine("Tareas encontradas:");
            foreach (Tarea tarea in tareasEncontradas)
            {
                Console.WriteLine(tarea);
            }
        }
        else
        {
            Console.WriteLine("No se encontraron tareas con ese tipo.");
        }
    }

    public void EliminarTarea()
    {
        Console.WriteLine("ID de la tarea a eliminar:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ID no válido. Inténtalo de nuevo.");
        }

        Tarea tareaAEliminar = tareas.Find(tarea => tarea.Id == id);

        if (tareaAEliminar != null)
        {
            tareas.Remove(tareaAEliminar);
            Console.WriteLine("Tarea eliminada con éxito.");
        }
        else
        {
            Console.WriteLine("No se encontró ninguna tarea con ese ID.");
        }
    }

    public void ExportarTareas()
    {
        FileStream? fileStream = null;
        StreamWriter? streamWriter = null;
        try
        {
            fileStream = new FileStream("tareas.txt", FileMode.Create, FileAccess.Write);
            streamWriter = new StreamWriter(fileStream);

            foreach (Tarea tarea in tareas)
            {
                streamWriter.WriteLine(tarea.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al exportar tareas: {ex.Message}");
        }
        finally
        {
            streamWriter?.Close();
            fileStream?.Close();
        }
        try
        {
            using (StreamWriter writer = new StreamWriter("tareas.txt"))
            {
                foreach (Tarea tarea in tareas)
                {
                    writer.WriteLine(tarea);
                }
            }
            Console.WriteLine("Tareas exportadas a tareas.txt con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al exportar tareas: {ex.Message}");
        }
    }

    public void ImportarTareas()
    {   
        FileStream? fileStream = null;
        BufferedStream? bufferedStream = null;
        StreamReader? streamReader = null;
        try
        {
            fileStream = new FileStream("tareas.txt", FileMode.Open, FileAccess.Read);
            bufferedStream = new BufferedStream(fileStream);
            streamReader = new StreamReader(bufferedStream);

            string? linea;
            List<Tarea> tareasImportadas = new List<Tarea>();
            int maxIdEnArchivo = 0;

            while ((linea = streamReader.ReadLine()) != null)
            {
                Console.WriteLine($"Se leyó la línea: {linea}"); // Depuración
                string[] datosTarea = linea.Split(',');
             if (datosTarea.Length == 5 &&
                int.TryParse(datosTarea[0], out int id) &&
                Enum.TryParse(datosTarea[3], out TipoTarea tipo) &&
                bool.TryParse(datosTarea[4], out bool prioridad))
                {
                    Tarea tarea = new Tarea
                    {
                    Id = id,
                    Nombre = datosTarea[1],
                    Descripcion = datosTarea[2],
                    Tipo = tipo,
                    Prioridad = prioridad
                    };
                    tareasImportadas.Add(tarea);
                    Console.WriteLine($"Tarea parseada: ID={tarea.Id}, Nombre={tarea.Nombre}"); // Depuración
                    if (id > maxIdEnArchivo)
                    {   
                        maxIdEnArchivo = id;
                    }
                }
                else
                {
                    Console.WriteLine($"Advertencia: Línea ignorada por formato incorrecto: {linea}");
                }
            }
            tareas.AddRange(tareasImportadas);
            Console.WriteLine($"Se importaron {tareasImportadas.Count} tareas desde tareas.txt con éxito.");

            if (maxIdEnArchivo >= ultimoId)
            {
                ultimoId = maxIdEnArchivo;
            }
            Console.WriteLine($"ultimoId después de importar: {ultimoId}"); // Depuración

        
            Console.WriteLine("Tareas Importadas");
            if (tareasImportadas.Count > 0)
            {
                foreach (Tarea tarea in tareasImportadas)
                {
                    Console.WriteLine(tarea);
                }
            }
            else
            {
                Console.WriteLine("No se importaron tareas.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("El archivo tareas.txt no existe.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al importar tareas: {ex.Message}");
        }
        finally
        {
            streamReader?.Close();
            bufferedStream?.Close();
            fileStream?.Close();
        }
    }
}