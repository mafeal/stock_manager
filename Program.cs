int userPrivilege = 1; //administrador
User selectedUser = null;
List<Product> products = new List<Product>
{
   new Product(1, "Caneta BIC Azul cx 50 un", 41.00),
   new Product(2, "Caderno Tilibra 10 matérias", 19.45),
   new Product(3, "Estojo escolar 2 compartimentos", 32.80),
   new Product(4, "Lápis de Cor Sextavado BIC 12 Cores", 6.70),
   new Product(5, "Lápis Preto HB n.2 Faber-Castell CX 12 UN", 9.00)
};

List<ProductStock> stock = new List<ProductStock>
{
   new ProductStock(1, 100),
   new ProductStock(2, 50),
   new ProductStock(3, 30),
   new ProductStock(4, 80),
   new ProductStock(5, 100)
};

List<User> users = new List<User>
{
   new User(1, "Admin", "Admin"),
   new User(2, "Order User1", "Order"),
   new User(3, "Order User2", "Order"),
   new User(4, "Stock User 1", "Stock"),
   new User(5, "Stock User 2", "Stock")
};

List<Order> orders = new List<Order>
{
   new Order(1, users[0], new List<OrderItem>
   {
      new OrderItem(1, "Caneta BIC Azul cx 50 un", 2, 82.00),
      new OrderItem(2, "Caderno Tilibra 10 matérias", 3, 3*19.45)
   }),
   new Order(2, users[1],new List<OrderItem>
   {
      new OrderItem(3, "Estojo escolar 2 compartimentos", 5, 5*32.80),
      new OrderItem(2, "Caderno Tilibra 10 matérias", 1, 19.45)
   }),
   new Order(3, users[2],new List<OrderItem>
   {
      new OrderItem(4, "Lápis de Cor Sextavado BIC 12 Cores", 2, 2*6.70),
      new OrderItem(2, "Caderno Tilibra 10 matérias", 3, 3*19.45)
   }),
};

void initialRun()
{
   Console.WriteLine("**********************");
   Console.WriteLine("*    WELCOME         *");
   Console.WriteLine("*  SELECT AN USER    *");
   Console.WriteLine("**********************");
   foreach (var u in users)
   {
      Console.WriteLine($"* User Id: {u.Id} - Name: {u.Name} - Privilege: {u.Privilege} *");
      Console.WriteLine("**********************");
   }
   Console.WriteLine("Please select an user:");
   int userId = int.Parse(Console.ReadLine());
   selectedUser = users.Find(u => u.Id == userId);
   switch (selectedUser.Privilege)
   {
      case "Admin":
         userPrivilege = 1;
         break;
      case "Order":
         userPrivilege = 2;
         break;
      case "Stock":
         userPrivilege = 3;
         break;
      default:
         userPrivilege = 0;
         break;
   }
   runApp();
}

void runApp()
{
   Console.Clear();
   showOptionsMenu();
   Console.WriteLine("\nPlease select an option:");
   string option = Console.ReadLine();
   switch (option)
   {
      case "1":
         Console.Clear();
         ordersService();
         break;
      case "2":
         Console.Clear();
         stockService();
         break;
      case "3":
         userService();
         Console.Clear();
         break;
      case "0":
         Console.Clear();
         Console.WriteLine("Goodbye!");
         break;
      default:
         Console.WriteLine("Invalid option");
         break;
   }

}


#region VIEWS

void showOptionsMenu()
{
   Console.WriteLine("**********************");
   Console.WriteLine("*    OPTIONS MENU    *");
   Console.WriteLine("**********************");
   Console.WriteLine("* 1- SHOW ORDER MENU *");
   Console.WriteLine("* 2- SHOW STOCK MENU *");
   Console.WriteLine("* 3- SHOW USER MENU  *");
   Console.WriteLine("* 0- QUIT            *");
   Console.WriteLine("**********************");

}

void showOrderMenu(bool orderUser)
{

   if (orderUser)
   {
      Console.WriteLine("**********************");
      Console.WriteLine("*    ORDER MENU      *");
      Console.WriteLine("**********************");
      Console.WriteLine("* 1- SHOW ORDERS     *");
      Console.WriteLine("* 2- ADD ORDER       *");
      Console.WriteLine("* 3- DELETE ORDER    *");
      Console.WriteLine("* 0- BACK            *");
      Console.WriteLine("**********************");
   }
   else
   {

      Console.WriteLine("**********************");
      Console.WriteLine("*    ORDER MENU      *");
      Console.WriteLine("**********************");
      Console.WriteLine("* 1- SHOW ORDERS     *");
      Console.WriteLine("* 0- BACK            *");
      Console.WriteLine("**********************");
   }

}

void showStockMenu(bool stockUser)
{
   if (stockUser)
   {
      Console.WriteLine("**********************");
      Console.WriteLine("*    STOCK MENU      *");
      Console.WriteLine("**********************");
      Console.WriteLine("* 1- SHOW STOCK      *");
      Console.WriteLine("* 2- UPDATE STOCK    *");
      Console.WriteLine("* 3- DELETE PRODUCT  *");
      Console.WriteLine("* 0- BACK            *");
      Console.WriteLine("**********************");
   }
   else
   {
      Console.WriteLine("**********************");
      Console.WriteLine("*    STOCK MENU      *");
      Console.WriteLine("**********************");
      Console.WriteLine("* 1- SHOW STOCK      *");
      Console.WriteLine("* 0- BACK            *");
      Console.WriteLine("**********************");
   }

}

void showUserMenu(bool adminUser)
{
   if (adminUser)
   {
      Console.WriteLine("**********************");
      Console.WriteLine("*    USER MENU       *");
      Console.WriteLine("**********************");
      Console.WriteLine("* 1- SHOW USERS      *");
      Console.WriteLine("* 2- ADD USER        *");
      Console.WriteLine("* 3- DELETE USER     *");
      Console.WriteLine("* 0- BACK            *");
      Console.WriteLine("**********************");
   }
   else
   {
      Console.WriteLine("Access denied!");
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
      Console.Clear();
      runApp();
   }
}

#endregion

#region SERVICES

void ordersService()
{
   if (userPrivilege == 1 || userPrivilege == 2)
   {
      showOrderMenu(true);
      Console.WriteLine("\nPlease select an option:");
      string option = Console.ReadLine();
      switch (option)
      {
         case "1":
            showOrders();
            break;
         case "2":
            addOrder();
            break;
         case "3":
            deleteOrder();
            break;
         case "0":
            runApp();
            break;
         default:
            Console.WriteLine("Invalid option");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            ordersService();
            break;
      }
   }
   else
   {
      showOrderMenu(false);
      Console.WriteLine("\nPlease select an option:");
      string option = Console.ReadLine();
      switch (option)
      {
         case "1":
            showOrders();
            break;
         case "0":
            runApp();
            break;
         default:
            Console.WriteLine("Invalid option");
            break;
      }
   }
}

void stockService()
{

   if (userPrivilege == 1 || userPrivilege == 3)
   {
      showStockMenu(true);
      Console.WriteLine("\nPlease select an option:");
      string option = Console.ReadLine();
      switch (option)
      {
         case "1":
            showStock();
            break;
         case "2":
            updateStock();
            break;
         case "3":
            deleteProduct();
            break;
         case "0":
            runApp();
            break;
         default:
            Console.WriteLine("Invalid option");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            stockService();
            break;
      }
   }
   else
   {
      showStockMenu(false);
      Console.WriteLine("\nPlease select an option:");
      string option = Console.ReadLine();
      switch (option)
      {
         case "1":
            showStock();
            break;
         case "0":
            runApp();
            break;
         default:
            Console.WriteLine("Invalid option");
            break;
      }
   }

}

void userService()
{
   if (userPrivilege == 1)
   {
      showUserMenu(true);
      Console.WriteLine("\nPlease select an option:");
      string option = Console.ReadLine();
      switch (option)
      {
         case "1":
            showUsers();
            break;
         case "2":
            addUser();
            break;
         case "3":
            deleteUser();
            break;
         case "0":
            runApp();
            break;
         default:
            Console.WriteLine("Invalid option");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            userService();
            break;
      }
   }
   else
   {
      showUserMenu(false);
   }
}

#endregion
initialRun();

#region CONTROLLERS
void showOrders()
{
   Console.Clear();
   Console.WriteLine("**********************");
   Console.WriteLine("*      ORDERS        *");
   Console.WriteLine("**********************");
   foreach (var order in orders)
   {
      foreach (var item in order.productsList)
      {
         Console.WriteLine($"* Order Id: {order.Id} - User: {order.UserName} - Product: {item.ProductName} - Quantity: {item.Quantity} - Total Price: {item.TotalPrice} *");
      }
      Console.WriteLine("**********************");
   }
   Console.WriteLine("Press any key to continue...");
   Console.ReadKey();
   Console.Clear();
   ordersService();
}

void addOrder()
{
   Console.Clear();
   Console.WriteLine("**********************");
   Console.WriteLine("*      ADD ORDER     *");
   Console.WriteLine("**********************");

   List<OrderItem> productsList = new();

   foreach (var s in stock)
   {
      Product product = products.Find(p => p.Id == s.ProductId);
      Console.WriteLine($"* Product Id: {product.Id} - Name: {product.Name} - Price: {product.Price} - Qtt.: {s.Quantity} *");
      Console.WriteLine("**********************");
   }

   do
   {
      Console.WriteLine("Please select a product:");
      int productId = int.Parse(Console.ReadLine());
      Product product = products.Find(p => p.Id == productId);
      Console.WriteLine("Please enter the quantity:");
      int quantity = int.Parse(Console.ReadLine());
      stock.Find(s => s.ProductId == productId).Quantity -= quantity;
      productsList.Add(new OrderItem(product.Id, product.Name, quantity, product.Price * quantity));
      Console.WriteLine("Do you want to add another product? (Y/N)");
      string option = Console.ReadLine();
      if (option.ToUpper() == "N")
      {
         break;
      }

   } while (true);

   Order order = new Order(orders.Count + 1, selectedUser, productsList);
   orders.Add(order);
   Console.WriteLine("Order added successfully!");
   Console.WriteLine("Press any key to continue...");
   Console.ReadKey();
   Console.Clear();
   ordersService();
}

void deleteOrder()
{
   Console.Clear();
   Console.WriteLine("**********************");
   Console.WriteLine("*    DELETE ORDER    *");
   Console.WriteLine("**********************");
   Console.WriteLine("Please enter the order id:");
   int orderId = int.Parse(Console.ReadLine());
   Order order = orders.Find(o => o.Id == orderId);
   Console.WriteLine($"* Order Id: {order.Id} - User: {order.UserName} *");
   foreach (var item in order.productsList)
   {
      Console.WriteLine($"* Product: {item.ProductName} - Quantity: {item.Quantity} - Total Price: {item.TotalPrice} *");
   }
   Console.WriteLine("Are you sure you want to delete this order? (Y/N)");
   string option = Console.ReadLine();
   if (option.ToUpper() == "N")
   {
      Console.Clear();
      ordersService();
   }

   orders.Remove(order);
   Console.WriteLine("Order deleted successfully!");
   Console.WriteLine("Press any key to continue...");
   Console.ReadKey();
   Console.Clear();
   ordersService();
}

void showStock()
{
   Console.Clear();
   Console.WriteLine("**********************");
   Console.WriteLine("*       STOCK        *");
   Console.WriteLine("**********************");
   foreach (var s in stock)
   {
      Product product = products.Find(p => p.Id == s.ProductId);
      Console.WriteLine($"* Product Id: {product.Id} - Name: {product.Name} - Quantity: {s.Quantity} *");
      Console.WriteLine("**********************");
   }
   Console.WriteLine("Press any key to continue...");
   Console.ReadKey();
   Console.Clear();
   stockService();
}

void updateStock()
{
   Console.Clear();
   Console.WriteLine("**********************");
   Console.WriteLine("*    UPDATE STOCK    *");
   Console.WriteLine("**********************");

   foreach (var s in stock)
   {
      Product item = products.Find(p => p.Id == s.ProductId);
      Console.WriteLine($"* Product Id: {item.Id} - Name: {item.Name} - Price: {item.Price} - Qtt.: {s.Quantity} *");
      Console.WriteLine("**********************");
   }

   Console.WriteLine("Please select a product to Update or 'N' for add a new one:");
   string response = Console.ReadLine();
   int productId = 0;
   if (response.ToUpper() == "N")
   {
      // add a new product to the stock
      Console.WriteLine("Please enter the product name:");
      string productName = Console.ReadLine();
      Console.WriteLine("Please enter the product price:");
      double productPrice = double.Parse(Console.ReadLine());
      productId = products.Count + 1;
      products.Add(new Product(productId, productName, productPrice));
      Product product = products.Find(p => p.Id == productId);
      Console.WriteLine("Please enter the quantity:");
      int quantity = int.Parse(Console.ReadLine());
      ProductStock productStock = new ProductStock(productId, quantity);
      stock.Add(productStock);
   }
   else
   {
      // update the quantity of the itens on the stock
      productId = int.Parse(response);
      Product product = products.Find(p => p.Id == productId);
      Console.WriteLine("Please enter the quantity (Positive for entrance or negative for exits):");
      int quantity = int.Parse(Console.ReadLine());
      ProductStock productStock = stock.Find(s => s.ProductId == productId);
      productStock.Quantity += quantity;
   }

   Console.WriteLine("Product stock updated successfully!");
   Console.WriteLine("Press any key to continue...");
   Console.ReadKey();
   Console.Clear();
   stockService();
}

void deleteProduct()
{
   Console.Clear();
   Console.WriteLine("**********************");
   Console.WriteLine("*   DELETE PRODUCT   *");
   Console.WriteLine("**********************");
   foreach (var s in stock)
   {
      Product product = products.Find(p => p.Id == s.ProductId);
      Console.WriteLine($"* Product Id: {product.Id} - Name: {product.Name} - Quantity: {s.Quantity} *");
      Console.WriteLine("**********************");
   }
   Console.WriteLine("Please enter the product id:");
   int productId = int.Parse(Console.ReadLine());
   ProductStock productStock = stock.Find(s => s.ProductId == productId);
   Console.WriteLine("Are you sure you want to delete this product? (Y/N)");
   string option = Console.ReadLine();
   if (option.ToUpper() == "N")
   {
      Console.Clear();
      stockService();
   }

   stock.Remove(productStock);
   Console.WriteLine("Product deleted successfully!");
   Console.WriteLine("Press any key to continue...");
   Console.ReadKey();
   Console.Clear();
   stockService();
}

void showUsers()
{
   Console.Clear();
   Console.WriteLine("**********************");
   Console.WriteLine("*       USERS        *");
   Console.WriteLine("**********************");
   foreach (var u in users)
   {
      Console.WriteLine($"* User Id: {u.Id} - Name: {u.Name} - Privilege: {u.Privilege} *");
      Console.WriteLine("**********************");
   }
   Console.WriteLine("Press any key to continue...");
   Console.ReadKey();
   Console.Clear();
   userService();
}

void addUser()
{
   Console.Clear();
   Console.WriteLine("**********************");
   Console.WriteLine("*      ADD USER      *");
   Console.WriteLine("**********************");
   Console.WriteLine("Please enter the user name:");
   string userName = Console.ReadLine();
   Console.WriteLine("Please enter the user privilege (Admin, Order, Stock):");
   string userPrivilege = Console.ReadLine();
   users.Add(new User(users.Count + 1, userName, userPrivilege));
   Console.WriteLine("User added successfully!");
   Console.WriteLine("Press any key to continue...");
   Console.ReadKey();
   Console.Clear();
   userService();
}

void deleteUser()
{
   Console.Clear();
   Console.WriteLine("**********************");
   Console.WriteLine("*     DELETE USER    *");
   Console.WriteLine("**********************");
   foreach (var u in users)
   {
      Console.WriteLine($"* User Id: {u.Id} - Name: {u.Name} - Privilege: {u.Privilege} *");
      Console.WriteLine("**********************");
   }
   Console.WriteLine("Please enter the user id:");
   int userId = int.Parse(Console.ReadLine());
   User user = users.Find(u => u.Id == userId);
   Console.WriteLine("Are you sure you want to delete this user? (Y/N)");
   string option = Console.ReadLine();
   if (option.ToUpper() == "N")
   {
      Console.Clear();
      userService();
   }

   users.Remove(user);
   Console.WriteLine("User deleted successfully!");
   Console.WriteLine("Press any key to continue...");
   Console.ReadKey();
   Console.Clear();
   userService();
}

#endregion



#region MODELS
class Product
{
   public int Id { get; set; }
   public string Name { get; set; }
   public double Price { get; set; }

   public Product(int id, string name, double price)
   {
      Id = id;
      Name = name;
      Price = price;
   }
}

class ProductStock
{
   public int ProductId { get; set; }
   public int Quantity { get; set; }

   public ProductStock(int productId, int quantity)
   {
      ProductId = productId;
      Quantity = quantity;
   }
}

class User
{
   public int Id { get; set; }
   public string Name { get; set; }
   public string Privilege { get; set; }

   public User(int id, string name, string privilege)
   {
      Id = id;
      Name = name;
      Privilege = privilege;
   }
}

class Order
{
   public int Id { get; set; }
   public string UserName { get; set; }
   public int ProductId { get; set; }
   public string ProductName { get; set; }
   public int Quantity { get; set; }
   public decimal TotalPrice { get; set; }

   public List<OrderItem> productsList = new();

   public Order(int id, User user, List<OrderItem> productsList)
   {
      Id = id;
      UserName = user.Name;
      this.productsList = productsList;
   }

}

class OrderItem
{
   public int ProductId { get; set; }
   public string ProductName { get; set; }
   public int Quantity { get; set; }
   public double TotalPrice { get; set; }

   public OrderItem(int productId, string productName, int quantity, double totalPrice)
   {
      ProductId = productId;
      ProductName = productName;
      Quantity = quantity;
      TotalPrice = totalPrice;
   }
}
#endregion


