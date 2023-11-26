import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { EmployeeService } from '../employee-service.service';
import { Employee } from '../Employee';
import { CategorizedFilterProperties } from '../filters/CategorizedFilterProperties';
import { FilterRequest } from '../filters/filter-request';
import { EqualPropertiesDataSource } from '../equalPropDataSource';
import { FilterOption } from '../filters/FilterOption';

@Component({
  selector: 'employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
})
export class EmployeeListComponent implements OnInit, OnDestroy {
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

  FilterOption = FilterOption;
  selectedOption: FilterOption | null = null;
  handleOptionSelected(option: FilterOption) {
    this.selectedOption = option;
  }

  constructor(private empsvc: EmployeeService) {}

  ngOnInit(): void {
    this.getEmployees();
    this.empsvc.getCategorizedFilterPropertiesOfEmployee().subscribe((res) => {
      this.employeeCategorizedProperties = res;
    });
  }

  getEmployees() {
    var fr = this.empsvc.removeDefaultFilterValues(this.filterRequest);
    this.empsvc.getEmployees(fr).subscribe((res) => {
      this.employees = res;
    });
  }

  @HostListener('window:beforeunload', ['$event'])
  unloadHandler(event: Event): void {
    sessionStorage.clear();
    // Perform cleanup or execute code before the browser is refreshed
    console.log('Window is about to unload!');
  }
  ngOnDestroy(): void {
    sessionStorage.clear();
  }
}
