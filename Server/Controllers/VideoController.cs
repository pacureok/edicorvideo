using Microsoft.AspNetCore.Mvc;
using MiVideoEditor.Shared.Models;
using MiVideoEditor.Server.Services;

[ApiController]
[Route("api/[controller]")]
public class VideoController : ControllerBase
{
    private readonly VideoProcessingService _videoService;

    public VideoController(VideoProcessingService videoService)
    {
        _videoService = videoService;
    }

    [HttpPost("export")]
    public async Task<IActionResult> ExportVideo([FromBody] VideoProject project)
    {
        // Iniciar el procesamiento del video en un hilo en segundo plano
        // para no bloquear la respuesta HTTP.
        await _videoService.ProcessVideoAsync(project);
        
        return Ok(new { Message = "Proceso de exportación iniciado." });
    }
}
