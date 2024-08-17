import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalAsignComponent } from './modal-asign.component';

describe('ModalAsignComponent', () => {
  let component: ModalAsignComponent;
  let fixture: ComponentFixture<ModalAsignComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ModalAsignComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalAsignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
