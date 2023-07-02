import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BardReportModel } from 'src/models/bard.report.model';
import { DrugOfChoiceModel } from 'src/models/drug.of.choice.model';
import { DrugRequestContract } from 'src/models/drug.request.contract';
import { ReportRequestContract } from 'src/models/report.request.contract';

@Injectable({
  providedIn: 'root'
})
export class ReportGenerationService {

  constructor(private httpClient: HttpClient) { }
  generateReport(request:ReportRequestContract): Observable<BardReportModel> {
    return this.httpClient.post<BardReportModel>('api/Report/Generate', request);
  }
  generateDrugReport(request:DrugRequestContract): Observable<DrugOfChoiceModel> {
    return this.httpClient.post<DrugOfChoiceModel>('api/Report/GetDrugOfChoice', request);
  }
}
