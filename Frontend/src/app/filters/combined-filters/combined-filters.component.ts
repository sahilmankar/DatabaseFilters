import {
  Component,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
} from '@angular/core';
import { FilterOption } from '../FilterOption';
import { EqualPropertiesDataSource } from 'src/app/filters/EqualPropertiesDataSource';
import { FilterRequest } from '../filter-request';
import { CategorizedFilterProperties } from '../CategorizedFilterProperties';
import { FilterService } from '../filter.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'combined-filters',
  templateUrl: './combined-filters.component.html',
  styleUrls: ['./combined-filters.component.css'],
})
export class CombinedFiltersComponent implements OnInit, OnDestroy {
  @Input() filterRequest!: FilterRequest;
  @Input() equalPropertiesDataSources!: EqualPropertiesDataSource[];
  @Input() categorizedProperties!: CategorizedFilterProperties;
  @Output() filterChange = new EventEmitter<void>();

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
  onfilterChange() {
    this.filterChange.emit();
  }
  ngOnDestroy(): void {
    this.filterOptionsubscription?.unsubscribe();
  }
}
