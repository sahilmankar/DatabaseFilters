import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee-service.service';
import { Employee } from '../Employee';
import { CategorizedFilterProperties } from '../filters/CategorizedFilterProperties';
import { FilterRequest } from '../filters/filter-request';
import { EqualPropertiesDataSource } from '../filters/EqualPropertiesDataSource';
import { FilterService } from '../filters/filter.service';

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

  employeeCategorizedProperties!: CategorizedFilterProperties;

  equalPropertiesDataSources: EqualPropertiesDataSource[] = [
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

  constructor(
    private empsvc: EmployeeService,
    private filtersvc: FilterService
  ) {}

  ngOnInit(): void {
    this.getEmployees();
    this.empsvc.getCategorizedFilterPropertiesOfEmployee().subscribe((res) => {
      this.employeeCategorizedProperties = res;
      this.filterRequest = this.filtersvc.populateFilterRequest(
        this.employeeCategorizedProperties,
        this.equalPropertiesDataSources
      );
    });
  }

  getEmployees() {
    var fr = this.filtersvc.removeDefaultFilterValues(this.filterRequest);
    this.empsvc.getEmployees(fr).subscribe((res) => {
      this.employees = res;
    });
  }
}
