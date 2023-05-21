import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BardReportModel } from 'src/models/bard.report.model';
import { ReportRequestContract } from 'src/models/report.request.contract';

@Injectable({
  providedIn: 'root'
})
export class ReportGenerationService {

  constructor(private httpClient: HttpClient) { }
  generateReport(request:ReportRequestContract): Observable<BardReportModel> {
    return this.httpClient.post<BardReportModel>('api/Report/Generate', request);
  }
}
