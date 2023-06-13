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
  maxCount = 3;
  constructor(private appService: AppService) {
  }

  ngOnInit(): void {
    this.getPadingMenu();
  }

  getPadingMenu() {
    this.appService.getPagingMenus(this.skipCount, this.maxCount).subscribe((menus: Menus) => {
      this.appService.setListMenu(menus.items);
    })
  }
}
