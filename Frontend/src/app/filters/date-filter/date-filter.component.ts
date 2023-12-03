import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Input,
  Output,
  SimpleChanges,
} from '@angular/core';
import { FilterRequest } from '../filter-request';

@Component({
  selector: 'date-filter',
  templateUrl: './date-filter.component.html',
  styleUrls: ['./date-filter.component.css'],
})
export class DateFilterComponent {
  @Input() filterRequest!: FilterRequest;
  @Input() dateProperties!: string[];
  // @Output() filterChange = new EventEmitter<void>();
  expandedPropertyIndex: number = 0;

  updateToDate(index: number) {
    const fromDate = this.filterRequest.dateRangeFilters[index].fromDate;
    if (fromDate && this.filterRequest.dateRangeFilters[index].toDate == '') {
      const fromDateObj = new Date(fromDate);
      const toDateObj = new Date(fromDateObj.getTime() + 24 * 60 * 60 * 1000);
      this.filterRequest.dateRangeFilters[index].toDate = toDateObj
        .toISOString()
        .substring(0, 10);
    }
  }

  toggleProperty(index: number): void {
    this.expandedPropertyIndex = index;
  }

  isPropertyExpanded(index: number): boolean {
    return this.expandedPropertyIndex === index;
  }
}
