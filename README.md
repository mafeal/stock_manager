# STOCK MANAGER

A simple project made in C# to submit to Microsoft in the conclusion of the course **"Foundations of Coding Back-End"** on the Coursera platform.

## About the Project

It has three main functions:
> To manage users' access (Admin, Order, Stock);
> 
> To manage orders (create, update and delete);
> 
> To manage stocks (add products, update quantity and delete products from the stock).

About the ***users access privilegies***, each category of user has some permissions:
> **ADMIN USER** has full access to all functionalities of the program, including managing users;
>
>**ORDER USER** has full access to the orders functionalities, but can't access users options and can only read the stock inventory;
>
>**STOCK USER** has full access to the stock functionalities, but can't access users options and can only read the orders availables.
>

It's a simple code made in only one file, mainly in Program.cs, even though that is not the best practice in coding. However, it was done this way to comply with the rules of the course, which is for beginners. As soon as possible, I will submit a new version refactoring all the code following best practices.

If someone would like to refactor this code for practice, feel free to clone it and have fun.

