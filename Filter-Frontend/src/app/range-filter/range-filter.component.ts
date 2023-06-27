import { Component, EventEmitter, HostListener, Input, OnInit, Output } from '@angular/core';
import { FilterRequest } from '../filter-request';
import { FiltersService } from '../filters.service';

@Component({
  selector: 'app-range-filter',
  templateUrl: './range-filter.component.html',
  styleUrls: ['./range-filter.component.css']
})
export class RangeFilterComponent implements OnInit {

  @Input() filterRequest!: FilterRequest ;
  @Output() filterChange = new EventEmitter<void>();
  expandedPropertyIndex: number = 0;
  rangeProperties: string[] = [];
  isButtonClicked: boolean=false;
  initializationDone: boolean = false;

  constructor( private filterservice: FiltersService) { }

  ngOnInit(): void {
    const initializationStatus = sessionStorage.getItem('rangeFilterInitializationDone');
    if (initializationStatus === 'true') {
      this.initializationDone = true;
    }

   this.filterservice.getCategorizedProperties().subscribe((response) => {
      this.rangeProperties = response.rangeProperties;
      if (!this.initializationDone) {
        this.initializeRangeFilters();
        this.initializationDone = true;
        sessionStorage.setItem('rangeFilterInitializationDone', 'true');
      }
    });
  }

  initializeRangeFilters() {
    this.filterRequest.rangeFilters = this.rangeProperties.map(property => {
      return { propertyName: property, minValue: undefined, maxValue: undefined };
    });
  }

  setMaxValue(index: number) {
    const minVal = this.filterRequest.rangeFilters[index].minValue;
      this.filterRequest.rangeFilters[index].maxValue = minVal;
      console.log("🚀 ~ setMaxValue ~       this.filterRequest.rangeFilters[index]:",       this.filterRequest.rangeFilters[index]);
      
  }
  onSubmit(){
    this.filterChange.emit();
    this.isButtonClicked=true;
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

  @HostListener('window:beforeunload', ['$event'])
  onBeforeUnload(): void {
    sessionStorage.removeItem('dateFilterInitializationDone');
    sessionStorage.removeItem('equalFilterInitializationDone');
    sessionStorage.removeItem('rangeFilterInitializationDone');
  }
}
