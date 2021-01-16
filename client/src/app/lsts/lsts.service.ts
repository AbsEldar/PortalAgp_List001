import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILst } from '../shared/models/ILst';

@Injectable({
  providedIn: 'root'
})
export class LstsService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getLsts() {
    return this.http.get<ILst[]>(this.baseUrl + 'list/rootdog')
  }

  getLstsById(id: string) {
    return this.http.get<ILst>(this.baseUrl + 'list/getLstDog/' + id)
  }
}
