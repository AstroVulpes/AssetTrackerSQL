using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WeeklyMiniProject_w30_31
{
    public static class StringExt
    {
        public static string? Truncate(this string? value, int maxLength, string truncationSuffix = "…")
        {
            return value?.Length > maxLength
                ? value.Substring(0, maxLength) + truncationSuffix
                : value;
        }
    }

    class Program
    {
        private static bool exit = false;
        private static Office defaultOffice = new Office() { Name = "default" };
        private static Product defaultProduct = new Laptop() { Brand = "default" };
        /*
          /$$$$$$                                  /$$                     /$$$$$$$              /$$               /$$                                    
         /$$__  $$                                | $$                    | $$__  $$            | $$              | $$                                      
        | $$  \__/  /$$$$$$   /$$$$$$   /$$$$$$  /$$$$$$    /$$$$$$       | $$  \ $$  /$$$$$$  /$$$$$$    /$$$$$$ | $$$$$$$   /$$$$$$   /$$$$$$$  /$$$$$$ 
        | $$       /$$__  $$ /$$__  $$ |____  $$|_  $$_/   /$$__  $$      | $$  | $$ |____  $$|_  $$_/   |____  $$| $$__  $$ |____  $$ /$$_____/ /$$__  $$
        | $$      | $$  \__/| $$$$$$$$  /$$$$$$$  | $$    | $$$$$$$$      | $$  | $$  /$$$$$$$  | $$      /$$$$$$$| $$  \ $$  /$$$$$$$|  $$$$$$ | $$$$$$$$
        | $$    $$| $$      | $$_____/ /$$__  $$  | $$ /$$| $$_____/      | $$  | $$ /$$__  $$  | $$ /$$ /$$__  $$| $$  | $$ /$$__  $$ \____  $$| $$_____/
        |  $$$$$$/| $$      |  $$$$$$$|  $$$$$$$  |  $$$$/|  $$$$$$$      | $$$$$$$/|  $$$$$$$  |  $$$$/|  $$$$$$$| $$$$$$$/|  $$$$$$$ /$$$$$$$/|  $$$$$$$
         \______/ |__/       \_______/ \_______/   \___/   \_______/      |_______/  \_______/   \___/   \_______/|_______/  \_______/|_______/  \_______/
        */
        private static void CreateDb(ProductContext context)
        {
            context.Database.EnsureCreated();

            var product1 = new Laptop() { Type = "Laptop", Brand = "Apple", Model = "MacBook Pro 14” M3 8 GB 512 GB", PurchaseDate = new DateTime(2024, 1, 1), Price = 23995 };
            var product2 = new Laptop() { Type = "Laptop", Brand = "Apple", Model = "MacBook Pro 16” M3 Max 48 GB 1 TB", PurchaseDate = new DateTime(2023, 12, 31), Price = 55745 };
            var product3 = new Laptop() { Type = "Laptop", Brand = "Apple", Model = "MacBook Air 13” M2 8 GB 256 GB", PurchaseDate = new DateTime(2021, 1, 3), Price = 13495 };
            var product4 = new Laptop() { Type = "Laptop", Brand = "Apple", Model = "MacBook Air 15” M3 16 GB 512 GB", PurchaseDate = new DateTime(2022, 1, 6), Price = 23995 };
            var productA = new MobilePhone() { Type = "Mobile phone", Brand = "Apple", Model = "iPhone 13 128 GB", PurchaseDate = new DateTime(2022, 5, 1), Price = 8995 };
            var productB = new MobilePhone() { Type = "Mobile phone", Brand = "Apple", Model = "iPhone 15 Pro Max 128 GB", PurchaseDate = new DateTime(2022, 7, 17), Price = 23995 };
            var product5 = new Laptop() { Type = "Laptop", Brand = "Lenovo", Model = "ThinkPad X12 Gen 2 Detachable (12” Intel)", PurchaseDate = new DateTime(2022, 4, 12), Price = 25953 };
            var product6 = new Laptop() { Type = "Laptop", Brand = "Lenovo", Model = "LOQ Gen 9 (15” AMD 7TH Gen)", PurchaseDate = new DateTime(2022, 3, 19), Price = 12279 };
            var product7 = new Laptop() { Type = "Laptop", Brand = "Lenovo", Model = "ThinkBook 16 Gen 7 (16” AMD)", PurchaseDate = new DateTime(2022, 8, 13), Price = 8199.20 };
            var product8 = new Laptop() { Type = "Laptop", Brand = "Lenovo", Model = "Yoga 7i 2-i-1 Gen 9 (16” Intel)", PurchaseDate = new DateTime(2022, 9, 21), Price = 11287.15 };
            var product9 = new Laptop() { Type = "Laptop", Brand = "ASUS", Model = "14.0” Vivobook Go 14 (E410)", PurchaseDate = new DateTime(2022, 7, 21), Price = 2990 };
            var product10 = new Laptop() { Type = "Laptop", Brand = "ASUS", Model = "14” Chromebook Plus CX34 (CX3402)", PurchaseDate = new DateTime(2022, 2, 28), Price = 6290 };
            var product11 = new Laptop() { Type = "Laptop", Brand = "ASUS", Model = "16” TUF Gaming F16 (2024)", PurchaseDate = new DateTime(2024, 2, 29), Price = 17490 };
            var product12 = new Laptop() { Type = "Laptop", Brand = "ASUS", Model = "ROG Strix SCAR 18 (2024) G834JYR-R6019W", PurchaseDate = new DateTime(2024, 3, 1), Price = 55990 };
            var productC = new MobilePhone() { Type = "Mobile phone", Brand = "Samsung", Model = "Galaxy S24 Ultra", PurchaseDate = new DateTime(2024, 6, 1), Price = 19490 };
            var productD = new MobilePhone() { Type = "Mobile phone", Brand = "Nokia", Model = "HMD Pulse+ Business Edition 128/6 GB", PurchaseDate = new DateTime(2022, 7, 1), Price = 2549 };

            List<Product> productsSweden = new List<Product>();
            productsSweden.Add(product1);
            productsSweden.Add(product12);
            productsSweden.Add(product7);
            productsSweden.Add(productA);
            productsSweden.Add(product9);
            Office officeSweden = new Office() { Name = "Sweden", Currency = "SEK", Products = productsSweden };

            List<Product> productsUnitedStates = new List<Product>();
            productsUnitedStates.Add(product10);
            productsUnitedStates.Add(product2);
            productsUnitedStates.Add(product11);
            productsUnitedStates.Add(productB);
            productsUnitedStates.Add(productC);
            productsUnitedStates.Add(product8);
            Office officeUnitedStates = new Office() { Name = "United States", Currency = "USD", Products = productsUnitedStates };

            List<Product> productsSpain = new List<Product>();
            productsSpain.Add(product3);
            productsSpain.Add(product4);
            productsSpain.Add(product5);
            productsSpain.Add(product6);
            productsSpain.Add(productD);
            Office officeSpain = new Office() { Name = "Spain", Currency = "EUR", Products = productsSpain };

            context.Products.Add(productA);
            context.Products.Add(productB);
            context.Products.Add(productC);
            context.Products.Add(productD);
            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.Products.Add(product4);
            context.Products.Add(product5);
            context.Products.Add(product6);
            context.Products.Add(product7);
            context.Products.Add(product8);
            context.Products.Add(product9);
            context.Products.Add(product10);
            context.Products.Add(product11);
            context.Products.Add(product12);

            context.Offices.Add(officeSpain);
            context.Offices.Add(officeUnitedStates);
            context.Offices.Add(officeSweden);

            context.SaveChanges();
            /*
            foreach (var p in context.Products)
            {
                Console.WriteLine($"Brand: {p.Brand}, Model: {p.Model}, Purchase date: {p.PurchaseDate.ToString("yyyy-MM-dd")}, Price: {p.Price.ToString("F2")}");
            }
            */

        }

        /*
         /$$$$$$$           /$$             /$$           /$$$$$$$              /$$               /$$                                    
        | $$__  $$         |__/            | $$          | $$__  $$            | $$              | $$                                    
        | $$  \ $$ /$$$$$$  /$$ /$$$$$$$  /$$$$$$        | $$  \ $$  /$$$$$$  /$$$$$$    /$$$$$$ | $$$$$$$   /$$$$$$   /$$$$$$$  /$$$$$$ 
        | $$$$$$$//$$__  $$| $$| $$__  $$|_  $$_/        | $$  | $$ |____  $$|_  $$_/   |____  $$| $$__  $$ |____  $$ /$$_____/ /$$__  $$
        | $$____/| $$  \__/| $$| $$  \ $$  | $$          | $$  | $$  /$$$$$$$  | $$      /$$$$$$$| $$  \ $$  /$$$$$$$|  $$$$$$ | $$$$$$$$
        | $$     | $$      | $$| $$  | $$  | $$ /$$      | $$  | $$ /$$__  $$  | $$ /$$ /$$__  $$| $$  | $$ /$$__  $$ \____  $$| $$_____/
        | $$     | $$      | $$| $$  | $$  |  $$$$/      | $$$$$$$/|  $$$$$$$  |  $$$$/|  $$$$$$$| $$$$$$$/|  $$$$$$$ /$$$$$$$/|  $$$$$$$
        |__/     |__/      |__/|__/  |__/   \___/        |_______/  \_______/   \___/   \_______/|_______/  \_______/|_______/  \_______/                                                                                                                        
        */
        private static void PrintDb(ProductContext context)
        {
            /* Order products by office, then type, then price */
            var offices = context.Offices.Include(o => o.Products)
                                          .OrderBy(o => o.Name)
                                          .ToList()
                                          .Select(o => new Office()
                                          {
                                              OfficeID = o.OfficeID,
                                              Name = o.Name,
                                              Currency = o.Currency,
                                              Products = o.Products
                                              .OrderBy(p => p.Price)
                                              .ToList()
                                          });



            List<string> headers = new List<string>() { "P-ID", "Type", "Brand", "Model", "O-ID", "Office", "Buy date", "PriceSEK", "Crrncy", "Lcl price" };
            Console.WriteLine("{0,-5}{1,-13}{2,-13}{3,-30}{4,-5}{5,-14}{6,-14}{7,-9}{8,-7}{9,-9}", headers[0], headers[1], headers[2], headers[3], headers[4], headers[5],
                headers[6], headers[7], headers[8], headers[9]);
            Console.WriteLine(new string('-', 119));

            int total = 0, safe = 0, yellow = 0, red = 0;
            /* Iterate through all the products that are returned and print them */
            foreach (var o in offices)
            {
                foreach (var p in o.Products)
                {
                    if ((DateTime.Now.AddMonths(3) - p.PurchaseDate.AddYears(3)).TotalDays > 0) // Color the text red if the product is older than 3 years in 3 months
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        red++;
                    }
                    else if ((DateTime.Now.AddMonths(6) - p.PurchaseDate.AddYears(3)).TotalDays > 0) // Color the text yellow if the product is older than 3 years in 6 months
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        yellow++;
                    }
                    else
                    {
                        safe++;
                    }
                    Console.WriteLine("{0,5}{1,-13}{2,-13}{3,-30}{4,5}{5,-14}{6,-14}{7,9}{8,7}{9,9}", p.ProductID + " ", p.Type, p.Brand, p.Model.Truncate(28), o.OfficeID + " ", o.Name,
                        p.PurchaseDate.ToString("yyyy-MM-dd"), p.Price.ToString("F2") + " ",
                        o.Currency + " ", (o.Currency == "SEK") ? p.Price.ToString("F2") :
                        LiveCurrency.Convert(p.Price, "SEK", o.Currency).ToString("F2")); // Convert the currency from SEK to the local office's if it isn't already in SEK
                    if ((DateTime.Now.AddMonths(6) - p.PurchaseDate.AddYears(3)).TotalDays > 0 || (DateTime.Now.AddMonths(3) - p.PurchaseDate.AddYears(3)).TotalDays > 0)
                        Console.ResetColor();
                }
            }
            total = safe + yellow + red;
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.Write("Total products: " + total.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Safe: " + safe.ToString());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Almost expired: " + yellow.ToString());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Expired: " + red.ToString());
            Console.ResetColor();
        }

        /*
         /$$      /$$                                          
        | $$$    /$$$                                          
        | $$$$  /$$$$  /$$$$$$  /$$$$$$$  /$$   /$$       /$$$$
        | $$ $$/$$ $$ /$$__  $$| $$__  $$| $$  | $$      |____/
        | $$  $$$| $$| $$$$$$$$| $$  \ $$| $$  | $$       /$$$$
        | $$\  $ | $$| $$_____/| $$  | $$| $$  | $$      |____/
        | $$ \/  | $$|  $$$$$$$| $$  | $$|  $$$$$$/            
        |__/     |__/ \_______/|__/  |__/ \______/             
        */
        private static void Menu(ProductContext context)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Select action: (1) Add (2) Edit (3) Remove (4) Quit");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string input = Console.ReadLine();
            Console.ResetColor();

            int selection = 0;
            int.TryParse(input, out selection);

            switch (selection)
            {
                case 1:
                    Add(context);
                    break;
                case 2:
                    Edit(context);
                    break;
                case 3:
                    Remove(context);
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid selection.");
                    Console.ResetColor();
                    Menu(context);
                    return;
            }
        }

        /*
          /$$$$$$        /$$       /$$          
         /$$__  $$      | $$      | $$    /$$   
        | $$  \ $$  /$$$$$$$  /$$$$$$$   | $$   
        | $$$$$$$$ /$$__  $$ /$$__  $$ /$$$$$$$$
        | $$__  $$| $$  | $$| $$  | $$|__  $$__/
        | $$  | $$| $$  | $$| $$  | $$   | $$   
        | $$  | $$|  $$$$$$$|  $$$$$$$   |__/   
        |__/  |__/ \_______/ \_______/          
        */
        private static void Add(ProductContext context)
        {
            /* Type */
            string input1 = "init";
            int type = 0;
            do
            {
                if (input1 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Type.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Type (1. Laptop; 2. Mobile phone): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input1 = Console.ReadLine();

                int.TryParse(input1, out type);
            } while (type < 1 || type > 2);

            /* Brand */
            string input2 = "init";
            do
            {
                if (input2 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Brand: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input2 = Console.ReadLine();
            } while (input2 == "");

            /* Model */
            string input3 = "init";
            do
            {
                if (input3 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Model: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input3 = Console.ReadLine();
            } while (input3 == "");

            /* Date */
            string input4 = "init";
            DateTime date = new DateTime();
            do
            {
                if (input4 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Date.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Date: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input4 = Console.ReadLine();
                DateTime.TryParse(input4, out date);
            } while (date == new DateTime());

            /* Price SEK */
            string input5 = "init";
            double price = 0;
            do
            {
                if (input5 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Price.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Price (SEK): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input5 = Console.ReadLine();

                double.TryParse(input5, out price);
            } while (price <= 0);

            /* Office */
            string input6 = "init";
            int officeID = 0;
            Office office = defaultOffice;
            do
            {
                if (input6 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Office.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Office ID: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input6 = Console.ReadLine();

                int.TryParse(input6, out officeID);
                var officeQuery = context.Offices.DefaultIfEmpty().First(o => o.OfficeID == officeID);
                if (officeQuery == null)
                {
                    officeID = 0;
                }
                else
                {
                    office = officeQuery;
                }
            } while (officeID <= 0);

            Console.ResetColor();

            switch (type)
            {
                case 1:
                    var product1 = new Laptop() { Type = "Laptop", Brand = input2, Model = input3, PurchaseDate = date, Price = price };
                    context.Products.Add(product1);
                    context.Offices.First(o => o.OfficeID == office.OfficeID).Products.Add(product1);


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Product ID {product1.ProductID} added.");
                    Console.ResetColor();
                    break;
                case 2:
                    var product2 = new MobilePhone() { Type = "Mobile phone", Brand = input2, Model = input3, PurchaseDate = date, Price = price };
                    context.Products.Add(product2);
                    context.Offices.First(o => o.OfficeID == office.OfficeID).Products.Add(product2);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Product ID {product2.ProductID} added.");
                    Console.ResetColor();
                    break;
            }
            context.Offices.Update(office);
            context.SaveChanges();
        }

        /*
         /$$$$$$$$       /$$ /$$   /$$    /$$$ /$$
        | $$_____/      | $$|__/  | $$   /$$ $$ $$
        | $$        /$$$$$$$ /$$ /$$$$$$| $$  $$$/
        | $$$$$    /$$__  $$| $$|_  $$_/|__/\___/ 
        | $$__/   | $$  | $$| $$  | $$            
        | $$      | $$  | $$| $$  | $$ /$$        
        | $$$$$$$$|  $$$$$$$| $$  |  $$$$/        
        |________/ \_______/|__/   \___/           
        */
        private static void Edit(ProductContext context)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Input ID: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string inputD = "init";
            int selection = -1;

            inputD = Console.ReadLine();
            int.TryParse(inputD, out selection);

            if (selection <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID.");
                Console.ResetColor();
                Edit(context);
                return;
            }

            var productToEdit = context.Products.DefaultIfEmpty().First(p => p.ProductID == selection);

            if (productToEdit == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID not found.");
                Console.ResetColor();
                Edit(context);
                return;
            }

            /* Type */
            string input1 = "init";
            int type = 0;
            do
            {
                if (input1 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Type.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Type (1. Laptop; 2. Mobile phone) (optional): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input1 = Console.ReadLine();

                int.TryParse(input1, out type);
                if (input1 == "")
                {
                    break;
                }
                else if (type == 1)
                {
                    if (productToEdit.Type != "Laptop")
                    {
                        productToEdit = new Laptop()
                        {
                            Type = "Laptop",
                            Brand = productToEdit.Brand,
                            Model = productToEdit.Model,
                            PurchaseDate = productToEdit.PurchaseDate,
                            Price = productToEdit.Price
                        };
                    }
                }
                else if (type == 2)
                {
                    if (productToEdit.Type != "Mobile phone")
                    {
                        productToEdit = new MobilePhone()
                        {
                            Type = "Mobile phone",
                            Brand = productToEdit.Brand,
                            Model = productToEdit.Model,
                            PurchaseDate = productToEdit.PurchaseDate,
                            Price = productToEdit.Price
                        };
                    }
                }
            } while (type < 1 || type > 2);

            /* Brand */
            string input2 = "init";
            do
            {
                if (input2 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Brand (optional): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input2 = Console.ReadLine();
                if (input2 == "")
                {
                    break;
                }
                else
                {
                    productToEdit.Brand = input2;
                }
            } while (input2 == "");

            /* Model */
            string input3 = "init";
            do
            {
                if (input3 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Model (optional): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input3 = Console.ReadLine();
                if (input3 == "")
                {
                    break;
                }
                else
                {
                    productToEdit.Model = input3;
                }
            } while (input3 == "");

            /* Date */
            string input4 = "init";
            DateTime date = new DateTime();
            do
            {
                if (input4 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Date.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Date (optional): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input4 = Console.ReadLine();
                DateTime.TryParse(input4, out date);
                if (input4 == "")
                {
                    break;
                }
                else if (date != new DateTime())
                {
                    productToEdit.PurchaseDate = date;
                }
            } while (date == new DateTime());

            /* Price SEK */
            string input5 = "init";
            double price = 0;
            do
            {
                if (input5 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Price.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Price (SEK) (optional): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input5 = Console.ReadLine();

                double.TryParse(input5, out price);
                if (input5 == "")
                {
                    break;
                }
                else if (price > 0)
                {
                    productToEdit.Price = price;
                }
            } while (price <= 0);

            /* Office */
            string input6 = "init";
            int officeID = 0;
            Office office = defaultOffice;
            do
            {
                if (input6 != "init")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Office.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Office ID (optional): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input6 = Console.ReadLine();

                int.TryParse(input6, out officeID);
                var officeQuery = context.Offices.DefaultIfEmpty().First(o => o.OfficeID == officeID);
                if (input6 == "")
                {
                    break;
                }
                else if (officeQuery == null)
                {
                    officeID = 0;
                }
                else
                {
                    office = officeQuery;
                    context.Offices.ToList().ForEach(o => o.Products.RemoveAll(p => p.ProductID == productToEdit.ProductID));
                    office.Products.Add(productToEdit);
                }
            } while (officeID <= 0);

            context.Products.Update(productToEdit);
            context.Offices.Update(office);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Product ID {selection} edited.");
            Console.ResetColor();
        }

        /*
         /$$$$$$$                                                               
        | $$__  $$                                                              
        | $$  \ $$  /$$$$$$  /$$$$$$/$$$$   /$$$$$$  /$$    /$$ /$$$$$$         
        | $$$$$$$/ /$$__  $$| $$_  $$_  $$ /$$__  $$|  $$  /$$//$$__  $$ /$$$$$$
        | $$__  $$| $$$$$$$$| $$ \ $$ \ $$| $$  \ $$ \  $$/$$/| $$$$$$$$|______/
        | $$  \ $$| $$_____/| $$ | $$ | $$| $$  | $$  \  $$$/ | $$_____/        
        | $$  | $$|  $$$$$$$| $$ | $$ | $$|  $$$$$$/   \  $/  |  $$$$$$$        
        |__/  |__/ \_______/|__/ |__/ |__/ \______/     \_/    \_______/        
        */
        private static void Remove(ProductContext context)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Input ID: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string inputD = "init";
            int selection = -1;

            inputD = Console.ReadLine();
            int.TryParse(inputD, out selection);

            if (selection <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID.");
                Console.ResetColor();
                Remove(context);
                return;
            }

            var productToDelete = context.Products.DefaultIfEmpty().First(p => p.ProductID == selection);

            if (productToDelete == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID not found.");
                Console.ResetColor();
                Remove(context);
                return;
            }

            context.Offices.ToList().ForEach(o => o.Products.RemoveAll(p => p.ProductID == productToDelete.ProductID));
            context.Products.Remove(productToDelete);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Product ID {selection} removed.");
            Console.ResetColor();
        }

        /*
          /$$$$$$            /$$   /$$                    
         /$$__  $$          |__/  | $$                    
        | $$  \ $$ /$$   /$$ /$$ /$$$$$$         /$$   /$$
        | $$  | $$| $$  | $$| $$|_  $$_/        |  $$ /$$/
        | $$  | $$| $$  | $$| $$  | $$           \  $$$$/ 
        | $$/$$ $$| $$  | $$| $$  | $$ /$$        >$$  $$ 
        |  $$$$$$/|  $$$$$$/| $$  |  $$$$/       /$$/\  $$
         \____ $$$ \______/ |__/   \___/        |__/  \__/
              \__/                                                                               
        */
        private static void Quit()
        {
            /* Closes the window after a countdown has finished */
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Thank you for using AssetTracker. The Program will close in 5...");
            while (stopwatch.ElapsedMilliseconds < 1000) { }
            Console.Write("\b\b\b\b4...");
            while (stopwatch.ElapsedMilliseconds < 2000) { }
            Console.Write("\b\b\b\b3...");
            while (stopwatch.ElapsedMilliseconds < 3000) { }
            Console.Write("\b\b\b\b2...");
            while (stopwatch.ElapsedMilliseconds < 4000) { }
            Console.Write("\b\b\b\b1...");
            while (stopwatch.ElapsedMilliseconds < 5000) { }
            Console.Write("\b\b\b\b0...");
            while (stopwatch.ElapsedMilliseconds < 6000) { }
            Console.ResetColor();
        }

        /*
         /$$      /$$  /$$$$$$  /$$$$$$ /$$   /$$
        | $$$    /$$$ /$$__  $$|_  $$_/| $$$ | $$
        | $$$$  /$$$$| $$  \ $$  | $$  | $$$$| $$
        | $$ $$/$$ $$| $$$$$$$$  | $$  | $$ $$ $$
        | $$  $$$| $$| $$__  $$  | $$  | $$  $$$$
        | $$\  $ | $$| $$  | $$  | $$  | $$\  $$$
        | $$ \/  | $$| $$  | $$ /$$$$$$| $$ \  $$
        |__/     |__/|__/  |__/|______/|__/  \__/                                     
        */
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Asset Tracker v1.0");
            Console.ResetColor();

            LiveCurrency.FetchRates(); // Fetch the exchange rates once before running the program

            var context = new ProductContext(); // Used to work with the database throughout
            if (!(context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists()) // Create the database if it is not found
                CreateDb(context);

            while (!exit) // Program loop
            {
                PrintDb(context);

                Menu(context);
            }

            Quit();
        }
    }
}