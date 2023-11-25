import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee-service.service';
import { Employee } from '../Employee';
import { CategorizedFilterProperties } from '../filters/CategorizedFilterProperties';
import { FilterRequest } from '../filters/filter-request';
import { EqualPropertiesDataSource } from '../equalPropDataSource';

@Component({
  selector: 'employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];

  filterRequest: FilterRequest = {
    equalFilters: [],
    rangeFilters: [],
    dateRangeFilters: [],
    sortBy: undefined,
    searchString: undefined,
    sortAscending: false,
  };
  employeeProperties!: CategorizedFilterProperties;

  equalPropertiesDataSources = [
    {
      key: 'DepartmentName',
      fetcher: (searchString: string) =>
        this.empsvc.getDepartmentNames(searchString),
      dataStore: [],
    },
    {
      key: 'Name',
      fetcher: (searchString: string) =>
        this.empsvc.getEmployeeNames(searchString),
      dataStore: [],
    },
  ];

  constructor(private empsvc: EmployeeService) {}

  ngOnInit(): void {
    this.getEmployees();
    this.empsvc.getCategorizedFilterPropertiesOfEmployee().subscribe((res) => {
      this.employeeProperties = res;
    });
  }

  getEmployees() {
    var fr = this.empsvc.removeDefaultFilterValues(this.filterRequest);
    this.empsvc.getEmployees(fr).subscribe((res) => {
      console.log('🚀 ~ this.empsvc.getEmployees ~ fr:', fr);
      this.employees = res;
    });
  }
}
