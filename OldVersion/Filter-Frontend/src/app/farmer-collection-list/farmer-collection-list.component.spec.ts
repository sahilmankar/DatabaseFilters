import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FarmerCollectionListComponent } from './farmer-collection-list.component';

describe('FarmerCollectionListComponent', () => {
  let component: FarmerCollectionListComponent;
  let fixture: ComponentFixture<FarmerCollectionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FarmerCollectionListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FarmerCollectionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
