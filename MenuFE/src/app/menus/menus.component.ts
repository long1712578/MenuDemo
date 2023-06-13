import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Menu } from '../shared/models/menu';
import { AppService } from '../app.service';

@Component({
  selector: 'app-menus',
  templateUrl: './menus.component.html',
  styleUrls: ['./menus.component.scss']
})
export class MenusComponent implements OnInit {

  listMenu: Menu[] = [];
  constructor(private appService: AppService) {
   }

  ngOnInit(): void {
    this.onGetListMenu();
  }

  onGetListMenu() {
    this.appService.listMenu$.subscribe((result: Menu[]) => {
      this.listMenu = result;
    });
  }

}
