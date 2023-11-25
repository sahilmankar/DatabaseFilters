import { Observable } from 'rxjs';

export class EqualPropertiesDataSource {
  constructor(
    public key: string,
    // public fetcher: Observable<string[]>,
    public fetcher: (searchString: string) => Observable<string[]>,
    public dataStore: string[]
  ) {}
}
