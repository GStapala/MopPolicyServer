import {Component, OnInit} from '@angular/core';

import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';

import {PolicyClient, PolicyDto} from "../../policy-web-api-client";
import {MatSlideToggleModule} from "@angular/material/slide-toggle";

@Component({
  // standalone: true,
  selector: 'policies-component',
  templateUrl: './policies.component.html',
  // imports: [MatButtonModule, MatTableModule, MatSlideToggleModule],

})
export class PoliciesComponent implements OnInit {
  policies: PolicyDto[];
  displayedColumns: string[] = ['id', 'name', 'description', 'created', 'edit'];
  columnsToDisplay: string[] = this.displayedColumns.slice();

  constructor(
    private policyClient: PolicyClient
  ) {

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

  addPolicy() {

  }

  editPolicy(element) {
    console.log(element)
  }
}
