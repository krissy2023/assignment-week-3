﻿using EntityModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Week3EntityFramework.Dtos;

var context = new IndustryConnectWeek2Context();

//var customer = new Customer
//{
//    DateOfBirth = DateTime.Now.AddYears(-20)
//};


//Console.WriteLine("Please enter the customer firstname?");

//customer.FirstName = Console.ReadLine();

//Console.WriteLine("Please enter the customer lastname?");

//customer.LastName = Console.ReadLine();


//var customers = context.Customers.ToList();

//foreach (Customer c in customers)
//{   
//    Console.WriteLine("Hello I'm " + c.FirstName);
//}

//Console.WriteLine($"Your new customer is {customer.FirstName} {customer.LastName}");

//Console.WriteLine("Do you want to save this customer to the database?");

//var response = Console.ReadLine();

//if (response?.ToLower() == "y")
//{
//    context.Customers.Add(customer);
//    context.SaveChanges();
//}



//var sales = context.Sales.Include(c => c.Customer)
//    .Include(p => p.Product).ToList();

//var salesDto = new List<SaleDto>();

//foreach (Sale s in sales)
//{
//    salesDto.Add(new SaleDto(s));
//}



//context.Sales.Add(new Sale
//{
//    ProductId = 1,
//    CustomerId = 1,
//    StoreId = 1,
//    DateSold = DateTime.Now
//});


//context.SaveChanges();




//Console.WriteLine("Which customer record would you like to update?");

//var response = Convert.ToInt32(Console.ReadLine());

//var customer = context.Customers.Include(s => s.Sales)
//    .ThenInclude(p => p.Product)
//    .FirstOrDefault(c => c.Id == response);


//var total = customer.Sales.Select(s => s.Product.Price).Sum();


//var customerSales = context.CustomerSales.ToList();

//var totalsales = customer.Sales



//Console.WriteLine($"The customer you have retrieved is {customer?.FirstName} {customer?.LastName}");

//Console.WriteLine($"Would you like to updated the firstname? y/n");

//var updateResponse = Console.ReadLine();

//if (updateResponse?.ToLower() == "y")
//{

//    Console.WriteLine($"Please enter the new name");

//    customer.FirstName = Console.ReadLine();
//    context.Customers.Add(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//    context.SaveChanges();
//}



var customerWithoutSale = context.Customers.Include(c => c.Sales)
    .Where(c => c.Sales.Count() == 0).ToList();

foreach (var customer in customerWithoutSale)
{
    Console.WriteLine($"{customer.FirstName} {customer.LastName}");
}

Console.WriteLine();
var customer2 = new Customer();

Console.WriteLine("Would you like to add a new customer? y/n");
var response = Console.ReadLine();
if (response?.ToLower() == "y")
{
    Console.WriteLine("Please enter customer's first name");
    customer2.FirstName = Console.ReadLine();
    Console.WriteLine("Please enter customer's last name");
    customer2.LastName = Console.ReadLine();
}

Console.WriteLine("Would you like to add a new sale for this customer?");
var response2 = Console.ReadLine();
if (response?.ToLower() == "y")
{
    Console.WriteLine("Which product would you like to add?");
    var product = Convert.ToInt32(Console.ReadLine());
    customer2.Sales.Add(new Sale { ProductId = product });
}


context.Customers.Add(customer2);
context.SaveChanges();



var newStore = new Store();

Console.WriteLine();
Console.WriteLine("Please enter the store name.");
newStore.Name = Console.ReadLine();

context.Stores.Add(newStore);
context.SaveChanges();



Console.ReadLine();









