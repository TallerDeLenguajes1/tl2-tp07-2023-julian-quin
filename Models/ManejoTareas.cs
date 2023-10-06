namespace tl2_tp07_2023_julian_quin;
public class ManejoTareas
{
    private AccesoADatos acceso;
    public ManejoTareas(AccesoADatos accesoTareas)
    {
        this.acceso = accesoTareas;
    }
    public Tarea NuevaTarea(Tarea nuevaTarea)
    {
        var tareas = acceso.LeerT();
        if (nuevaTarea!=null)
        {
            var id = tareas.Count()+1;
            nuevaTarea.Id = id;
            tareas.Add(nuevaTarea);
            acceso.GuardarT(tareas);
            return nuevaTarea;
        }
        return nuevaTarea;
    }
    public List<Tarea> Tareas ()
    {
        return acceso.LeerT();
    }
}