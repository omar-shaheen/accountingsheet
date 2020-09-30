import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsertwoComponent } from './usertwo.component';

describe('UsertwoComponent', () => {
  let component: UsertwoComponent;
  let fixture: ComponentFixture<UsertwoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsertwoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsertwoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
