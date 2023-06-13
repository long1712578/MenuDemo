import { Component, Input, OnInit } from '@angular/core';
import { AppService } from 'src/app/app.service';
import { Menu } from 'src/app/shared/models/menu';

@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.scss']
})
export class MenuItemComponent implements OnInit {

  @Input() menu!: Menu;
  constructor(private appService: AppService) { }

  ngOnInit(): void {
  }

  selecMenu(menu: Menu) {
    this.appService.setMenuActive(menu);
  }

}
