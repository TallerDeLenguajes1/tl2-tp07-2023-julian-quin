using System.Text.Json;

namespace tl2_tp07_2023_julian_quin;

public class AccesoADatos
{
    private const string path = "AccesoADatos/Tareas.json";
    public List<Tarea> LeerT ()
    {   
        var tareas = new List<Tarea>();
       
        if (File.Exists(path))
        {
            var TextoJson = File.ReadAllText(path);
            if(TextoJson!=null && TextoJson.Length > 10)
            {
                tareas = JsonSerializer.Deserialize<List<Tarea>>(TextoJson);
                return tareas; 
            }
             
        }
        return tareas;
    }

    public void GuardarT(List<Tarea> tareas)
    {
        string objetoEnTexto = JsonSerializer.Serialize(tareas);
        File.WriteAllText(path,objetoEnTexto);
    }
       
      
}