import { CoreModule } from '@abp/ng.core';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { DeviceTypePipe } from './pipes/device-type.pipe';
import { DeviceStatusPipe } from './pipes/device-status.pipe';

@NgModule({
  declarations: [DeviceTypePipe, DeviceStatusPipe],
  imports: [
    CoreModule,
    ThemeSharedModule,
    NgbDropdownModule,
    NgxValidateCoreModule
  ],
  exports: [
    CoreModule,
    ThemeSharedModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    DeviceTypePipe,
    DeviceStatusPipe
  ],
  providers: []
})
export class SharedModule {}
