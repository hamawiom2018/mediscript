using medisoft.application.models;
using medisoft.model;
using medisoft.service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace medisoft.application.Controllers;
[ApiController]
[Route("api/[controller]")]

public class ReportController : ControllerBase
{
    private readonly IBardService _bardService;
    public ReportController(IBardService bardService)
    {
        _bardService = bardService;
    }
    [HttpPost("Generate")]
    public IActionResult GenerateReport(ReportRequestContract request)
    {
        BardReportModel reportModel = _bardService.GenerateReport(request);
        if (reportModel == null)
        {
            return BadRequest("No report found");
        }
        else
        {
            return Ok(reportModel);
        }
    }
}