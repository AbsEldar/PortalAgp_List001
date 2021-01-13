import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IDepartment } from '../shared/models/IDepartment';
import { IPagination } from '../shared/models/IPagination';
import { map, delay } from 'rxjs/operators';
import { ShopParams } from '../shared/models/ShopParams';
import { IUser } from '../shared/models/IUser';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getUsers(shopParams: ShopParams) {

    let params = new HttpParams();
    
    if(shopParams.departmentId != '') {
      params = params.append('departmentId', shopParams.departmentId.toString());
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    // if (shopParams.sort) {
    //   params = params.append('sort', shopParams.sort);
    // }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());
    
    return this.http.get<IPagination>(this.baseUrl + 'users/getAllWithSpec', {observe: 'response', params})
    .pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getUser(id: string) {
    return this.http.get<IUser>(this.baseUrl + 'users/getUser/' + id);
  }

  getDepartments() {
    return this.http.get<IDepartment[]>(this.baseUrl + 'departments/getAllDepDtos')
  }

}
