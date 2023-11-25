export class CategorizedFilterProperties {
  constructor(
    public equalProperties: string[],
    public rangeProperties: string[],
    public dateRangeProperties: string[],
    public allProperties: string[]
  ) {}
}
