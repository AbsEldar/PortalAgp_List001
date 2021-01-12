import { Component, OnInit } from '@angular/core';
import { IDepartment } from '../shared/models/IDepartment';
import { IUser } from '../shared/models/IUser';
import { ShopParams } from '../shared/models/ShopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  users: IUser[];
  departments: IDepartment[];
  // departmentIdSelected = '';
  // sortSelected = 'name';

  shopParams = new ShopParams();
  totalCount: number;

  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Имя: Low to High', value: 'nameAsc'},
    {name: 'Имя: High to Low', value: 'nameDesc'}
  ];
  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getUsers();
    this.getDepartments();
  }

  getUsers() {
    this.shopService.getUsers(this.shopParams).subscribe(response => {
      this.users = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  getDepartments() {
    this.shopService.getDepartments().subscribe((deps: IDepartment[]) => {
      this.departments = deps;
    }, error => {
      console.log(error);
    });
  }

  onDepartmentSelected(departmentId: string) {
    this.shopParams.departmentId = departmentId;
    this.getUsers();
  }
  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getUsers();
  }

  onPageChanged(event: any) {
    this.shopParams.pageNumber = event.page;
    this.getUsers();
  }

}
