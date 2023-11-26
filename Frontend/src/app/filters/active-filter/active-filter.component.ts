import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FilterRequest } from '../filter-request';
import { FilterOption } from '../FilterOption';

@Component({
  selector: 'active-filter',
  templateUrl: './active-filter.component.html',
  styleUrls: ['./active-filter.component.css'],
})
export class ActiveFilterComponent {
  @Input() filterRequest!: FilterRequest;
  @Output() filterChange = new EventEmitter<void>();

  @Output() optionSelected = new EventEmitter<FilterOption>();
  FilterOption= FilterOption ;

  selectOption(option: FilterOption) {
    this.optionSelected.emit(option);
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
