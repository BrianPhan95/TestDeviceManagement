import { Injector, Pipe, PipeTransform } from '@angular/core';
import { DeviceType } from '@proxy/devices/device-type.enum';

@Pipe({
    name: 'deviceType'
})
export class DeviceTypePipe implements PipeTransform {

    constructor() {
    }

    transform(value: number): string {
        if (value === DeviceType.Unknown) {
            return 'Unknown';
        } else if (value === DeviceType.SmartPhone) {
            return 'Smart Phone';
        } else if (value === DeviceType.Tablet) {
            return 'Tablet';
        }
        return '';
    }
}
