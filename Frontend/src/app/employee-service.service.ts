import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Employee } from './Employee';
import { CategorizedFilterProperties } from './filters/CategorizedFilterProperties';
import { FilterRequest } from './filters/filter-request';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private http: HttpClient) {}

  getEmployees(
    filterRequest: FilterRequest,
    pageNumber: number = 1
  ): Observable<Employee[]> {
    let url = 'http://localhost:5069/api/employees';
    const params = new HttpParams().set('pageNumber', pageNumber.toString());
    return this.http.post<Employee[]>(url, filterRequest, { params: params });
  }

  getCategorizedFilterPropertiesOfEmployee(): Observable<CategorizedFilterProperties> {
    let url = 'http://localhost:5069/api/employees/proprerties';
    return this.http.get<CategorizedFilterProperties>(url);
  }

  getDepartmentNames(searchString: string): Observable<string[]> {
    let url = 'http://localhost:5069/api/employees/departments/names';
    const params = new HttpParams().set(
      'searchString',
      searchString.toString()
    );
    return this.http.get<string[]>(url, { params: params });
  }
  getEmployeeNames(searchString: string): Observable<string[]> {
    let url = 'http://localhost:5069/api/employees/names';
    const params = new HttpParams().set(
      'searchString',
      searchString.toString()
    );
    return this.http.get<string[]>(url, { params: params });
  }

  removeDefaultFilterValues(filterRequest: FilterRequest): FilterRequest {
    const filteredRequest: FilterRequest = {
      equalFilters: [],
      rangeFilters: [],
      dateRangeFilters: [],
      sortBy: undefined,
      searchString: undefined,
      sortAscending: false,
    };
    // Filter and assign values to equalFilters
    filteredRequest.equalFilters = filterRequest.equalFilters.filter(
      (filter) => filter.propertyValues.length > 0
    );
    // Filter and assign values to dateRangeFilters
    filteredRequest.dateRangeFilters = filterRequest.dateRangeFilters.filter(
      (filter) => filter.fromDate !== '' || filter.toDate !== ''
    );
    // Filter and assign values to rangeFilters
    filteredRequest.rangeFilters = filterRequest.rangeFilters.filter(
      (filter) => filter.minValue !== undefined || filter.maxValue !== undefined
    );
    filteredRequest.sortBy = filterRequest.sortBy;
    filteredRequest.searchString = filterRequest.searchString;
    filteredRequest.sortAscending = filterRequest.sortAscending;
    return filteredRequest;
  }
}
