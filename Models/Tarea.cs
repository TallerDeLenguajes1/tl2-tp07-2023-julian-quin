namespace  tl2_tp07_2023_julian_quin;
public enum Estado
{
    pendiente,
    EnProgreso,
    compleada,
    
}
public class Tarea
{
    private int id;
    private string titulo;
    private string descripcion;
    private Estado estado;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public Estado Estado { get => estado; set => estado = value; }
}