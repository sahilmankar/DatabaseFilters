export class PaginationHeader {
  constructor(
    public TotalCount: number,
    public CurrentPage: number,
    public TotalPages: number,
    public HasNext: boolean,
    public HasPrevious: boolean
  ) {}
}
