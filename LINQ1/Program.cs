using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}

public class Order
{
    public int OrderID { get; set; }
    public DateTime OrderDate { get; set; }
}

public class Customer
{
    public string CustomerID { get; set; }
    public List<Order> Orders { get; set; }
}

public static class Data
{
    public static List<Product> ProductList = new List<Product>
    {
        new Product { ProductID = 1, ProductName = "Chai",          Category = "Beverages",  UnitPrice = 18.00m, UnitsInStock = 39 },
        new Product { ProductID = 2, ProductName = "Chang",         Category = "Beverages",  UnitPrice = 19.00m, UnitsInStock = 17 },
        new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.00m, UnitsInStock = 13 },
        new Product { ProductID = 4, ProductName = "Ikura",         Category = "Seafood",    UnitPrice = 31.00m, UnitsInStock = 0  },
    };

    public static List<Customer> CustomerList = new List<Customer>
    {
        new Customer { CustomerID = "ALFKI", Orders = new List<Order>
        {
            new Order { OrderID = 10643, OrderDate = new DateTime(1997, 8, 25) },
            new Order { OrderID = 10835, OrderDate = new DateTime(1998, 1, 15) },
            new Order { OrderID = 10692, OrderDate = new DateTime(1996, 10, 3) },
        }},
        new Customer { CustomerID = "ANATR", Orders = new List<Order>
        {
            new Order { OrderID = 10308, OrderDate = new DateTime(1996, 9, 18) },
            new Order { OrderID = 10625, OrderDate = new DateTime(1997, 8, 8) },
        }},
    };
}

public class Program
{
    static void Header(string title) => Console.WriteLine($"\n= {title} =");

    static void Main()
    {
        var ProductList = Data.ProductList;
        var CustomerList = Data.CustomerList;

        // Q1
        Header("Q1");
        var seafood = ProductList.Where(p => p.Category == "Seafood");
        foreach (var p in seafood)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        // Q2
        Header("Q2");
        List<string> names = ProductList.Select(p => p.ProductName).ToList();
        foreach (var n in names)
            Console.WriteLine(n);

        // Q3
        Header("Q3");
        foreach (var p in ProductList.OrderBy(p => p.UnitPrice))
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        // Q4
        Header("Q4");
        foreach (var p in ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30))
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        // Q5
        Header("Q5");
        foreach (var p in ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments"))
            Console.WriteLine($"{p.ProductName} - {p.Category} - Stock: {p.UnitsInStock}");

        // Q6
        Header("Q6");
        var result = ProductList.Select(p => new
        {
            Name = p.ProductName,
            Price = p.UnitPrice,
            StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
        });
        foreach (var item in result)
            Console.WriteLine($"{item.Name} | {item.Price} | {item.StockStatus}");

        // Q7
        Header("Q7");
        var numbered = ProductList.Select((p, i) => new { Index = i + 1, p.ProductName });
        foreach (var item in numbered)
            Console.WriteLine($"{item.Index}. {item.ProductName}");

        // Q8
        Header("Q8");
        var sorted = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
        foreach (var p in sorted)
            Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice}");

        // Q9
        Header("Q9");
        var beverages = ProductList
            .Where(p => p.Category == "Beverages")
            .OrderByDescending(p => p.UnitsInStock);
        foreach (var p in beverages)
            Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");

        // Q10
        Header("Q10");
        var orders = from c in CustomerList
                     from o in c.Orders
                     where o.OrderDate.Year >= 1997
                     select new { c.CustomerID, o.OrderDate };
        foreach (var o in orders)
            Console.WriteLine($"{o.CustomerID} - {o.OrderDate:yyyy-MM-dd}");

        // Q11
        Header("Q11");
        foreach (var item in ProductList.Select((p, i) => new { Position = i + 1, p.ProductName }))
            Console.WriteLine($"{item.Position} - {item.ProductName}");

        // Q12
        Header("Q12");
        string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        var sortedWords = Arr
            .OrderBy(w => w.Length)
            .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
        foreach (var w in sortedWords)
            Console.WriteLine(w);

        // Q13
        Header("Q13");
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var withI = digits
            .Where(d => d.Length > 1 && d[1] == 'i')
            .Reverse()
            .ToList();
        foreach (var d in withI)
            Console.WriteLine(d);
    }
}
