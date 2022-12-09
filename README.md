# SimplifiedDMV

This is a program which mimics the DMV system in simplified version. The project is based on ASP.NET Core MVC(.NET 6) in C# language. The following are functionalities of SimplifiedDMV.

1- Display Drivers - Displaying all drivers in the system in a table form with pagination, each page shows 8 drivers at most. users can click on pagination bar to view drivers on a different page. Last name, first name, address, phone number, address, resigration date and id of the driver are displayed for each driver. 

![Employee data](/Images_demo/Vehicle.png?raw=true "Employee Data title")

2- Delete Drivers - User can remove a driver from the system.

3- Add Drivers - User can add a driver into the system.

3- Edit Drivers - User can edit the information of a driver which includes Last name, first name, address, phone number, address.

4- Search Drivers - User can search for a driver or a group of drivers through the first name of driver, based on a text query string.

5- Display vehicles - User can click on a driver to view all vehicles registered under the driver. Vehicles are displayed with their information in table form with pagination. 

6- Add vehicles - User can register a new vehicle for a driver. 

7- Edit vehicles - User can edit a vehicle.

8- Delete vehicles - User can delte a vehicle from the system.

## Getting Started 

### Pre-requisites and Local Development

Developers using this project should already have:

- Visual Studio(recommended)
- Mirosoftware SQL Server Management Studio(recommended)
- ASP.NET Core 
- #C

#### Backend 

packeges used:
  - EntityFrameworkCore
  
Create your own sql database. Change the connection string in appsettings.json file to connect your own database.


#### Frontend

- Boostrap
- Jquery

## API Reference

### Endpoints


**GET /Driver**

General:
- Returns a list of drivers
- Results are paginated in groups of 8. Include a request argument to choose page number, starting from 1.

**POST /Driver/Create**

General:
- Create a driver based on the information inputted by user

**POST /Driver/Edit/{id}**

General:
- Edit a driver with id with based on the information inputted by user

**POST /Driver/Delete/{id}**

General:
- Delete a driver with id

//
**GET /Driver/Detail**

General:
- Returns a list of vehicles
- Results are paginated in groups of 8. Include a request argument to choose page number, starting from 1.

**POST /Vehicle/Create/{id}**

General:
- Create a vehicle based on the information inputted by user with id

**POST /Vehicle/Edit/{id}**

General:
- Edit a vehicle with id with based on the information inputted by user

**POST /Vehicle/Delete/{id}**

General:
- Delete a vehicle with id

## Deployment(optional)

It is optional to deploy this project to cloud.
If you decide to deploy, Azure cloud service is highly recommended.
