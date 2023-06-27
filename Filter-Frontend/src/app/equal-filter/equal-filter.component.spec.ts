import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EqualFilterComponent } from './equal-filter.component';

describe('EqualFilterComponent', () => {
  let component: EqualFilterComponent;
  let fixture: ComponentFixture<EqualFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EqualFilterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EqualFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
