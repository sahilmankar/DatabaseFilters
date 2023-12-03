import { ChangeDetectorRef, Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { FilterRequest } from '../filter-request';

@Component({
  selector: 'range-filter',
  templateUrl: './range-filter.component.html',
  styleUrls: ['./range-filter.component.css'],
})
export class RangeFilterComponent {
  @Input() filterRequest!: FilterRequest;
  // @Output() filterChange = new EventEmitter<void>();
  @Input() rangeProperties: string[] = [];
  expandedPropertyIndex: number = 0;

 
 
  toggleProperty(index: number): void {
    this.expandedPropertyIndex = index;
  }

  isPropertyExpanded(index: number): boolean {
    return this.expandedPropertyIndex === index;
  }

 
}
