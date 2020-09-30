import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContractordetailComponent } from './contractordetail.component';

describe('ContractordetailComponent', () => {
  let component: ContractordetailComponent;
  let fixture: ComponentFixture<ContractordetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContractordetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContractordetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
