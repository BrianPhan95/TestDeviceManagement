import { Injector, Pipe, PipeTransform } from '@angular/core';
import { DeviceStatus } from '@proxy/devices/device-status.enum';

@Pipe({
    name: 'deviceStatus'
})
export class DeviceStatusPipe implements PipeTransform {

    constructor() {
    }

    transform(value: number): string {
        if (value === DeviceStatus.Available) {
            return 'Available';
        } else if (value === DeviceStatus.Unavailable) {
            return 'Unavailable';
        } 
        return '';
    }
}
