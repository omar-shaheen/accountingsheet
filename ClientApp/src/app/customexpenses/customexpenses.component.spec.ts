import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomexpensesComponent } from './customexpenses.component';

describe('CustomexpensesComponent', () => {
  let component: CustomexpensesComponent;
  let fixture: ComponentFixture<CustomexpensesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomexpensesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomexpensesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
