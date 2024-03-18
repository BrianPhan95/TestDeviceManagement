import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'TDM',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:7000/',
    redirectUri: baseUrl,
    clientId: 'TDM_App',
    responseType: 'code',
    scope: 'IdentityService AdministrationService SaaSService DeviceService',
    requireHttps: false,
  },
  apis: {
    default: {
      url: 'https://localhost:7500',
      rootNamespace: 'TDM',
    },
  },
} as Environment;
