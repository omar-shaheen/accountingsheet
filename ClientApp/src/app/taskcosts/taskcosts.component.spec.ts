import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskcostsComponent } from './taskcosts.component';

describe('TaskcostsComponent', () => {
  let component: TaskcostsComponent;
  let fixture: ComponentFixture<TaskcostsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaskcostsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskcostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
