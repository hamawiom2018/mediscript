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
        bool isSuccess=false;
        int count = 0;
        BardReportModel reportModel=new BardReportModel();
        while (!isSuccess && count < 4)
        {
            count++;
            try
            {
                reportModel = _bardService.GenerateReport(request);
                isSuccess = reportModel.success;

            }
            catch (Exception)
            {
                isSuccess = false;
            }
        }
        return Ok(reportModel);
       
    }
}