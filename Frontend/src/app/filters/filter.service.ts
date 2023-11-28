import { Injectable } from '@angular/core';
import { CategorizedFilterProperties } from './CategorizedFilterProperties';
import { EqualPropertiesDataSource } from './EqualPropertiesDataSource';
import { FilterRequest } from './filter-request';
import { Subject } from 'rxjs';
import { FilterOption } from './FilterOption';
import { HttpResponse } from '@angular/common/http';
import { PaginationHeader } from './paginationHeader';

@Injectable({
  providedIn: 'root',
})
export class FilterService {
  filterOptionSelected$ = new Subject<FilterOption>();
  constructor() {}

  getPaginationHeader(res: HttpResponse<any>) {
    const paginationHeader = res.headers.get('X-Pagination');
    if (paginationHeader) {
      const paginationData: PaginationHeader = JSON.parse(paginationHeader);
      return paginationData;
    }
    return null;
  }

  populateFilterRequest(
    employeeCategorizedProperties: CategorizedFilterProperties,
    equalPropertiesDataSources: EqualPropertiesDataSource[]
  ): FilterRequest {
    let filterRequest: FilterRequest = {
      equalFilters: [],
      rangeFilters: [],
      dateRangeFilters: [],
      sortBy: undefined,
      searchString: undefined,
      sortAscending: false,
    };

    filterRequest.dateRangeFilters =
      employeeCategorizedProperties.dateRangeProperties.map((property) => {
        return { propertyName: property, fromDate: '', toDate: '' };
      });
    filterRequest.equalFilters = equalPropertiesDataSources.map((property) => {
      return { propertyName: property.key, propertyValues: [] };
    });
    filterRequest.rangeFilters =
      employeeCategorizedProperties.rangeProperties.map((property) => {
        return {
          propertyName: property,
          minValue: undefined,
          maxValue: undefined,
        };
      });
    return filterRequest;
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
