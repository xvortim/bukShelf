using bukShelf.Database;
using bukShelf.Managers;
using System;

namespace bukShelf
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;Port=5432;Database=bukShelfDatabase;Username=admin;Password=admin";
            var databaseService = new DatabaseService(connectionString);
            var bookManager = new BookManager(databaseService);
            var shelfManager = new ShelfManager(databaseService);

            try
            {
                databaseService.CreateTables();

                Console.WriteLine("Application is running...");
                Console.WriteLine("Welcome to the Book and Shelf Management System!");

                while (true)
                {
                    Console.WriteLine("\nSelect an option:");
                    Console.WriteLine("1. Add a Book");
                    Console.WriteLine("2. Delete a Book");
                    Console.WriteLine("3. Add a Shelf");
                    Console.WriteLine("4. Add a Book to Shelf");
                    Console.WriteLine("5. View all Books");
                    Console.WriteLine("6. Exit");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            bookManager.AddBook();
                            break;
                        case "2":
                            bookManager.DeleteBookByName();
                            break;
                        case "3":
                            shelfManager.AddShelf();
                            break;
                        case "4":
                            shelfManager.AddBookToShelf();
                            break;
                        case "5":
                            bookManager.ListAllBooks();
                            break;
                        case "6":
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
            finally
            {
                databaseService.DropTables();
            }
        }
    }
}
