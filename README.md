E-Commerce Web Application

A web-based e-commerce application developed using **ASP.NET MVC 5, C#, Entity Framework 6, and SQL Server**.

Features

* User Registration
* User Login 
* Product Listing
* Product Categories
* Category-based Product Filtering
* Product Images
* Session-based Shopping Cart
* Add to Cart
* Update Cart Quantity
* Remove from Cart
* Checkout
* Order Creation
* Order Details
* User Order Information
* Database integration using Entity Framework

Shopping Cart

The application uses a **session-based shopping cart** to allow users to:

* Add products to the cart
* View cart items
* Update quantities
* Remove products
* Calculate the cart total

Authentication

Users can:

* Create an account
* Login using their credentials
* Logout
* Maintain login state using ASP.NET Session

Orders

The checkout process allows users to submit their order and stores order information in the SQL Server database.

The system maintains:

* Order information
* Order details
* Product information
* User information

Technologies Used

* **ASP.NET MVC 5**
* **C#**
* **Entity Framework 6**
* **SQL Server**
* **HTML5**
* **CSS3**
* **Bootstrap**
* **JavaScript**
* **jQuery**

Database

The project uses **SQL Server** with **Entity Framework Database First**.

The application includes database relationships between users, products, categories, orders and order details.

How to Run

1. Clone or download the repository.
2. Open the project in **Visual Studio**.
3. Restore the required NuGet packages.
4. Create or restore the SQL Server database.
5. Update the database connection string in `Web.config`.
6. Build the solution.
7. Run the application using Visual Studio.

> `Web.config` is not included in this repository because the database connection is specific to the local development environment.

Project Structure

```text
Controllers/
Models/
Views/
Content/
Scripts/
App_Start/
assets/
```

Project Purpose

This project was developed as a practical **ASP.NET MVC e-commerce project** to demonstrate MVC architecture, Entity Framework, SQL Server integration, authentication, session management, shopping cart functionality, checkout and order management.

Author

**Asfand Khan**

Built as an ASP.NET MVC project for learning and portfolio development.
