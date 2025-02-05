# ABCCorpEmployeeManagement

Problem statement -

Develop a .NET core API backend application to maintain the organization (ABC Corp) employee’s data. Including functionalities mentioned below. 

1 – User/Admin sign up and Login feature using JWT token, user should not logout from application if token gets expired while using the application.  

2 – After successful login, user should be able to add organization employee’s data in system (like FirstName, LastName, Email, Mobile, Emergency Contact, Blood Group, Total Exp, Profile Pic, Role, Status, Manager Name, Manager Email, Previous Company Employer data etc.) 

3 – After saving the data, the same will be processed to admin for approval.  

Admin can approve or reject the user entry with comments.  
On name, date column filter should be there with pagination feature.  
Sorting should be there on each column.  
Admin can change the user status like active/terminated. (Terminated users should be blocked from using the system with friendly message while logging in) 
 

Tech stack can be chosen – C#, Asp.Net MVC, MSSQL, LINQ, EF Core, Ado.Net, .NET Core API. 

Architecture – Repository pattern, Clean Architecture, N tier Architecture.  


Solution -
Summary of the Solution for ABCCorpEmployeeManagement
1.	Project Structure (based on clean architecture):
		•	API Layer: Handles HTTP requests and responses.
		•	Application Layer: Contains business logic and application services.
		•	Domain Layer: Contains domain entities and business rules.
		•	Infrastructure Layer: Handles data access and external services.
Framework : .net 8.0

Project : ABCCorp.EmployeeManagement.Api 
		AuthController - handles authentication-related operations such as login, registration, and token management.
		TheEmployeeRecordController - responsible for handling CRUD (Create, Read, Update, Delete) operations for employee records.
		
		Above controllers need specific roles as prerequiste for access
		Exception Handling Middleware: to catch and handle exceptions, returning a JSON response with error details (standard ProblemDetails).
		
		Tools : EF core tools, Swagger for api documentation and making api calls (with authentication support)

Project : ABCCorp.EmployeeManagement.Application
		The ABCCorp.EmployeeManagement.Application project is likely responsible for containing the business logic and application services for the employee management system. Here are the key characteristics and components typically found in such a project:
		Key Components
		1.	Contracts:
			•	Interfaces: Define the contracts for services and repositories used across the application.
			•	Example: IEmployeeRecordService, IAuthService, IUserService.
		2.	Models:
			•	DTOs (Data Transfer Objects): Define the data structures used for transferring data between layers.
			•	Example: CreateEmployeeRecordCommand, UpdateEmployeeRecordCommand, LoginRequest, RegisterRequest.
		4.	Mappings:
			•	AutoMapper Profiles: Define the mapping configurations between domain entities and DTOs.
			•	Example: MappingProfile for mapping CreateEmployeeRecordCommand to EmployeeRecord.
		5.	Validators:
			•	FluentValidation: Define validation rules for the DTOs to ensure data integrity.
			•	Example: CreateEmployeeRecordCommandValidator, UpdateEmployeeRecordCommandValidator.


Project : ABCCorp.EmployeeManagement.Domain
			The ABCCorp.EmployeeManagement.Domain project is responsible for defining the core domain entities, value objects, and business rules for the employee management system. This project encapsulates the essential business logic and data structures that are central to the application's functionality.
			Key Components
			1.	Entities:
			•	Define the main business objects that represent the data and behavior of the system.
			•	Example: EmployeeRecord, BaseEntity.

Project : ABCCorp.EmployeeManagement.Identity
			The ABCCorp.EmployeeManagement.Identity project is responsible for handling authentication and authorization within the employee management system. This project typically includes user management, role management, and security features such as JWT token generation and validation.
			Key Components
			1.	DbContext:
				•	EmployeeManagementIdentityDatabaseContext: Manages the identity-related database operations using Entity Framework Core.
			2.	Models:
				•	ApplicationUser: Extends the IdentityUser class to include additional properties specific to the application.
				•	JwtSettings: Configuration settings for JWT tokens.
			3.	Services:
				•	AuthService: Handles authentication logic, including login, registration, and token generation.
				•	UserService: Manages user-related operations such as retrieving user details and updating user information.
			4.	Configuration:
				•	IdentityServicesRegistration: Extension method to configure identity services, including JWT authentication, database context, and Swagger documentation.
				
				
Project : ABCCorp.EmployeeManagement.Infrastructure
		 Key Components
			
			1.	Services:
				•	Infrastructure services logging.
				•	Example: EmailService, FileStorageService.
			
			
Project : ABCCorp.EmployeeManagement.Persistence
			The ABCCorp.EmployeeManagement.Persistence project is responsible for implementing the persistence layer of the employee management system. This project typically includes the database context, entity configurations, and repository implementations for interacting with the database using Entity Framework Core.
			Key Components
			1.	DbContext:
				•	EmployeeManagementDbContext: Manages the database operations using Entity Framework Core.
			2.	Repositories:
				•	Implementations of repository interfaces defined in the domain layer.
				•	Example: EmployeeRecordRepository.
			3.	Configurations:
				•	Entity configurations for the database context.
				•	Example: EmployeeRecordConfiguration.
			4.	Migrations:
				•	Database migrations for managing schema changes over time. 


Project : ABCCorp.EmployeeManagement.Application.UnitTests
			The ABCCorp.EmployeeManagement.Application.UnitTests project is responsible for testing the business logic and application services of the ABCCorp.EmployeeManagement.Application project. This project typically includes unit tests for service methods, validation logic, and other application-level functionalities.
			Key Components
			1.	Test Framework:
				•	Utilizes a test framework xUnit
			2.	Mocking Framework:
			•	Uses a mocking framework  Moq to create mock objects for dependencies.
Project : ABCCorp.EmployeeManagement.Persistence.IntegrationTests
				Responsible for testing the integration of the persistence layer with the actual database. 