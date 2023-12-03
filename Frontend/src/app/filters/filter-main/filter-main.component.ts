import { Component, EventEmitter, Input, Output, TemplateRef } from '@angular/core';
import { CategorizedFilterProperties } from '../CategorizedFilterProperties';
import { EqualPropertiesDataSource } from '../EqualPropertiesDataSource';
import { FilterRequest } from '../filter-request';
import { PaginationHeader } from '../paginationHeader';
import { Subscription } from 'rxjs';
import { FilterOption } from '../FilterOption';
import { FilterService } from '../filter.service';

@Component({
  selector: 'filter-main',
  templateUrl: './filter-main.component.html',
  styleUrls: ['./filter-main.component.css']
})
export class FilterMainComponent {

  @Input() templateToRender!: TemplateRef<any>;
  @Input() filterRequest!: FilterRequest;
  @Input() equalPropertiesDataSources!: EqualPropertiesDataSource[];
  @Input() categorizedProperties!: CategorizedFilterProperties;
  @Input() paginationData: PaginationHeader | null = null;
  @Output() filterChange = new EventEmitter<number>();

  FilterOption = FilterOption;
  selectedOption: FilterOption | null = null;

  filterOptionsubscription: Subscription | undefined;

  constructor(private filtersvc: FilterService) {}

  ngOnInit(): void {
    this.filterOptionsubscription =
      this.filtersvc.filterOptionSelected$.subscribe((res) => {
        this.selectedOption = res;
      });
  }

  onFilterChange(){
    this.filterChange.emit();
  }

  onReceivePageNumber(page:number){
    this.filterChange.emit(page);
  }

}
