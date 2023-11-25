import {
  Component,
  EventEmitter,
  Input,
  Output,
  SimpleChange,
  SimpleChanges,
} from "@angular/core";
import { FilterRequest } from "../filter-request";


@Component({
  selector: "date-filter",
  templateUrl: "./date-filter.component.html",
  styleUrls: ["./date-filter.component.css"],
})
export class DateFilterComponent {
  @Input() filterRequest!: FilterRequest;
  @Input() dateProperties!: string[];
  @Output() filterChange = new EventEmitter<void>();
  isButtonClicked: boolean = false;
  expandedPropertyIndex: number = 0;
  initializationDone: boolean = false;



  ngOnChanges(changes: SimpleChanges) {
    if (changes["dateProperties"].currentValue) {
      this.initializeDateFilters();
    }
  }

  initializeDateFilters() {
    this.filterRequest.dateRangeFilters = this.dateProperties.map(
      (property) => {
        return { propertyName: property, fromDate: "", toDate: "" };
      }
    );
  }

  updateToDate(index: number) {
    const fromDate = this.filterRequest.dateRangeFilters[index].fromDate;
    if (fromDate && this.filterRequest.dateRangeFilters[index].toDate == "") {
      const fromDateObj = new Date(fromDate);
      const toDateObj = new Date(fromDateObj.getTime() + 24 * 60 * 60 * 1000); // Add one day (24 hours) to the fromDate
      this.filterRequest.dateRangeFilters[index].toDate = toDateObj
        .toISOString()
        .substring(0, 10);
    }
  }

  onSubmit() {
    this.filterChange.emit();
    this.isButtonClicked = true;
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


}
