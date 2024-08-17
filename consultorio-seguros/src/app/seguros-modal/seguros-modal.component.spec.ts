import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SegurosModalComponent } from './seguros-modal.component';

describe('SegurosModalComponent', () => {
  let component: SegurosModalComponent;
  let fixture: ComponentFixture<SegurosModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SegurosModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SegurosModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
