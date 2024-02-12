import {Component, OnInit} from '@angular/core';

import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';

import {PolicyClient, PolicyDto} from "../../policy-web-api-client";
import {MatSlideToggleModule} from "@angular/material/slide-toggle";

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];

@Component({
  standalone: true,
  selector: 'policies-component',
  templateUrl: './policies.component.html',
  imports: [MatButtonModule, MatTableModule, MatSlideToggleModule],

})
export class PoliciesComponent implements OnInit {
  policies: PolicyDto[];
  displayedColumns: string[] = ['name', 'weight', 'symbol', 'position'];
  columnsToDisplay: string[] = this.displayedColumns.slice();
  data: PeriodicElement[] = ELEMENT_DATA;

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
}
