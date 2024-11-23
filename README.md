Agri-Energy Connect Prototype

This is a prototype for the Agri-Energy Connect platform, a web application designed to connect farmers with green energy solutions. The system allows farmers to manage their products, while employees can manage farmer profiles and view all products. The application is built using ASP.NET Core and Razor Views.

Table of Contents

Development Environment Setup

Building and Running the Prototype

System Functionalities

User Roles

Development Environment Setup

Prerequisites

Before setting up the project, ensure you have the following installed:

Visual Studio 2022 (or later) with the following workloads:
ASP.NET and web development
.NET 6 SDK or later

A web browser (e.g., Chrome, Edge)

Installation Steps

Clone the repository:


git clone https://github.com/ImaanEbrahim/PROG7311_POE_ST10029122_RESUB.git
Open the solution file PROG3A_POE.sln in Visual Studio.

Install required NuGet packages:

If Visual Studio prompts you, restore missing packages by selecting Restore NuGet Packages.
Alternatively, run the following in the Package Manager Console:
bash
Copy code
Update-Package
Ensure the application starts using the In-Memory Data Storage:

No database setup is required.
Building and Running the Prototype
Build the Project
In Visual Studio, build the solution:
Navigate to Build > Rebuild Solution from the menu bar.
Ensure the build completes without errors.
Run the Project
Set the project to launch in debug mode:
Press F5 in Visual Studio, or select Start Debugging.
The application will open in your default browser at:
arduino

https://localhost:5001
System Functionalities
Overview
The prototype provides functionalities for two primary user roles: Farmers and Employees.

Farmers
Add Products: Farmers can add products they produce, including details like product name, category, and production date.
View Products: Farmers can view a list of their own products, filtered by their account.
Employees
Add Farmer Profiles: Employees can add new farmers to the system.
View Farmer Profiles: Employees can see a list of all registered farmers.
View All Products: Employees can view all products in the system, with filtering capabilities (e.g., by category).
User Roles
1. Farmer
Purpose: Farmers manage their product data.
Login Credentials (Preloaded for demo purposes):
Username: farmer1

Password: Password123


Username: farmer2


Password: Password123


Access:
Dashboard: /Farmer/Dashboard
View Products: /Farmer/ProductList
Add Products: /Farmer/AddProduct


2. Employee
Purpose: Employees manage farmer profiles and review all products in the system.
Login Credentials (Preloaded for demo purposes):

Username: employee1


Password: Password123


Access:


Dashboard: /Employee/Dashboard
View Farmers: /Employee/FarmerList
View All Products: /Employee/ViewAllProducts
Add Farmers: /Employee/AddFarmerProfile
Technical Notes
Application Architecture
The application follows the MVC (Model-View-Controller) design pattern:

Model: Defines data entities like ApplicationUser and FarmerProduct.
View: Razor Views used to display pages for farmers and employees.
Controller: Manages HTTP requests and provides the required data to views.
Data Storage
The prototype uses In-Memory Data Storage to simulate user accounts, farmer profiles, and product data. This is suitable for development and testing purposes but can be replaced with a database (e.g., SQL Server) for production.

Additional Notes
Session-Based Login: The system uses session storage to maintain user sessions without relying on ASP.NET Identity.
No Database Required: All data is preloaded or managed in memory.
Testing: Use the credentials provided in the User Roles section to explore the system functionalities.
ST10021922
