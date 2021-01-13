import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IUser } from 'src/app/shared/models/IUser';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.scss']
})
export class UserDetailsComponent implements OnInit {

  user: IUser;
  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.loadUser();
  }

  loadUser() {
    this.shopService.getUser(this.activatedRoute.snapshot.paramMap.get('id')).subscribe(user => {
      this.user = user;
    }, error => {
      console.log(error);
    })
  }

}
