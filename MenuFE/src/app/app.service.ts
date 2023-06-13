import { Injectable } from '@angular/core';
import { Menu, Menus } from './shared/models/menu';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  private listMenuSubject =  new BehaviorSubject<Menu[]>([]);
  listMenu$ = this.listMenuSubject.asObservable();

  chatUrl = '';
  constructor(private http: HttpClient) { 
    this.chatUrl = environment.apiUrl;
  }

  getListMenu() {
    return this.listMenuSubject.getValue();
  };
  setListMenu(menus: Menu[]) {
    this.listMenuSubject.next(menus);
  }

  getPagingMenus(skipCount: number, maxCount: number): Observable<Menus> {
    return this.http.get<Menus>(`${this.chatUrl}/api/Menus?SkipCount=${skipCount}&MaxCount=${maxCount}`);
  }
}
