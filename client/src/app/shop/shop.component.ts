import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
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

  @ViewChild('search', {static: true}) searchTerm: ElementRef;
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
    this.shopParams.pageNumber = 1;
    this.getUsers();
  }
  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getUsers();
  }

  onPageChanged(event: any) {
    if(this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getUsers();
    }
    
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getUsers();
  }
 
  onReset()
  {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getUsers();
  }

}
