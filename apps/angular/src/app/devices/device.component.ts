import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { DeviceDto, DeviceService } from '@proxy/devices';
import { FormGroup,FormBuilder, Validators } from '@angular/forms';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrl: './device.component.scss',
  providers: [ListService],
})
export class DeviceComponent implements OnInit{

  devices = { items: [], totalCount: 0 } as PagedResultDto<DeviceDto>;
  isModalOpen = false;

  form: FormGroup;

  selectedDevice = {} as DeviceDto;

  constructor(public readonly list: ListService, 
    private deviceService: DeviceService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService) {}

  ngOnInit() {
    const deviceStreamCreator = (query) => this.deviceService.getList(query);

    this.list.hookToQuery(deviceStreamCreator).subscribe((response) => {
      this.devices = response;
    });
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
      name: [this.selectedDevice.name || '', Validators.required]
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
}
