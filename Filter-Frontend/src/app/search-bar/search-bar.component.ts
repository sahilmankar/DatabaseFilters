import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FilterRequest } from '../filter-request';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent {
  @Input() filterRequest!: FilterRequest ;
  @Output() filterChange = new EventEmitter<void>();
  
  onSearch(){
    this.filterChange.emit();
  }
}
