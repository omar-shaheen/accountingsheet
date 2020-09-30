import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UseroneComponent } from './userone.component';

describe('UseroneComponent', () => {
  let component: UseroneComponent;
  let fixture: ComponentFixture<UseroneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UseroneComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UseroneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
