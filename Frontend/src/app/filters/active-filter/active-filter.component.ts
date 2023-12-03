import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Input,
  OnChanges,
  Output,
  SimpleChanges,
} from '@angular/core';
import { FilterRequest } from '../filter-request';
import { FilterOption } from '../FilterOption';
import { Subject } from 'rxjs';
import { FilterService } from '../filter.service';

@Component({
  selector: 'active-filter',
  templateUrl: './active-filter.component.html',
  styleUrls: ['./active-filter.component.css'],
})
export class ActiveFilterComponent {
  @Input() filterRequest!: FilterRequest;
  @Output() filterChange = new EventEmitter<void>();

  FilterOption = FilterOption;
  selectedOption: FilterOption | null = null;

  constructor(private filtersvc: FilterService) {}

  selectOption(option: FilterOption) {
    this.selectedOption = option;
    this.filtersvc.filterOptionSelected$.next(option);
  }

  sendRequest() {
    this.filterChange.emit();
  }

  clearFilters() {
    this.filterRequest.rangeFilters.forEach((filter) => {
      filter.maxValue = undefined;
      filter.minValue = undefined;
    });
    this.filterRequest.dateRangeFilters.forEach((filter) => {
      filter.fromDate = '';
      filter.toDate = '';
    });
    this.filterRequest.equalFilters.forEach((filterValues) => {
      filterValues.propertyValues = [];
    });
    this.filterRequest.sortBy = undefined;
    this.filterRequest.searchString = undefined;
    this.filterRequest.sortAscending = false;
    this.filterChange.emit();
  }

  removeFilterProperty(filterType: string, index: number) {
    if (filterType === 'dateRange') {
      this.filterRequest.dateRangeFilters[index].fromDate = '';
      this.filterRequest.dateRangeFilters[index].toDate = '';
    } else if (filterType === 'range') {
      this.filterRequest.rangeFilters[index].minValue = undefined;
      this.filterRequest.rangeFilters[index].maxValue = undefined;
    }

    this.filterChange.emit();
  }

  removeEqualFilterProperty(equalIndex: number, valueIndex: number) {
    this.filterRequest.equalFilters[equalIndex].propertyValues.splice(
      valueIndex,
      1
    );
    this.filterChange.emit();
  }
}
