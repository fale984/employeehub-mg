import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { HubEmployee } from '../../models/hub-employee.model';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent implements OnInit {
  employees: HubEmployee[];
  loading = false;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
  }

  onSearch(form: NgForm) {
    if (form.invalid) {
      return;
    }

    const formData = form.value;

    // If there is id
    if (formData.employeeId) {
      this.loadEmployeeById(formData.employeeId);
    } else {
      this.loadAllEmployees();
    }
  }

  loadEmployeeById(id: any) {
    // Verify the id is numeric
    const empId = Number(id);
    if (isNaN(empId)) {
      return;
    }

    this.loading = true;

    // Find employee
    this.employeeService.getEmployee(empId)
      .subscribe(
        (employee: HubEmployee) => {
          this.employees = [employee];
          this.loading = false;
        },
        error => {
          this.employees = [];
          this.loading = false;
        }
      );
  }

  loadAllEmployees() {
    this.loading = true;

    // Retrieve all employees
    this.employeeService.getEmployees()
      .subscribe(
        (employees: HubEmployee[]) => {
          this.employees = employees;
          this.loading = false;
        },
        error => {
          this.employees = [];
          this.loading = false;
        }
      );
  }
}
