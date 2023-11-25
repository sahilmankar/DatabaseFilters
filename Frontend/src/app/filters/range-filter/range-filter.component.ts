import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { FilterRequest } from '../filter-request';

@Component({
  selector: 'range-filter',
  templateUrl: './range-filter.component.html',
  styleUrls: ['./range-filter.component.css'],
})
export class RangeFilterComponent {
  @Input() filterRequest!: FilterRequest;
  @Output() filterChange = new EventEmitter<void>();
  @Input() rangeProperties: string[] = [];
  expandedPropertyIndex: number = 0;
  isButtonClicked: boolean = false;
  initializationDone: boolean = false;


 
  ngOnChanges(changes: SimpleChanges) {
    if (changes["rangeProperties"].currentValue) {
      this.initializeRangeFilters();
    }
  }

  initializeRangeFilters() {
    this.filterRequest.rangeFilters = this.rangeProperties.map((property) => {
      return {
        propertyName: property,
        minValue: undefined,
        maxValue: undefined,
      };
    });
  }

  setMaxValue(index: number) {
    const minVal = this.filterRequest.rangeFilters[index].minValue;
    this.filterRequest.rangeFilters[index].maxValue = minVal;
    console.log(
      '🚀 ~ setMaxValue ~       this.filterRequest.rangeFilters[index]:',
      this.filterRequest.rangeFilters[index]
    );
  }
  onSubmit() {
    this.filterChange.emit();
    this.isButtonClicked = true;
    setTimeout(() => {
      this.isButtonClicked = false;
    }, 500);
  }

  toggleProperty(index: number): void {
    this.expandedPropertyIndex = index;
  }

  isPropertyExpanded(index: number): boolean {
    return this.expandedPropertyIndex === index;
  }

 
}
