import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeListRendererComponent } from './employee-list-renderer.component';

describe('EmployeeListRendererComponent', () => {
  let component: EmployeeListRendererComponent;
  let fixture: ComponentFixture<EmployeeListRendererComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeListRendererComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeListRendererComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
