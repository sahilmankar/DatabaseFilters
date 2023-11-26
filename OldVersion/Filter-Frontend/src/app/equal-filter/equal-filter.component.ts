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
   
    this.filterservice.getEqualProperties().subscribe((response) => {
      this.equalProperties = response
      this.equalProperties= this.equalProperties.map(item => {
        return { name:item, expanded: false };
      });
      if (!this.initializationDone) {
        if(!this.doesPreviousRequestContainsEqualProperties()){
        this.initializeEqualFilters();
        }
        this.initializationDone = true;
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

  doesPreviousRequestContainsEqualProperties():boolean{
    const prevFilterRequest= sessionStorage.getItem("prevFilterRequest");
    if(prevFilterRequest!=null){
     const filterRequest:FilterRequest=JSON.parse(prevFilterRequest);
     return filterRequest.equalFilters.length > 0
    }
    return false;
  }

  // removing  session data of initalize Filter
  // @HostListener('window:beforeunload', ['$event'])
  // onBeforeUnload(): void {
  // }
}
