import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranscriptDialogComponent } from './transcript-dialog.component';

describe('TranscriptDialogComponent', () => {
  let component: TranscriptDialogComponent;
  let fixture: ComponentFixture<TranscriptDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TranscriptDialogComponent]
    });
    fixture = TestBed.createComponent(TranscriptDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
