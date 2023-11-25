import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateFilterComponent } from './date-filter/date-filter.component';
import { EqualFilterComponent } from './equal-filter/equal-filter.component';
import { RangeFilterComponent } from './range-filter/range-filter.component';
import { SortFilterComponent } from './sort-filter/sort-filter.component';
import { SearchFilterComponent } from './search-filter/search-filter.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    DateFilterComponent,
    EqualFilterComponent,
    RangeFilterComponent,
    SortFilterComponent,
    SearchFilterComponent,
  ],
  imports: [CommonModule, FormsModule],
  exports: [
    DateFilterComponent,
    EqualFilterComponent,
    RangeFilterComponent,
    SortFilterComponent,
    SearchFilterComponent,
  ],
})
export class FiltersModule {}
