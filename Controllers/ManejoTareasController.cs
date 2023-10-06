using Microsoft.AspNetCore.Mvc;

namespace tl2_tp07_2023_julian_quin.Controllers;

[ApiController]
[Route("[controller]")]
public class ManejoTareasController : ControllerBase
{
    private ManejoTareas manejadorTareas;
    private AccesoADatos acceso;

    private readonly ILogger<ManejoTareasController> _logger;

    public ManejoTareasController(ILogger<ManejoTareasController> logger)
    {
        _logger = logger;
        acceso = new AccesoADatos();
        manejadorTareas = new(acceso);   
    }

    [HttpGet]
    public ActionResult<List<Tarea>> lookTareas()
    {
        return Ok(manejadorTareas.Tareas());
    }
    [HttpGet("Tarea-id")]
    public ActionResult<Tarea> LookTareaId(int id)
    {
        var tareaSeach = manejadorTareas.BuscarTareaViaId(id);
        if (tareaSeach!=null)
        {
            return Ok(tareaSeach);
        }
        return NotFound("Recurso No encontrado");
    }

    [HttpGet("Tareas-Completas")]
    public ActionResult<List<Tarea>> TareasComplete()
    {
        var tareasCompletas = manejadorTareas.TareasCompletadas();
        return Ok(tareasCompletas);
    }

    [HttpPost("Nueva-Tarea")]
    public ActionResult <Tarea> AddTarea(Tarea nuevaTarea)
    {
        if (manejadorTareas.NuevaTarea(nuevaTarea)!=null)
        {
            return Ok(nuevaTarea);
        }
        return BadRequest("Error en la solicitud");

    }

    [HttpPut("Actualizar-Tarea")]
    public ActionResult ActualizarTarea(int id, int nuevoEstado)
    {
        if(manejadorTareas.ActualizarTarea(id, nuevoEstado)) return Ok("Recurso Especicfico Acualizado");
         else return BadRequest("Error en la solicitud");
    }
    [HttpDelete("Eliminar-tarea")]
    public ActionResult DeleteTarea (int id)
    {
        if(manejadorTareas.EliminarTarea(id))return Ok("Recurso Eliminado");
        return NotFound("Recurso no encontrado");
    }
}
