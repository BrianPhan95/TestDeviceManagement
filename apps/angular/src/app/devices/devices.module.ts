import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DevicesRoutingModule } from './devices-routing.module';
import { SharedModule } from '../shared/shared.module';
import { DeviceComponent } from './device.component';


@NgModule({
  declarations: [
    DeviceComponent
  ],
  imports: [
    CommonModule,
    DevicesRoutingModule,
    SharedModule,
  ]
})
export class DevicesModule { }
