import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthlyinputComponent } from './monthlyinput.component';

describe('MonthlyinputComponent', () => {
  let component: MonthlyinputComponent;
  let fixture: ComponentFixture<MonthlyinputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MonthlyinputComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MonthlyinputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
