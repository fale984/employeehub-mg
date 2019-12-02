import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { HubEmployee } from '../models/hub-employee.model';

const { apiUrl } = environment;

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {
    private employeesUrl = `${apiUrl}/api/employee`;

    constructor(private http: HttpClient) { }

    getEmployees(): Observable<HubEmployee[]> {
        return this.http.get<HubEmployee[]>(this.employeesUrl);
    }

    getEmployee(id: number): Observable<HubEmployee> {
        const url = `${this.employeesUrl}/${id}`;
        return this.http.get<HubEmployee>(url);
    }
}
