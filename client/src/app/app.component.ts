import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/IPagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  users: any[];
 
  constructor(private http: HttpClient) {}
 
  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/users/getAllWithSpec?sort=nameDesc&search=07&pageIndex=1&pageSize=50')
    .subscribe((response: IPagination) => {
      this.users = response.data;
    }, error => {
      console.log(error);
    });
  }

}
