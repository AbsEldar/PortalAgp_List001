import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILst } from '../shared/models/ILst';
import { IUserLstAccess } from '../shared/models/IUserLstAccess';

@Injectable({
  providedIn: 'root'
})
export class LstsService {

  baseUrl = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  getLsts() {
    return this.http.get<ILst[]>(this.baseUrl + 'list/rootdog')
  }

  getLstsById(id: string) {
    return this.http.get<ILst>(this.baseUrl + 'list/getLstDog/' + id)
  }

  getLstBcById(id: string) {
    return this.http.get<ILst[]>(this.baseUrl + 'list/getBreadCrambForList/' + id)
  }

  getAccessUsersForList(id: string) {
    return this.http.get<IUserLstAccess[]>(this.baseUrl + 'list/getAccessUsersForList/' + id)
  }
}
