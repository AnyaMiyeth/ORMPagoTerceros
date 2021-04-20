import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistroTerceroComponent } from './registro-tercero.component';

describe('RegistroTerceroComponent', () => {
  let component: RegistroTerceroComponent;
  let fixture: ComponentFixture<RegistroTerceroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistroTerceroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistroTerceroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
