
# 📚 Library Management System

A simple yet functional **Library Management System** built using **ASP.NET MVC**, **Entity Framework Core (Code-First)**, and an **in-memory database**. The system manages authors, books, and borrowing transactions using an **n-tier architecture** with clear separation of concerns.

---

## ✅ Features

### 📖 Author Management
- Add, edit, delete, and list authors.
- Full name must contain **4 words**, each with **at least 2 characters**.
- Email must be **unique** and follow a **valid format**.

### 📚 Book Management
- Add, edit, delete, and list books.
- Assign books to authors.
- Genre is selected from an **enum**.
- Book title and genre are **required** fields.

### 🔁 Borrowing System
- **Borrow** a book:
  - Sets `BorrowedDate`.
  - Prevents borrowing if already checked out.
- **Return** a book:
  - Sets `ReturnedDate`.
  - Marks book as available again.

### ✅ Validation
- Client-side and server-side validation included.

### 🎯 Dynamic Dropdowns
- Genre and Author dropdowns in book forms.

### 🌱 Seeding
- Initial data seeding for development/testing using **InMemory** DB.

---

## 🧱 Architecture

### 🔹 N-Tier Structure

- **Presentation Layer:** ASP.NET MVC Controllers & Views
- **Business Layer:** Services for all business logic
- **Data Layer:** EF Core with InMemory DB and Repositories

---

## 🛠 Technologies

- ASP.NET MVC  
- Entity Framework Core (InMemory)  
- C#  
- Bootstrap 5  
- jQuery  

📂 Project Structure

📁 Controllers

├─ 📄 AuthorController.cs

├─ 📄 BookController.cs


└─ 📄 BorrowingController.cs



📁 Services

├─ 📁 Interfaces

└─ 📁 Implementations


📁 Repositories

├─ 📁 Interfaces

└─ 📁 Implementations



📁 Models

├─ 📁 Entities


└─ 📁 DTOs


📁 Validators

  ├─ 📁 AuthorValidator 


  └─ 📁 BookValidator 


📁 Views

├─ 📁 Author

├─ 📁 Book

├─ 📁 BookLibrary

└─ 📁 Borrowing



🧑‍💻 Author

Ahmed Roshdy.NET Developer
