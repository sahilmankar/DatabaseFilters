export class RangeFilter {
  constructor(
    public propertyName: string,
    public minValue: number | undefined,
    public maxValue: number | undefined
  ) {}
}
