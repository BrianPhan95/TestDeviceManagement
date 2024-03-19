import { mapEnumToOptions } from '@abp/ng.core';

export enum DeviceStatus {
    Available = 0,
    Unavailable = 1,
}

export const deviceStatusOptions = mapEnumToOptions(DeviceStatus);
