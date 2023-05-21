import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-transcript-dialog',
  templateUrl: './transcript-dialog.component.html',
  styleUrls: ['./transcript-dialog.component.css']
})
export class TranscriptDialogComponent implements OnInit {
  transcript:string|undefined;
  constructor(
    public dialogRef: MatDialogRef<TranscriptDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string,
    private chRef: ChangeDetectorRef,
  ) {}
  ngOnInit(): void {
    this.transcript=this.data;
    console.log(this.transcript);
    this.chRef.detectChanges();
  }


}
