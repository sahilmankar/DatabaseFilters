import { Component, EventEmitter, HostListener, Input, OnInit, Output } from '@angular/core';
import { FilterRequest } from '../filter-request';
import { FiltersService } from '../filters.service';

@Component({
  selector: 'app-equal-filter',
  templateUrl: './equal-filter.component.html',
  styleUrls: ['./equal-filter.component.css']
})
export class EqualFilterComponent implements OnInit {

  @Input() filterRequest!: FilterRequest;
  @Output() filterChange = new EventEmitter<void>();
  equalProperties: any[] =[]
  selectedPropertyIndex: number = -1;
  initializationDone: boolean = false;
  

  crops: any[] = []
  // ["Potato", "Tomato"];
  grades: any[] = []
  // ["A", "B", "C", "D"];
  containerTypes: any[] = []
  // ["bags", "lenobags", "crates"]
  constructor(private filterservice: FiltersService) { }
  ngOnInit(): void {
    const initializationStatus = sessionStorage.getItem('equalFilterInitializationDone');
    if (initializationStatus === 'true') {
      this.initializationDone = true;
    }
    this.filterservice.getCategorizedProperties().subscribe((response) => {
      this.equalProperties = response.equalProperties
      this.equalProperties= this.equalProperties.map(item => {
        return { name:item, expanded: false };
      });
      if (!this.initializationDone) {
        this.initializeEqualFilters();
        this.initializationDone = true;
        sessionStorage.setItem('equalFilterInitializationDone', 'true');
      }
      this.toggleProperty(0);
    });

    //fetching crop names
    this.filterservice.getCrops().subscribe((response) => {
      this.crops = response;
    });

    //fetching grades
    this.filterservice.getGrades().subscribe((response) => {
      this.grades = response;
    });

    //fetching containerTypes
    this.filterservice.getContainerTypes().subscribe((response) => {
      this.containerTypes = response;
    });

  }
// intialize all equal propeties with empty array of values
  initializeEqualFilters() {
    this.filterRequest.equalFilters = this.equalProperties.map(property => {
      return { propertyName: property.name, propertyValues: [] };
    });
  }

  onCheckboxChange(value: string, index: number) {
    const propertyValues = this.filterRequest.equalFilters[index].propertyValues;

    if (propertyValues?.includes(value)) {
      // Remove value from propertyValues array if it's already present
      const valueIndex = propertyValues.indexOf(value);
      propertyValues.splice(valueIndex, 1);
    } else {
      // Add value to propertyValues array if it's not already present
      propertyValues.push(value);
    }
    this.filterChange.emit();
  }
// expanding the property whose index matches
  toggleProperty(index: number): void {
    this.selectedPropertyIndex = index;
    for (let i = 0; i < this.equalProperties.length; i++) {
      this.equalProperties[i].expanded = (i === index);
    }
  }
// check property is expanded or not 
  isPropertyExpanded(property: any): boolean {
    return property.expanded;
  }
  // to check active menu
  isPropertySelected(index: number): boolean {
    return this.selectedPropertyIndex === index;
  }

  // removing  session data of initalize Filter
  @HostListener('window:beforeunload', ['$event'])
  onBeforeUnload(): void {
    sessionStorage.removeItem('dateFilterInitializationDone');
    sessionStorage.removeItem('equalFilterInitializationDone');
    sessionStorage.removeItem('rangeFilterInitializationDone');
  }
}
