import { DrugOfChoiceModel } from './../../../models/drug.of.choice.model';
import { ChangeDetectorRef, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { TranscriptDialogComponent } from 'src/app/dialogd/transcript-dialog/transcript-dialog.component';
import { TranscriptService } from 'src/app/services/transcript.service';
import { AudioTranscript, TranscriptRequestContract, audioTranscriptsVar } from 'src/models/audio.transcript.model';
import { Visit, visitsVar } from 'src/models/visit.model';
import { NgZone } from '@angular/core';
import { ReportRequestContract } from 'src/models/report.request.contract';
import { BardReportModel, Diagnosis } from 'src/models/bard.report.model';
import { ReportGenerationService } from 'src/app/services/report-generation.service';
import { PatientInformationDialogComponent } from 'src/app/dialogs/patient-information-dialog/patient-information-dialog.component';
import { TestsNeedsDialogComponent } from 'src/app/dialogs/tests-needs-dialog/tests-needs-dialog.component';
import { DrugRequestContract } from 'src/models/drug.request.contract';
import { NeededTestModel } from 'src/models/needed.tests.model';

@Component({
  selector: 'app-visit-details',
  templateUrl: './visit-details.component.html',
  styleUrls: ['./visit-details.component.css']
})
export class VisitDetailsComponent implements OnInit {
  constructor(private activatedRout: ActivatedRoute,
    private chRef: ChangeDetectorRef,
    private zone: NgZone,
    private transcriptService: TranscriptService,
    private reportGenerationService: ReportGenerationService,
    public dialog: MatDialog) { }
  ngOnInit(): void {
    this.activatedRout.params.subscribe(async params => {
      if (params['id']) {
        this.currentVisit = this.visits.find(p => p.id == params['id']);
        console.log(this.currentVisit);
      }
    });
    //
  }
  exampleState: boolean = false;
  visits: Visit[] = visitsVar;
  currentVisit: Visit | undefined;
  audioTranscripts: AudioTranscript[] = [];
  drugOfChoiceModel: DrugOfChoiceModel | undefined;
  neededTestsModel: NeededTestModel | undefined;
  openDialog(transcript: string) {
    this.zone.run(() => {
      this.dialog.open(TranscriptDialogComponent, {
        data: transcript
      });
    });


    this.chRef.detectChanges();
  }
  openPatientInformationDialog() {
    this.zone.run(() => {
      this.dialog.open(PatientInformationDialogComponent, {
        data: this.currentVisit!.patient
      });
    });
  }
  openDiagnosisTestDialog(diagnosis: Diagnosis) {
    this.zone.run(() => {
      this.dialog.open(TestsNeedsDialogComponent, {
        data: diagnosis
      });
    });
  }
  audioBase64: string | undefined;
  async startRecording() {

    console.log("start recording");
    this.mediaRecorder = new MediaRecorder(await navigator.mediaDevices.getUserMedia({ audio: true }));
    this.mediaRecorder.onstart = () => {
      this.isRecording = true;
      this.chRef.detectChanges();
    };
    this.mediaRecorder.ondataavailable = (event) => {
      //blob to audio string

      var blobUrl = URL.createObjectURL(event.data);
      this.audioUrl = blobUrl;
      //get base64 string
      var reader = new FileReader();
      reader.readAsDataURL(event.data);
      reader.onloadend = () => {

        this.audioBase64 = reader.result as string;
        //get content type

        this.audioBase64 = this.audioBase64.substring(this.audioBase64.indexOf(',') + 1);
      };

      //apply changes in scope
      this.chRef.detectChanges();

      console.log('test');
    };
    this.mediaRecorder.start();


  }
  stopRecording() {
    this.isRecording = false;
    this.mediaRecorder!.stop();
  }
  isRecording: boolean = false;
  audioUrl: string | undefined;
  mediaRecorder: MediaRecorder | undefined;
  async sendRecording() {
    let newTranscript: AudioTranscript = { audio: this.audioUrl!, transcript: undefined, isUploading: true };
    this.audioTranscripts.push(newTranscript);
    this.audioUrl = undefined;
    this.chRef.detectChanges();
    let transcriptReqContract: TranscriptRequestContract = { content: this.audioBase64! };
    let response = await lastValueFrom(this.transcriptService.uploadTranscript(transcriptReqContract!));
    newTranscript.transcript = response.content;
    newTranscript.isUploading = false;
    if (this.audioTranscripts.filter(p => p.isUploading).length == 0) {
      this.isGenerateReportAvailable = true;
    }
    this.audioUrl = undefined;
    this.audioBase64 = undefined;
    this.chRef.detectChanges();

  }
  isGenerateReportFailed: boolean = false;
  async generateReport() {
    this.zone.run(async () => {
      this.isReportGenerating = true;
      let patientModel = this.currentVisit!.patient;
      let reportRequestContract: ReportRequestContract = {
        patient: patientModel,
        transcripts: this.audioTranscripts.map(p => { return p.transcript! }),
      }
      let reportGenerationResponse = await lastValueFrom(this.reportGenerationService.generateReport(reportRequestContract));
      if (reportGenerationResponse.success) {
        this.reportResult = reportGenerationResponse;
        this.isGenerateReportFailed = false;
        this.reportResult!.differentialDiagnosis.forEach(p => {
          p.selected = false;
        });
      } else {
        this.reportResult = reportGenerationResponse;
        this.isGenerateReportFailed = true;
      }
      this.drugOfChoiceModel=undefined;

      this.isReportGenerating = false;
      this.chRef.detectChanges();
    });


  }

  async generateDrugReport(diagnosis: Diagnosis) {
    this.zone.run(async () => {
      this.isDrugReportGenerating = true;
      let patientModel = this.currentVisit!.patient;
      let reportRequestContract: DrugRequestContract = {
        patient: patientModel,
        transcripts: this.audioTranscripts.map(p => { return p.transcript! }),
        diagnosis: diagnosis.name,
        symptoms: this.reportResult!.symptoms.map(p => { return p.name })
      }
      let reportDrugGenerationResponse = await lastValueFrom(this.reportGenerationService.generateDrugReport(reportRequestContract));
      if (reportDrugGenerationResponse.success) {
        this.drugOfChoiceModel = reportDrugGenerationResponse;
        
      } else {

      }
      //this.drugOfChoiceModel=undefined;

      this.isDrugReportGenerating = false;
      this.chRef.detectChanges();
    });


  }

  async generateNeededTestsReport(diagnosis: Diagnosis) {
    this.zone.run(async () => {
      this.isNeededTestsReportGenerating = true;
      let patientModel = this.currentVisit!.patient;
      let reportRequestContract: DrugRequestContract = {
        patient: patientModel,
        transcripts: this.audioTranscripts.map(p => { return p.transcript! }),
        diagnosis: diagnosis.name,
        symptoms: this.reportResult!.symptoms.map(p => { return p.name })
      }
      let reportNeededTestsGenerationResponse = await lastValueFrom(this.reportGenerationService.generateNeededTestReport(reportRequestContract));
      if (reportNeededTestsGenerationResponse.success) {
        this.neededTestsModel = reportNeededTestsGenerationResponse;
        
      } else {

      }
      //this.drugOfChoiceModel=undefined;

      this.isNeededTestsReportGenerating = false;
      this.chRef.detectChanges();
    });


  }
  isReportGenerating: boolean = false;
  isGenerateReportAvailable: boolean = false;
  reportResult: BardReportModel | undefined;
  isDrugReportGenerating: boolean = false;
  isNeededTestsReportGenerating: boolean = false;

  selectDiagnosis(diagnosis: Diagnosis) {
    diagnosis.selected = !diagnosis.selected;
    //get drug of choice
    this.generateDrugReport(diagnosis);

    this.generateNeededTestsReport(diagnosis);
  }

}


