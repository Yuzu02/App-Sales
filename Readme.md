# App-Ventas

## Description

App-Ventas is a sales management application developed in .NET. It allows users to manage products, users, privileges, and more.

## Project Structure

The project is divided into several layers:

- `CapaDatos`: This layer handles all data-related operations. It contains classes like [`CD_Carrito`](CapaDatos/CD_Carrito.cs), [`CD_Login`](CapaDatos/CD_Login.cs), etc.
- `CapaEntidad`: This layer defines the entities used in the project, such as [`CE_Carrito`](CapaEntidad/CE_Carrito.cs), [`CE_Usuarios`](CapaEntidad/CE_Usuarios.cs), etc.
- `CapaNegocio`: This layer contains the business logic of the application. It includes classes like [`CN_Carrito`](CapaNegocio/CN_Carrito.cs), [`CN_Login`](CapaNegocio/CN_Login.cs), etc.
- `CapaPresentacion`: This layer is responsible for the presentation logic and user interface of the application.

## Getting Started

To get started with this project, clone the repository and open `App-Ventas.sln` in your preferred .NET IDE.

NOTE---------------------------------------------------------------------------------------------

- Ejecutar script.Sql para crear la base de datos que consume la app.
- Cambiar la cadena de conexión en la clase CD_Conexión (Si se ejectuo el scrip.Sql debería bastar con cambiar la parte del DataSource).


## Build

To build the project, use the build functionality of your .NET IDE.

Login----------------------------------------------------------------------------------------

Admin User: 
- user : Admin1
- password : 123abc

Sales User: 
- usuario : ventas1
- password : v321

## Contributing

If you want to contribute to this project, please create a new branch and submit a pull request.
