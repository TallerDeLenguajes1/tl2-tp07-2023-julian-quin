using System.Text.Json;

namespace tl2_tp07_2023_julian_quin;

public class AccesoADatos
{
    private const string path = "AccesoADatos/Tareas.json";
    public List<Tarea> LeerT ()
    {
       
        if (File.Exists(path))
        {
            var TextoJson = File.ReadAllText(path);
            var tareas = JsonSerializer.Deserialize<List<Tarea>>(TextoJson);
            return tareas;   
        }
        return new List<Tarea>();
    }

    public void GuardarT(List<Tarea> tareas)
    {
        string objetoEnTexto = JsonSerializer.Serialize(tareas);
        File.WriteAllText(path,objetoEnTexto);
    }
       
      
}