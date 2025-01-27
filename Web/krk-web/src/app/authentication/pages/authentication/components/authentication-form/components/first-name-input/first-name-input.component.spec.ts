import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FirstNameInputComponent } from './first-name-input.component';

describe('FirstNameInputComponent', () => {
  let component: FirstNameInputComponent;
  let fixture: ComponentFixture<FirstNameInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FirstNameInputComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FirstNameInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
