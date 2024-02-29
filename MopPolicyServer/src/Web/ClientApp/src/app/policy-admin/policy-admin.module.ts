import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';


import {HttpClientModule} from '@angular/common/http';
import {PolicyAdminComponent} from "./policy-admin.component";
import {PolicyAdminRoutingModule} from "./policy-admin-routing.module";
import {MatButtonModule} from "@angular/material/button";
import {MatTableModule} from "@angular/material/table";
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import {AppModule} from "../app.module";
import {PoliciesComponent} from "./policies/policies.component";


@NgModule({
  declarations: [
    PolicyAdminComponent,
    PoliciesComponent
  ],
  imports: [
    MatButtonModule, MatTableModule, MatSlideToggleModule,
    CommonModule,
    PolicyAdminRoutingModule,
    HttpClientModule,
  ],
  exports: [
    PolicyAdminComponent,
  ],
  providers: [],
})
export class PolicyAdminModule {
}
