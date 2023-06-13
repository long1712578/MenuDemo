import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuInfomationComponent } from './menu-infomation.component';

describe('MenuInfomationComponent', () => {
  let component: MenuInfomationComponent;
  let fixture: ComponentFixture<MenuInfomationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuInfomationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuInfomationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
