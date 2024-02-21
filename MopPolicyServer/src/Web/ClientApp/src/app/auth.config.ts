import { AuthConfig } from 'angular-oauth2-oidc';

export const authCodeFlowConfig: AuthConfig = {
  issuer: 'https://localhost:44310',
  redirectUri: window.location.origin + '/policy-admin',
  clientId: 'AngularApp',
  responseType: 'code',
  scope: 'openid profile email offline_access policyServer_api',
  showDebugInformation: true,
  timeoutFactor: 0.01,
};
