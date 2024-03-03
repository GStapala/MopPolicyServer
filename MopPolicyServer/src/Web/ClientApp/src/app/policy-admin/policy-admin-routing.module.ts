import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {PolicyAdminComponent} from "./policy-admin.component";

// import { TutorialComponent } from './tutorial.component';

const routes: Routes = [
  {
    path: '', component: PolicyAdminComponent, children: [
      {path: 'policy-admin', component: PolicyAdminComponent}
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PolicyAdminRoutingModule {
}
