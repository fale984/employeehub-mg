## EmployeeHub Project
This is a website to expose data from Employees.
The project consist of:

  * DataAccess: Retrieves the employees from an external server using a REST service
  * Core: Processes the external employees and applies calculations
  * Web: Exposes the converted employees in a controller and contains the WebSite to view information+
  * Tests: Unit test for the logic components


### Usage
Run the Web Project from Visual Studio 2017 or up. The default URLs are:
```
https://localhost:44384/
https://localhost:44384/api/employee
```

If required, replace the `apiUrl` parameter with the appropriate endpoint URL in the file:
```
`EmployeeHub.Web\ClientApp\src\environments\environment.ts`
```

### Author
Francisco Lopez

Greetings
