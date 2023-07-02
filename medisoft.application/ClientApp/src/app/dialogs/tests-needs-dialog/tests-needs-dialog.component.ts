import { ChangeDetectorRef, Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Diagnosis } from 'src/models/bard.report.model';

@Component({
  selector: 'app-tests-needs-dialog',
  templateUrl: './tests-needs-dialog.component.html',
  styleUrls: ['./tests-needs-dialog.component.css']
})
export class TestsNeedsDialogComponent implements OnInit {
  diagnosis: Diagnosis | undefined;
  constructor(public dialogRef: MatDialogRef<TestsNeedsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Diagnosis,
    private chRef: ChangeDetectorRef,) { }
  ngOnInit(): void {
    this.diagnosis = this.data;
    console.log(this.diagnosis);
    this.chRef.detectChanges();
  }
}
