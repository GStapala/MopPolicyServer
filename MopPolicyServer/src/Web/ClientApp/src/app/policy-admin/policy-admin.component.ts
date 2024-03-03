import {Component, OnInit} from '@angular/core';
import {TodoItemsClient, TodoListDto, TodoListsClient} from "../web-api-client";
import {PolicyClient, PolicyDto} from "../policy-web-api-client";
import {BsModalService} from "ngx-bootstrap/modal";
import {OAuthService} from "angular-oauth2-oidc";
import {authCodeFlowConfig} from "../auth.config";
import {filter} from "rxjs";

@Component({
  selector: 'app-policy-admin-component',
  templateUrl: './policy-admin.component.html'
})
export class PolicyAdminComponent {
  policies: PolicyDto[];

  constructor(
    private policyClient: PolicyClient,
    private oauthService: OAuthService
  ) {
    this.oauthService.configure(authCodeFlowConfig);
    if (oauthService.getAccessTokenExpiration() < new Date().getTime()) {
      this.oauthService.loadDiscoveryDocumentAndLogin().then(() => {
        // Automatically load user profile
        this.oauthService.events
          .pipe(filter((e) => e.type === 'token_received'))
          .subscribe((_) => this.oauthService.loadUserProfile());
      });
    }
  }

  get userName(): string {
    const claims = this.oauthService.getIdentityClaims();
    if (!claims) return null;
    return claims['given_name'];
  }

  get idToken(): string {
    return this.oauthService.getIdToken();
  }

  get accessToken(): string {
    return this.oauthService.getAccessToken();
  }

  refresh() {
    this.oauthService.refreshToken();
  }
}
