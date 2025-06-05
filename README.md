📚 Library Management System

A simple yet functional Library Management System built using ASP.NET MVC, Entity Framework Core (Code-First), and an in-memory database. This system is designed to manage authors, books, and borrowing transactions using an n-tier architecture with a clear separation of concerns.

✅ Features

Author Management: Add, edit, delete, and list authors with full name and bio and Validation Full name contain 4 words each at least 2 char

and Unique Email with valid format

Book Management: Add, edit, delete, and list books with genre and author assignment. with required title and genre Enum

Borrowing System: Request and return books, track borrowing records.

Validation: Client-side and server-side validation.

Dynamic Dropdowns: Genre and author selection in book forms.

Seeding: In-memory database seeding for development/testing.

🔄 Borrowing Transactions

Borrow:

Sets BorrowedDate.

Prevents borrowing if already checked out.

Return:

Sets ReturnedDate.

Marks book as available again.

🧱 Architecture

🔹 N-Tier Design:

Presentation Layer: ASP.NET MVC Controllers & Views.

Business Layer: Services for all business logic.

Data Layer: EF Core with InMemory database + Repositories.

🔹 Technologies:

ASP.NET MVC

Entity Framework Core (InMemory DB)

C#

jQuery

Bootstrap 5 (for styling)

📂 Project Structure

/Controllers

AuthorController.cs

BookController.cs

BookLibraryController.cs

BorrowingController.cs

/Services

Interfaces/

Implementations/

/Repositories

Interfaces/

Implementations/

/Models

Entities/

DTOs/

/Views

Author/

Book/

BookLibrary/

Borrowing/

🧑‍💻 Author

Ahmed Roshdy.NET Developer
