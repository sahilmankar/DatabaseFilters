import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FilterRequest } from '../filter-request';
import { FiltersService } from '../filters.service';

@Component({
  selector: 'app-sort-by',
  templateUrl: './sort-by.component.html',
  styleUrls: ['./sort-by.component.css']
})
export class SortByComponent {
  @Input() filterRequest: FilterRequest | undefined;
  @Output() filterChange = new EventEmitter<void>();

  sortByProperties: string[] =[]

  constructor( private filterservice: FiltersService) { }
  ngOnInit(): void {
    // fetching all properties for sorting
    this.filterservice.getAllProperties().subscribe((response) => {
      this.sortByProperties = response;
    });
  }

  onChange(){
    this.filterChange.emit();
  }
}
