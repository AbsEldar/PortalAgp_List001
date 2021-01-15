import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IUser } from 'src/app/shared/models/IUser';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.scss']
})
export class UserDetailsComponent implements OnInit {

  user: IUser;
  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute, private bcService: BreadcrumbService) { }

  ngOnInit() {
    this.loadUser();
  }

  loadUser() {
    this.shopService.getUser(this.activatedRoute.snapshot.paramMap.get('id')).subscribe(user => {
      this.user = user;
      this.bcService.set('@userDetails', user.name);
    }, error => {
      console.log(error);
    })
  }

}
