# OrganicProductOrderForm
This Project can be used By ASP.Net Core MVC 8+ SQL DB + Ajax + HTML code. User create Check list with modification and checkout order list.

# OrganicForm Order Management App

This is a simple ASP.NET Core MVC web application for managing product orders. Users can create orders by selecting products, specifying quantity, unit, and price, add multiple order items, and then submit the complete order to be saved in the database. It also supports viewing orders by date.

---

## Features

- List products in a dropdown for order creation
- Add multiple order items dynamically on client side before submitting
- Client-side validation for order item inputs
- Submit order as a batch of order details via AJAX POST with anti-forgery protection
- Server-side validation before saving order data
- Store orders and their details in the database with timestamps
- Fetch and view orders filtered by date

---

## Technologies Used

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server (or other supported DB)
- jQuery & Bootstrap 5 for UI and AJAX
- Razor Views

---

## Project Structure

- **Controllers/OrderController.cs** — Handles order creation, saving, and fetching orders
- **Views/Order/Index.cshtml** — UI for creating orders
- **Views/Order/FetchView.cshtml** — UI for viewing orders by date
- **Models** — Contains `Order`, `OrderDetails`, and `Product` entity models
- **Data/AppDbContext.cs** — EF Core DbContext for database access

---

## Setup Instructions

1. **Clone the repository**

   ```bash
   git clone https://github.com/yourusername/OrganicProductOrderForm.git
   cd OrganicProductOrderForm
