import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestsNeedsDialogComponent } from './tests-needs-dialog.component';

describe('TestsNeedsDialogComponent', () => {
  let component: TestsNeedsDialogComponent;
  let fixture: ComponentFixture<TestsNeedsDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TestsNeedsDialogComponent]
    });
    fixture = TestBed.createComponent(TestsNeedsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
