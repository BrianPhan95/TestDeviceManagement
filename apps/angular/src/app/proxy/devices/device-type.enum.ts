import { mapEnumToOptions } from '@abp/ng.core';

export enum DeviceType {
    Unknown = 0,
    Tablet = 1,
    SmartPhone = 2,
}

export const deviceTypeOptions = mapEnumToOptions(DeviceType);
