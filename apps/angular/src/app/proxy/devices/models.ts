
export interface DeviceDto {
  id: string,
  name?: string;
}

export interface CreateUpdateDeviceDto {
  id?: string,
  name: string;
}
