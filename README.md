# Overview

This program is a UI tool to connect and modify data held within a cloud database through the basic CRUD operations (Create, Read, Update, and Delete). It represents a product inventory management system that could be used by any company, store, or buisness that holds some type of stock. It uses a C# focused full stack to accomplish this.

The purpose of this software was to learn new stacks and how to incorporate a cloud database into this particular blend of stacks. It was also a goal to create an useful program that I feel is applicable to a majority of companies to showcase my ability to create "products" and not just "programs". 


[Software Demo Video](https://youtu.be/qolqamrEDP4)

# Cloud Database
This project uses the cloud database MongoDB due to its easy data manipulation and connection between data collections.
The database structure for this project consists of several collections:

Products: This collection stores information about the products in the inventory. Each document in the collection represents a single product and contains fields such as name, description, price, quantity, weight, and barcode.

Future Work -
Users: This collection will store user information for tied to the authentication of the application so each user has it's own specific collection of products. It will include fields such as username, password (hashed), email, and role.

# Development Environment

During the development of the project, I used the following software tools and environments:

### ASP.NET Core Web App
ASP.NET Core Web App served as the foundation of the project, providing a robust framework for building web applications.

### Razor Pages
Razor Pages were used to create dynamic web pages with server-side functionality. This allowed for the creation of interactive user interfaces and seamless integration with backend logic.

### OAuth
OAuth authentication was implemented to allow users to sign in using their Google accounts. This provided a secure and convenient authentication mechanism without the need for users to create separate credentials for the application.

### MongoDB
MongoDB was the chosen database technology, providing a flexible and scalable NoSQL database solution. It offered easy integration with ASP.NET Core using official MongoDB drivers and libraries.

### Bootstrap
Bootstrap was used for front-end styling and layout. It provided a responsive and mobile-first design framework, allowing for the creation of visually appealing user interfaces with minimal effort.


# Useful Websites

- [.NET Web App Documentation](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0)
- [Chat GPT](https://chatgpt.com/?oai-dm=1)
Chat was fundamental for me to be able to learn how to create this project with the integration of so many libraries that I have never used before within the 2 week time span (All except Mongo but I had never connected mongo to a core web app before).

# Future Work

- Connect Authentication to Database Records for Seperate Product Inventories
- Figure out bug in authentication why it displays the login screen again instead of the dashboard screen as it is supposed to.
- Implement added features to view inventory page so that they can edit or delete a specific product on the spot if they saw something out of place or in need of editing