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
  menuActiveSubject =new BehaviorSubject<Menu|null>(null);
  menuActive$ = this.menuActiveSubject.asObservable();

  chatUrl = '';
  totalCount = 0;
  constructor(private http: HttpClient) { 
    this.chatUrl = environment.apiUrl;
  }

  getListMenu() {
    return this.listMenuSubject.getValue();
  };
  setListMenu(menus: Menu[]) {
    this.listMenuSubject.next(menus);
  }

  setMenuActive(menu: Menu) {
    this.menuActiveSubject.next(menu);
  }

  getPagingMenus(skipCount: number, maxCount: number): Observable<Menus> {
    return this.http.get<Menus>(`${this.chatUrl}/api/Menus?SkipCount=${skipCount}&MaxCount=${maxCount}`);
  }
  createMenu(menuName: string, parentId: string| null = null) : Observable<Menu> {
    let body: any = {
      name: menuName
    };
    if(parentId !== null) {

      body = {...body, parentId}
    }
    return this.http.post<Menu>(`${this.chatUrl}/api/Menus`, body);
  }

  updateMenu(id: string , name: string) : Observable<any> {
    return this.http.put<any>(`${this.chatUrl}/api/Menus?id=${id}&name=${name}`,{});
  }
}
