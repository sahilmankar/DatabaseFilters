import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FilterRequest } from './filter-request';


@Injectable({
  providedIn: 'root'
})
export class FiltersService {

  constructor(private http: HttpClient) { }

  sendFilterRequest(filterRequest: FilterRequest, pageNumber: number): Observable<any> {
    const apiEndpoint: string = "http://localhost:5141/api/farmers/filter/3";
    const params = new HttpParams().set('pageNumber', pageNumber.toString());

    return this.http.post<any[]>(apiEndpoint, filterRequest, { params: params, observe: 'response' });
  }

  getCategorizedProperties(): Observable<any> {
    let url = "http://localhost:5141/api/filterhelper/categorizedproperties"
    return this.http.get<any>(url);
  }

  getProperties(): Observable<any> {
    let url = "http://localhost:5141/api/filterhelper/getpropertynames"
    return this.http.get<any>(url);
  }

  getCrops(): Observable<any> {
    let url = "http://localhost:5141/api/farmers/getcrops"
    return this.http.get<any>(url);
  }

  getContainerTypes(): Observable<any> {
    let url = "http://localhost:5141/api/farmers/getcontainertypes"
    return this.http.get<any>(url);
  }
  
  getGrades(): Observable<any> {
    let url = "http://localhost:5141/api/farmers/getgrades"
    return this.http.get<any>(url);
  }

}
