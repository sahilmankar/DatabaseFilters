import { DateRangeFilter } from "./date-range-filter";
import { EqualFilter } from "./equal-filter";
import { RangeFilter } from "./range-filter";

export class FilterRequest {
    constructor(
       public equalFilters: EqualFilter[] ,
       public rangeFilters: RangeFilter[] ,
       public dateRangeFilters: DateRangeFilter[] ,
       public sortBy: string | undefined,
       public searchString:string | undefined,
       public sortAscending: boolean
    ){}
}
