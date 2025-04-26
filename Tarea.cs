public enum TipoTarea
{
    Personal,
    Trabajo,
    Ocio
}

public class Tarea
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public TipoTarea Tipo { get; set; }
    public bool Prioridad { get; set; }

    public Tarea(){}
    public Tarea(int id, string? nombre, string? descripcion, TipoTarea tipo, bool prioridad)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.Tipo = tipo;
        this.Prioridad = prioridad;
    }
    public override string ToString()
    {
        return $"{Id},{Nombre},{Descripcion},{Tipo},{Prioridad}";
    }
}