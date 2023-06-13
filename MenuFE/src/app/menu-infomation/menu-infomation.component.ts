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
}
