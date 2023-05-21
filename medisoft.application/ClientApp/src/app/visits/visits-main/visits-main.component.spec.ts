import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisitsMainComponent } from './visits-main.component';

describe('VisitsMainComponent', () => {
  let component: VisitsMainComponent;
  let fixture: ComponentFixture<VisitsMainComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VisitsMainComponent]
    });
    fixture = TestBed.createComponent(VisitsMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
