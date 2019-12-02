import { HubRole } from "./hub-role.model";

export class HubEmployee {
  public id: number;
  public name: string;
  public hourlySalary: number;
  public monthlySalary: number;
  public annualSalary: number;
  public role: HubRole;
}
