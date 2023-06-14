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
  onEventMenuSubject = new BehaviorSubject<Menu| null>(null);
  onEventMenu$ = this.onEventMenuSubject.asObservable();
  constructor(private http: HttpClient) { 
    this.chatUrl = environment.apiUrl;
  }

  setEventMenu(menu: Menu | null) {
    this.onEventMenuSubject.next(menu);
  }

  getListMenu() {
    return this.listMenuSubject.getValue();
  };
  setListMenu(menus: Menu[]) {
    this.listMenuSubject.next(menus);
  }

  setMenuActive(menu: Menu| null) {
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

  deleteMenu(id: string): Observable<any> {
    return this.http.delete(`${this.chatUrl}/api/Menus?id=${id}`);
  }
}
