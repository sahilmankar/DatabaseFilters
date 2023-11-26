import { Component, EventEmitter, HostListener, Input, Output } from '@angular/core';
import { FilterRequest } from '../filter-request';
import { FiltersService } from '../filters.service';

@Component({
  selector: 'app-date-filter',
  templateUrl: './date-filter.component.html',
  styleUrls: ['./date-filter.component.css']
})
export class DateFilterComponent {
  
  @Input() filterRequest!: FilterRequest;
  @Output() filterChange = new EventEmitter<void>();
  isButtonClicked: boolean = false;
  expandedPropertyIndex: number = 0;
  dateProperties: string[] = []
  initializationDone: boolean = false;


  constructor( private filterservice: FiltersService) { }
  ngOnInit(): void {
    
    //fetching property types
    this.filterservice.getDateRangeProperties().subscribe((response) => {
      this.dateProperties = response;
      if (!this.initializationDone) {
        if(!this.doesPreviousRequestContainsDateProperties()){
        this.initializeDateFilters();
        }
        this.initializationDone = true;
      }
    });
  }


  initializeDateFilters() {
    this.filterRequest.dateRangeFilters = this.dateProperties.map(property => {
      return { propertyName: property, fromDate: '', toDate: '' }
    });
  }


  updateToDate(index: number) {
    const fromDate = this.filterRequest.dateRangeFilters[index].fromDate;
    if (fromDate && this.filterRequest.dateRangeFilters[index].toDate == '') {
      const fromDateObj = new Date(fromDate);
      const toDateObj = new Date(fromDateObj.getTime() + (24 * 60 * 60 * 1000)); // Add one day (24 hours) to the fromDate
      this.filterRequest.dateRangeFilters[index].toDate = toDateObj.toISOString().substring(0, 10);
    }
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

  doesPreviousRequestContainsDateProperties():boolean{
    const prevFilterRequest= sessionStorage.getItem("prevFilterRequest");
    if(prevFilterRequest!=null){
     const filterRequest:FilterRequest=JSON.parse(prevFilterRequest);
     return filterRequest.dateRangeFilters.length > 0
    }
    return false;
  }

//   @HostListener('window:beforeunload', ['$event'])
//   onBeforeUnload(): void {
//     sessionStorage.removeItem('dateFilterInitializationDone');
//     sessionStorage.removeItem('equalFilterInitializationDone');
//     sessionStorage.removeItem('rangeFilterInitializationDone');

// }
}
