import {
  Component,
  EventEmitter,
  Input,
  Output,
  SimpleChanges,
} from '@angular/core';
import { FilterRequest } from '../filter-request';
import { EqualPropertiesDataSource } from 'src/app/equalPropDataSource';
import { SessionstorageKeys } from '../SessionstorageKeys';

@Component({
  selector: 'equal-filter',
  templateUrl: './equal-filter.component.html',
  styleUrls: ['./equal-filter.component.css'],
})
export class EqualFilterComponent {
  searchString: string | undefined;

  @Input() filterRequest!: FilterRequest;
  @Input() equalPropertiesDataSources!: EqualPropertiesDataSource[];
  @Output() filterChange = new EventEmitter<void>();
  expandedPropertyIndex: number = 0;
  initializationDone: boolean = false;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['equalPropertiesDataSources'].currentValue) {
      if(!sessionStorage.getItem(SessionstorageKeys.equalfilterintializationdone)==true){
      this.initializeEqualFilters();
        this.equalPropertiesDataSources.forEach((item) => {
        item.fetcher('').subscribe((res) => {
          item.dataStore = res;
        });
      });
    }
  }
  }

  refetchDataStore(index: number) {
    if (this.searchString != undefined && this.searchString != '') {
      this.equalPropertiesDataSources[index]
        .fetcher(this.searchString)
        .subscribe((res) => {
          this.equalPropertiesDataSources[index].dataStore = res;
        });
    }
  }

  initializeEqualFilters() {
    sessionStorage.setItem(SessionstorageKeys.equalfilterintializationdone,"true");
    this.filterRequest.equalFilters = this.equalPropertiesDataSources.map(
      (property) => {
        return { propertyName: property.key, propertyValues: [] };
      }
    );
  }

  onCheckboxChange(value: string, index: number) {
    const propertyValues =
      this.filterRequest.equalFilters[index].propertyValues;

    if (propertyValues?.includes(value)) {
      const valueIndex = propertyValues.indexOf(value);
      propertyValues.splice(valueIndex, 1);
    } else {
      propertyValues.push(value);
    }
    this.filterChange.emit();
  }

  toggleProperty(index: number): void {
    this.expandedPropertyIndex = index;
  }

  isPropertyExpanded(index: number): boolean {
    return this.expandedPropertyIndex === index;
  }

}
