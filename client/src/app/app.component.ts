import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/IPagination';
import { IUser } from './models/IUser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  users: IUser[];
 
  constructor(private http: HttpClient) {}
 
  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/users/getAllWithSpec?pageSize=50')
    .subscribe((response: IPagination) => {
      this.users = response.data;
    }, error => {
      console.log(error);
    });
  }

}
