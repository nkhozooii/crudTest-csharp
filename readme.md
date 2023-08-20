I divided the source you sent into two parts : src and test <br />
I didn't have enough time for the test part, and if the team gives me time, I have to study and I think I will do it in 2 days. Considering that I have never dealt with any of (TDD/DDD/BDD/CleanArc),It took me 2 days to study and implement them.
## Practices and patterns
CleanArchitecture - DDD - CQRS - Dapper - DI
## Src Contains:
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
-Entities, FluentAPIConfigurations: <br />
##### Note: Due to the time, I use Annotation and fluentAPI together but in future I    should to have only fluentApI and moving some Annotation to fluentApi.<br />
- Repositories : that contains Command and Query Interfaces<br />
## Mc2.CrudTest.Presentation.Infrastructure
-Data: For CrudTestDbContext.cs and DbConnector for connect and create database.<br />
-Migrations<br />
- Repository<br />
##### Note2: Although I followed all the Validations but AddAsync Method ignore them so First, I add this package https://github.com/efcore/EFCore.CheckConstraints and then solve the problem. But Expression had some bugs for data input, So Due to the time,I uninstall this package and comment this code in CrudTestDbContext for now. <br />
//For check constraints Enabled by EFCore.CheckConstraints package:
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder
        //    .UseValidationCheckConstraints();
