import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeviceBookingComponent } from './device-booking.component';

describe('DeviceBookingComponent', () => {
  let component: DeviceBookingComponent;
  let fixture: ComponentFixture<DeviceBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeviceBookingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DeviceBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
