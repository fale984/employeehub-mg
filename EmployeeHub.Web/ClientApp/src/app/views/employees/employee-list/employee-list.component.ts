import { Component, OnInit, Input } from '@angular/core';
import { HubEmployee } from 'src/app/models/hub-employee.model';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent implements OnInit {
  @Input() employees: HubEmployee[];

  constructor() { }

  ngOnInit() {
  }

}
