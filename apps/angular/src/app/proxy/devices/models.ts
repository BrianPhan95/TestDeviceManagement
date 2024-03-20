import { DeviceStatus } from "./device-status.enum";
import { DeviceType } from "./device-type.enum";

export interface DeviceDto {
  id: string,
  name?: string;
  deviceType: DeviceType;
  deviceStatus: DeviceStatus;
  bookingBy: string;
}

export interface CreateUpdateDeviceDto {
  id?: string,
  name: string;
  deviceType: DeviceType;
}
