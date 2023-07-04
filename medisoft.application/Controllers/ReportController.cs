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
        string errorMessage = "";
        while (!isSuccess && count < 4)
        {
            count++;
            try
            {
                reportModel = _bardService.GenerateReport(request);
                isSuccess = reportModel.success;
                if(reportModel.success &&( reportModel.DifferentialDiagnosis == null
                || reportModel.DifferentialDiagnosis.Count== 0))
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                isSuccess = false;
                errorMessage = ex.Message;

            }
        }
        reportModel.message = errorMessage;
        return Ok(reportModel);
       
    }
    [HttpPost("GetDrugOfChoice")]
    public IActionResult GetDrugOfChoice(DrugRequestContract request)
    {
        bool isSuccess = false;
        int count = 0;
        DrugOfChoiceModel reportModel = new DrugOfChoiceModel();
        while (!isSuccess && count < 4)
        {
            count++;
            try
            {
                reportModel = _bardService.GenerateDrugReport(request);
                isSuccess = reportModel.success;
                if (reportModel.success && (reportModel.drugOfChoice == null
                || reportModel.drugOfChoice.Count == 0))
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
        }
        return Ok(reportModel);

    }
}