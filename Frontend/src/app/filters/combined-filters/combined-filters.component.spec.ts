import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CombinedFiltersComponent } from './combined-filters.component';

describe('CombinedFiltersComponent', () => {
  let component: CombinedFiltersComponent;
  let fixture: ComponentFixture<CombinedFiltersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CombinedFiltersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CombinedFiltersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
