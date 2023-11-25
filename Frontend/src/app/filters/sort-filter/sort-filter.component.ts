import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FilterRequest } from '../filter-request';

@Component({
  selector: 'sort-filter',
  templateUrl: './sort-filter.component.html',
  styleUrls: ['./sort-filter.component.css']
})
export class SortFilterComponent {

  @Input() filterRequest: FilterRequest | undefined;
  @Output() filterChange = new EventEmitter<void>();
  @Input() sortByProperties: string[] =[]

 

  onChange(){
    this.filterChange.emit();
  }

}
