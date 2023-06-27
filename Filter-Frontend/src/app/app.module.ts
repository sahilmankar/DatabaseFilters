import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FilterTestComponent } from './filter-test/filter-test.component';
import { FarmerCollectionListComponent } from './farmer-collection-list/farmer-collection-list.component';
import { HttpClientModule } from '@angular/common/http';
import { SortByComponent } from './sort-by/sort-by.component';
import { EqualFilterComponent } from './equal-filter/equal-filter.component';
import { DateFilterComponent } from './date-filter/date-filter.component';
import { RangeFilterComponent } from './range-filter/range-filter.component';

@NgModule({
  declarations: [
    AppComponent,
    FilterTestComponent,
    FarmerCollectionListComponent,
    SortByComponent,
    EqualFilterComponent,
    DateFilterComponent,
    RangeFilterComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [ ],
  bootstrap: [AppComponent]
})
export class AppModule { }
