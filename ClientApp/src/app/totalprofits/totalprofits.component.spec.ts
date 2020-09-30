import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalprofitsComponent } from './totalprofits.component';

describe('TotalprofitsComponent', () => {
  let component: TotalprofitsComponent;
  let fixture: ComponentFixture<TotalprofitsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TotalprofitsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalprofitsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
