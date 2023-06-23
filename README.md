# Blog
This project consists of three separate projects: Admin Panel, BlogMaster, and API.

## Admin Panel Project
- This project includes an administration panel where administrators can perform tasks such as adding, deleting, and updating articles.
- It is a web application based on the MVC (Model-View-Controller) architecture.
- The Admin Panel communicates with the API to perform CRUD operations.
- It is a project that includes a user interface (UI).

## BlogMaster Project
- This project includes a web application where all administrators' added articles can be viewed.
- It is a web application based on the MVC architecture.
- BlogMaster communicates with the API to list and display articles.
- It is a project that includes a user interface (UI).

## API Project
- This project includes a backend web API that communicates with the database to perform CRUD operations.
- The API communicates with the Admin Panel and BlogMaster projects to respond to requests.
- The API allows administrators to add, update, delete, and view articles.
- Database operations are performed in the API project, and responses are provided to the relevant projects.

This project structure aims to separate responsibilities and provide a modular architecture. The MVC projects focus on user interfaces, while the API project manages database operations and facilitates communication between projects. CRUD operations are performed in the API project and responses are returned to the respective projects. This approach enhances scalability and simplifies maintenance.
<hr>
<h2>Used</h2>
<h3>Blog.Api (.Net Core Web Api)</h3>

- [x] Mssql
- [x] Entity Framework (Codefirst approach) 
- [x] Restful Services
- [x] Linq-lambda queries
- [x] Inversion of Control (IoC)
- [x] Layered Architecture
- [x] Json Objects
- [ ] Jwt Token (ASAP Incoming)
- [ ] Repository Design Pattern (ASAP Incoming)

<h3>Admin Panel (.Net Core Mvc)</h3>

- [x] Inversion of Control (IoC)
- [x] Layered Architecture
- [x] Javascript & Html & Css & Bootstrap
- [x] Fluent Validation 
- [x] CKEditor 
- [x] Cookie-based Authentication
- [x] SweetAlert2 
- [x] Json Objects

<h3>BlogMaster (End User - .Net Core Mvc)</h3>

- [x] Inversion of Control (IoC)
- [x] Layered Architecture
- [x] Javascript & Html & Css & Bootstrap
