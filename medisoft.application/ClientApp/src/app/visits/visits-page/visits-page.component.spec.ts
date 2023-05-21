import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisitsPageComponent } from './visits-page.component';

describe('VisitsPageComponent', () => {
  let component: VisitsPageComponent;
  let fixture: ComponentFixture<VisitsPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VisitsPageComponent]
    });
    fixture = TestBed.createComponent(VisitsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
