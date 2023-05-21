using medisoft.application.models;
using medisoft.service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace medisoft.application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TranscriptController: ControllerBase{
    private readonly ITranscriptService _transcriptService;
    public TranscriptController(ITranscriptService transcriptService){
        _transcriptService = transcriptService;
        
    }
    [HttpPost("upload")]
    [DisableRequestSizeLimit]
    public IActionResult upload(TranscriptRequestContract transcriptRequestContract){
       string response= _transcriptService.GetTranscript(transcriptRequestContract.Content);
        TranscriptResponseContract transcriptResponseContract = new TranscriptResponseContract();
        transcriptResponseContract.Content = response;
        return Ok(transcriptResponseContract);
    }
}
