# Point of Sale (POS) Application

This repository contains the source code for a Point of Sale (POS) application developed using Microsoft Visual Studio. The POS application is designed to facilitate sales transactions in a retail environment.

## Features

### User Interface
- **WPF:** The user interface is built using WPF (Windows Presentation Foundation) for a modern and intuitive user experience.

### Architecture
- **Clean Architecture:** The application is built on the principles of Clean Architecture, emphasizing separation of concerns and maintainability.
- **Dependency Injection:** Utilizes Microsoft's Dependency Injection framework for managing object dependencies, promoting loose coupling and testability.

### Data Management
- **Entity Framework Core:** Data access and persistence are handled using Entity Framework Core, a lightweight, extensible, and cross-platform version of the Entity Framework data access technology.
- **SQLite:** Utilizes SQLite as the database provider, offering a lightweight and embedded database solution.
- **Identity Management:** Integrated with Microsoft's ASP.NET Core Identity framework for user authentication and authorization, providing robust security features out of the box.

### Validation
- **FluentValidation:** Input validation is implemented using FluentValidation, offering a fluent interface for defining validation rules.

### Charting
- **LiveCharts.Wpf:** Integrates LiveCharts.Wpf for data visualization, allowing users to analyze sales data through interactive charts.

### Barcode Scanning
- **ZXing.Net.Bindings.Windows.Compatibility:** Integrates ZXing.Net for barcode scanning functionalities, enabling efficient product entry through barcode scanning.
## Screenshots

1. **Sign-in Page:**
   ![Sign-in Page](/screenshots/signin.png)

2. **Dashboard:**
   ![Dashboard](/screenshots/dashboard.png)

3. **Sale Pages:**
   ![Sale Pages](/screenshots/sales.png)

4. **Inventory Page:**
   ![Inventory Page](/screenshots/inventory.png)

5. **Users:**
   ![Users](/screenshots/users.png)

6. **Permissions & Roles:**
   ![Permissions & Roles](/screenshots/permissions_roles.png)

## Projects Structure

- **POS:** Main project containing the POS application.
- **POS.Domain:** Domain entities and business logic.
- **POS.Application:** Application layer including services and application logic.
- **POS.Persistence:** Data access layer including database context and repositories. (Default project for Package Manager Console)
- **POS.Infrastructure:** Infrastructure concerns such as configuration and cross-cutting concerns.

## Prerequisites

To run the POS application, ensure you have the following prerequisites installed:

- **Microsoft Visual Studio 17:** Version 17.8.34330.188 or later.
- **.NET SDK:** .NET SDK 8.0 or later.

## Installation

Follow these steps to install and run the POS application:

1. Clone the repository: `git clone https://github.com/mohamedelareeg/POS.git`
2. Open the solution file (`POS.sln`) in Visual Studio.
3. Restore NuGet packages and build the solution.

## Usage

Once the application is built and running, you can:

- Navigate through the various features of the application such as sales, inventory management, user management, etc.
- Utilize the integrated barcode scanning functionality for faster product entry.

## Database Migration and Default Users

Before updating the database schema and creating default users, set POS.Persistence as the Default project in the Package Manager Console:

1. Open Package Manager Console in Visual Studio.
2. Set POS.Persistence as the Default project by selecting it from the dropdown list in the Package Manager Console.

Once POS.Persistence is set as the Default project:

1. Run the following command to update the database schema for SQLite: `Update-Database`.
2. The command above will apply any pending migrations and update the database schema accordingly.

## Default Users

The application comes with pre-configured default users for testing purposes:

- **System Administrator:**
  - Email: admin@arp.com
  - Password: 123
  - Role: Administrator

- **Regular User:**
  - Email: user@arp.com
  - Password: 123

These default users can be used to access the application and test its functionalities.

## Additional Features

The application also includes the following features:

- **Sales and Invoices:**
  - Create sales transactions and manage invoices.
  - Add price offers and view price offers.
  - Manage sales returns.

- **Inventory and Purchases:**
  - Manage inventory items and purchase goods.
  - Track goods movement and generate inventory reports.
  - View purchase invoices and manage purchase returns.

- **Treasury:**
  - Track incoming and outgoing transactions.
  - Generate treasury reports.

- **Customers and Installments:**
  - Manage customer information and installments.
  - Add new customers.

- **Suppliers and Debts:**
  - Manage supplier details and debts.
  - Add new suppliers.

- **Expenses:**
  - Add and track expenses.
  - Generate expense reports.

- **Reports:**
  - Generate various reports including sales, stock status, purchases, profits, etc.

- **Settings:**
  - Configure account settings, system settings, and company settings.
  - Backup data and manage user roles.

## Menu Configuration

The application's menu is dynamically configured based on user roles and permissions. Here is a breakdown of the menu structure:

- **Sales and Invoices:**
  - Provides functionalities related to sales transactions and invoices, including adding price offers, managing sales returns, etc.

- **Inventory and Purchases:**
  - Offers features for managing inventory items, purchasing goods, tracking goods movement, and generating inventory reports.

- **Treasury:**
  - Allows tracking of incoming and outgoing transactions, along with generating treasury reports.

- **Customers and Installments:**
  - Enables management of customer information and installments, with the option to add new customers.

- **Suppliers and Debts:**
  - Facilitates management of supplier details and debts, including the ability to add new suppliers.

- **Expenses:**
  - Provides functionalities for adding and tracking expenses, along with generating expense reports.

- **Reports:**
  - Offers a variety of reports including sales, stock status, purchases, profits, etc.

- **Settings:**
  - Allows configuration of account settings, system settings, company settings, and user roles. Also provides options for data backup.

## Menu Configuration Logic

The menu configuration is driven by user roles and permissions. Users with administrative privileges have access to additional settings options, while regular users have access to standard functionalities related to sales, inventory, treasury, customers, suppliers, expenses, and reports.

The menu items can be configured to require specific claims for access. For example, consider the following code snippet:

```csharp
var salesAndInvoices = new MenuItem { Name = "Sales and Invoices", Identifier = "salesAndInvoices", IsClickable = false };
salesAndInvoices.Children.Add(new MenuItem { Name = "Sales Screen", Identifier = "salesScreen", RequiredClaim = "salesScreen" });
```
In the above code, the RequiredClaim property is used to specify the permission required for accessing certain menu items. For instance, the menu item "Sales Screen" requires the user to have the claim "salesScreen" in order to access it. If the user does not have this claim, the menu item will not be visible or accessible to them

## License

This project is licensed under the [MIT License](LICENSE).
