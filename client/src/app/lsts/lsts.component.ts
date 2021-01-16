import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ILst } from '../shared/models/ILst';
import { LstsService } from './lsts.service';

@Component({
  selector: 'app-lsts',
  templateUrl: './lsts.component.html',
  styleUrls: ['./lsts.component.scss']
})
export class LstsComponent implements OnInit {

  lsts: ILst[];
  constructor(
    private lstsService: LstsService, 
    private activatedRoute: ActivatedRoute, 
    private router: Router,
    private bcService: BreadcrumbService) { 
      this.bcService.set('@lstDetails', '');
      this.getRootLsts();
  }

  ngOnInit() {
    this.getRootLsts();
  }

  goToChildren(id: string) {
    this.lsts = [];
  //  this.router.navigateByUrl('lsts/' + id);
    this.getLstById(id);
  }

  getRootLsts() {
    const lstId = this.activatedRoute.snapshot.paramMap.get('id');
    if(lstId !== null && lstId !== undefined) {
      this.lstsService.getLstsById(lstId).subscribe((lsts: ILst) => {
        this.lsts = lsts.childrens;
        this.bcService.set('@lstDetails', lsts.name);
      })
    } else {
        this.lstsService.getLsts().subscribe((lsts: ILst[]) => {
        this.lsts = lsts;
      })
    }
    
  }

  getLstById(id: string) {
    this.lstsService.getLstsById(id).subscribe((lsts: ILst) => {
      this.lsts = lsts.childrens;
      this.bcService.set('@lstDetails', lsts.name);
    })
  }
  

}
