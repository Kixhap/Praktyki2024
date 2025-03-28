# WebAPI in C# using ASP.NET Core

## 1. Project Overview

The project involves creating a WebAPI using the C# language and the .NET platform, along with implementing graphical user interfaces (GUI) using React, XAML, and Windows Forms based on the MVVM pattern.

Project objectives:
- Develop a WebAPI to handle CRUD (Create, Read, Update, Delete) operations using Entity Framework Core and SQLite database.
- Integrate the API with multiple user interfaces:
  - **React** – Login page and admin panel.
  - **XAML** – Desktop application on the .NET platform (MVVM).
  - **Windows Forms** – Classic GUI using the MVVM architecture.

## 2. Project Structure

1. **WebAPI (ASP.NET Core)**:
   - Handles CRUD operations on models.
   - Uses Entity Framework Core for communication with the SQLite database.
2. **User Interfaces:**
   - **React**: Login page and admin panel for viewing API data.
   - **XAML (WPF)**: Desktop application using the MVVM pattern, interacting with the API.
   - **Windows Forms**: Traditional desktop GUI using the MVVM architecture.

## 3. Required Tools

- **Visual Studio 2022** (with ASP.NET Core, WPF, and Windows Forms support)
- **Postman**: [Download here](https://www.postman.com)
- **Node.js** (LTS) for running the React application: [Download here](https://nodejs.org/en/)

## 4. Features

- **WebAPI**:
  - Supports HTTP methods: GET, POST, PUT, DELETE.
  - Implements CRUD operations on user models.
- **React**:
  - Login page (fixed credentials: `admin`, `admin1`).
  - Admin panel displaying data from the API.
- **XAML (WPF)**:
  - MVVM-based implementation.
  - Handles forms and API data.
- **Windows Forms**:
  - GUI supporting CRUD operations using the MVVM architecture.
  - 
