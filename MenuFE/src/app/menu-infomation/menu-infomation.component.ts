import { Component, Input, OnInit } from '@angular/core';
import { AppService } from '../app.service';
import { Menu } from '../shared/models/menu';

@Component({
  selector: 'app-menu-infomation',
  templateUrl: './menu-infomation.component.html',
  styleUrls: ['./menu-infomation.component.scss']
})
export class MenuInfomationComponent implements OnInit {

  menu!: Menu|null;
  name = '';
  isUpdateDisabled = true;
  menuName = '';
  isAddMenu = false;
  constructor(private appService: AppService) { }

  ngOnInit(): void {
    this.getMenuActive();
  }

  getMenuActive() {
    this.appService.menuActive$.subscribe({
      next: (menu) => {
        this.menu = menu;
        this.name = menu?.name?? '';
      }
    })
  }
  editMenu() {
    if(!this.isUpdateDisabled) {
      this.updateMenu();
    }
    this.isUpdateDisabled = !this.isUpdateDisabled;
  }

  updateMenu() {
    this.appService.updateMenu(this.menu?.id as string, this.name).subscribe({

      next: () => {

        if(this.menu) {
          this.menu.name = this.name;
        }
      }
    })
  }

  deleteMenu() {
    this.appService.deleteMenu(this.menu?.id as string ).subscribe({
      next: () => {
        this.appService.setEventMenuDel(this.menu);
        this.menu = null;
      }
    })
  }

  handleCancel(): void {
    this.menuName = '';
    this.isAddMenu = false;
  }

  handleOk(): void {
    this.isAddMenu = false;
    this.appService.createMenu(this.menuName, this.menu?.id).subscribe({
      next: (menu) => {
        const menuNew =menu;
        this.menu?.menuDtos.push(menuNew);
        this.menuName = '';
      },
      error: () => {
        this.menuName = '';
      }
    })
  }

  showModalAddMenu(): void {
    this.isAddMenu = true;
  }
}
