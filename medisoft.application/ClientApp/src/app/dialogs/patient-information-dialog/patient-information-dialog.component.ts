import { ChangeDetectorRef, Component, OnInit,Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Patient } from 'src/models/patient.model';

@Component({
  selector: 'app-patient-information-dialog',
  templateUrl: './patient-information-dialog.component.html',
  styleUrls: ['./patient-information-dialog.component.css']
})
export class PatientInformationDialogComponent implements OnInit {
  patient:Patient|undefined;
  constructor(
    public dialogRef: MatDialogRef<PatientInformationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Patient,
    private chRef: ChangeDetectorRef,
  ) {}
  ngOnInit(): void {
    this.patient=this.data;
    console.log(this.patient);
    this.chRef.detectChanges();
  }
}
