import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { FiltersModule } from './filters/filters.module';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeListRendererComponent } from './employee-list-renderer/employee-list-renderer.component';

@NgModule({
  declarations: [AppComponent, EmployeeListComponent, EmployeeListRendererComponent],
  imports: [BrowserModule,FiltersModule,HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
