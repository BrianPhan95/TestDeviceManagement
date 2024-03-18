import type { DeviceDto, CreateUpdateDeviceDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DeviceService {
  apiName = 'devices';
  

  create = (input: CreateUpdateDeviceDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DeviceDto>({
      method: 'POST',
      url: '/api/device',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/device/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DeviceDto>({
      method: 'GET',
      url: `/api/device/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<DeviceDto>>({
      method: 'GET',
      url: '/api/device',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateDeviceDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DeviceDto>({
      method: 'PUT',
      url: `/api/device/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
