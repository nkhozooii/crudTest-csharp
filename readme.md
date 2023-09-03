I divided the source you sent into two parts : src and test <br />
## Practices and patterns
CleanArchitecture - DDD - CQRS - Dapper - DI - TDD
## Src Part Contains:
## Mc2.CrudTest.Presentation.API : 
-CustomerController that sending requests via MediatR to Application layer. <br />
-appsettings.json for sqlconnection<br />
-Program.cs<br />
I added a Swagger UI in API Part instead of working on Front Project(Client):<br />
https://localhost:7045/swagger/index.html<br />
## Mc2.CrudTest.Presentation.Application :
-Commands Folder for Create/Delete/Edit Customer <br />
-Handlers (Command and Query Handlers)<br />
-Mapper<br />
-Queries For GetAll/GetById/GetByEmail<br />
-Response for CustomerResponse <br />
## Mc2.CrudTest.Presentation.Client : 
Not Worked(I add SwaggerUI)<br />
## Mc2.CrudTest.Presentation.Core: 
-DefineAttributes : I use the Google LibPhoneNumber library  to validate phonenumber at the backend , So this folder contains PhoneNumberAttribute.cs for Defining Attribute [PhoneNumber]<br />
-Entities<br />
-FluentAPIConfigurationsthat contains CustomerEntityConfiguration.cs for Data Annotaion <br />
-Validators that contains CustomerValidator.cs-->that use of FluentValidation.AspNetCore package for validation<br />
-Repositories : that contains Command and Query Interfaces<br />
## Mc2.CrudTest.Presentation.Infrastructure
-Data: For CrudTestDbContext.cs and DbConnector for connect and create database.<br />
-Migrations<br />
-Repository<br />
## Test Part Contains:
## Mc2.CrudTest.AcceptanceTest :
-Mc2.CrudTest.Presentation.ApplicationTest: for command and Query handlers tests.<br />
-Mc2.CrudTest.Presentation.CoreTest : for PhoneNumberAttributeTest and CustomerValidatorTest<br />
-MockData
