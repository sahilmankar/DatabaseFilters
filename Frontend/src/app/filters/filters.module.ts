import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateFilterComponent } from './date-filter/date-filter.component';
import { EqualFilterComponent } from './equal-filter/equal-filter.component';
import { RangeFilterComponent } from './range-filter/range-filter.component';
import { SortFilterComponent } from './sort-filter/sort-filter.component';
import { SearchFilterComponent } from './search-filter/search-filter.component';
import { FormsModule } from '@angular/forms';
import { ActiveFilterComponent } from './active-filter/active-filter.component';
import { PaginationComponent } from './pagination/pagination.component';
import { FilterMainComponent } from './filter-main/filter-main.component';

@NgModule({
  declarations: [
    DateFilterComponent,
    EqualFilterComponent,
    RangeFilterComponent,
    SortFilterComponent,
    SearchFilterComponent,
    ActiveFilterComponent,
    PaginationComponent,
    FilterMainComponent,
  ],
  imports: [CommonModule, FormsModule],
  exports: [
    DateFilterComponent,
    EqualFilterComponent,
    RangeFilterComponent,
    SortFilterComponent,
    SearchFilterComponent,
    ActiveFilterComponent,
    PaginationComponent,
    FilterMainComponent
  ],
})
export class FiltersModule {}
