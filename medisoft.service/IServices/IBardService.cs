using medisoft.application.models;
using medisoft.model;

namespace medisoft.service.IServices;

public interface IBardService{
    public BardReportModel GenerateReport(ReportRequestContract request);
    public DrugOfChoiceModel GenerateDrugReport(DrugRequestContract request);
}