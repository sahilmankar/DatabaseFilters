import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FilterOption } from '../FilterOption';
import { EqualPropertiesDataSource } from 'src/app/equalPropDataSource';
import { FilterRequest } from '../filter-request';
import { CategorizedFilterProperties } from '../CategorizedFilterProperties';

@Component({
  selector: 'combined-filters',
  templateUrl: './combined-filters.component.html',
  styleUrls: ['./combined-filters.component.css'],
})
export class CombinedFiltersComponent {
  @Input() filterRequest!: FilterRequest;
  @Input() equalPropertiesDataSources!: EqualPropertiesDataSource[];
  @Input() categorizedProperties!: CategorizedFilterProperties;
  @Output() filterChange = new EventEmitter<void>();
  FilterOption = FilterOption;
  @Input() selectedOption: FilterOption | null = null;

  onfilterChange() {
    this.filterChange.emit();
  }
}
