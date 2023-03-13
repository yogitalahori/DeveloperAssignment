import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddItemDataRowComponent } from './add-item-data-row.component';

describe('AddItemDataRowComponent', () => {
  let component: AddItemDataRowComponent;
  let fixture: ComponentFixture<AddItemDataRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddItemDataRowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddItemDataRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
