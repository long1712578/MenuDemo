import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';
import { Menus } from './shared/models/menu';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  skipCount = 0;
  maxCount = 6;
  pageIndex = 1;
  totalCount = 0;
  pageSizeOption = [3,6,9,12,15]
  isAddMenu = false;
  menuName='';
  constructor(private appService: AppService) {
  }

  ngOnInit(): void {
    this.getPadingMenu();
  }

  getPadingMenu() {
    this.appService.getPagingMenus(this.skipCount, this.maxCount).subscribe((menus: Menus) => {
      this.appService.totalCount = menus.totalCount;
      this.totalCount = menus.totalCount;
      this.appService.setListMenu(menus.items);
    })
  }

  onPageIndex(index: number) {
    this.pageIndex = index;
    this.skipCount = (index - 1 )* this.maxCount;
    this.getPadingMenu();
  }

  onPageSize(size: number) {
    this.maxCount = size;
    this.getPadingMenu();
  }
  showModalAddMenu(): void {
    this.isAddMenu = true;
  }
  handleOk(): void {
    this.isAddMenu = false;
    this.appService.createMenu(this.menuName).subscribe({
      next: () => {
        this.getPadingMenu();
        this.menuName = '';
      },
      error: () => {
        this.menuName = '';
      }
    })
  }

  handleCancel(): void {
    this.menuName = '';
    this.isAddMenu = false;
  }
}
