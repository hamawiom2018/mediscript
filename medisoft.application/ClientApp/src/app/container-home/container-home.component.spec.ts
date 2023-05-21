import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContainerHomeComponent } from './container-home.component';

describe('ContainerHomeComponent', () => {
  let component: ContainerHomeComponent;
  let fixture: ComponentFixture<ContainerHomeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ContainerHomeComponent]
    });
    fixture = TestBed.createComponent(ContainerHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
