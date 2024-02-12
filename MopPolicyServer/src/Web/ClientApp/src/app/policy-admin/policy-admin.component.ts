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
export class PolicyAdminComponent implements OnInit  {
  policies: PolicyDto[];

  constructor(
    private policyClient: PolicyClient,
    private oauthService: OAuthService
  ) {
    this.oauthService.configure(authCodeFlowConfig);
    this.oauthService.loadDiscoveryDocumentAndLogin();

    // Automatically load user profile
    this.oauthService.events
      .pipe(filter((e) => e.type === 'token_received'))
      .subscribe((_) => this.oauthService.loadUserProfile());
  }

  ngOnInit(): void {
    this.policyClient.getPoliciesWithPagination().subscribe(
      result => {
        this.policies = result.items;
        // this.priorityLevels = result.priorityLevels;
        // if (this.policies.length) {
        //   this.selectedList = this.policies[0];
        // }
      },
      error => console.error(error)
    );
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
