import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskcostdetailComponent } from './taskcostdetail.component';

describe('TaskcostdetailComponent', () => {
  let component: TaskcostdetailComponent;
  let fixture: ComponentFixture<TaskcostdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaskcostdetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskcostdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
