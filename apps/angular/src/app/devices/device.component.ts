import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto, PermissionService } from '@abp/ng.core';
import { DeviceDto, DeviceService } from '@proxy/devices';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { deviceTypeOptions } from '@proxy/devices/device-type.enum';
import { DeviceStatus } from '@proxy/devices/device-status.enum';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrl: './device.component.scss',
  providers: [ListService],
})
export class DeviceComponent implements OnInit {

  devices = { items: [], totalCount: 0 } as PagedResultDto<DeviceDto>;
  isModalOpen = false;
  types = [0, 1, 2];
  form: FormGroup;

  selectedDevice = {} as DeviceDto;
  canCheckout = false;
  canApproveReturn = false;

  constructor(public readonly list: ListService,
    private deviceService: DeviceService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    private permissionService: PermissionService) { }

  ngOnInit() {
    const deviceStreamCreator = (query) => this.deviceService.getList(query);

    this.list.hookToQuery(deviceStreamCreator).subscribe((response) => {
      this.devices = response;
    });

    this.canCheckout = this.permissionService.getGrantedPolicy('DeviceService.Device.Checkout');
    this.canApproveReturn = this.permissionService.getGrantedPolicy('DeviceService.Device.Return');
  }

  createDevice() {
    this.selectedDevice = {} as DeviceDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editDevice(id: string) {
    this.deviceService.get(id).subscribe((Device) => {
      this.selectedDevice = Device;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedDevice.name || '', Validators.required],
      deviceType: [this.selectedDevice.deviceType || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedDevice.id) {
      this.deviceService
        .update(this.selectedDevice.id, this.form.value)
        .subscribe(() => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        });
    } else {
      this.deviceService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
      .subscribe((status) => {
        if (status === Confirmation.Status.confirm) {
          this.deviceService.delete(id).subscribe(() => this.list.get());
        }
      });
  }

  allowCheckOut(status: DeviceStatus) {
    console.log(this.canCheckout);
    console.log(this.canCheckout);

    console.log(status === DeviceStatus.Available)

    return status === DeviceStatus.Available && this.canCheckout;
  }
  canReturn(status: DeviceStatus) {
    return status === DeviceStatus.Unavailable && this.canApproveReturn;
  }

  checkout(id: string) {
    this.confirmation.warn('::AreYouSureToBooking', '::AreYouSure')
      .subscribe((status) => {
        if (status === Confirmation.Status.confirm) {
          this.deviceService.checkout(id).subscribe(() => this.list.get());
        }
      });
  }

  return(id: string) {
    this.confirmation.warn('::AreYouSureToReturn', '::AreYouSure')
      .subscribe((status) => {
        if (status === Confirmation.Status.confirm) {
          this.deviceService.return(id).subscribe(() => this.list.get());
        }
      });
  }
}
