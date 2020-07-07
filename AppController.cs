using System;
using timstacos.Models;

namespace timstacos
{
  public class App
  {
    public Truck Truck { get; set; }
    public bool Running { get; private set; }

    public void Run()
    {
      Console.Clear();
      Truck = new Truck("West Bench Mark St", "Tims Taco Truck");
      Truck.Tacos.Add(new Taco("Banana", "Chocolate", 5));
      Console.WriteLine($"\nWelcome to {Truck.Name} - {Truck.Location}");
      Running = true;
      while (Running)
      {
        System.Console.WriteLine("What Would you like to do? Order / Stock / Quit");
        string input = Console.ReadLine().ToLower();
        switch (input)
        {
          case "order":
          case "o":
          case "buy":
          case "purchase":
            OrderTaco();
            break;
          case "stock":
          case "s":
          case "refil":
          case "restock":
            StockTaco();
            break;
          case "quit":
          case "q":
          case "end":
            Running = false;
            System.Console.WriteLine("Adios mi Bandito");
            break;
          default:
            System.Console.WriteLine("Invalid Command");
            break;
        }
      }
    }

    public void StockTaco()
    {
      Console.Clear();
      Truck.ViewTacos(false);
      System.Console.WriteLine("Select a taco to stock!");
      string selection = Console.ReadLine();
      Taco selectedTaco = Truck.checkTacoAvailability(selection);
      if (selectedTaco == null)
      {
        System.Console.WriteLine("Invalid Selection");
        return;
      }
      System.Console.WriteLine("How many " + selectedTaco.Protein + " do you want to stock today?");
      string input = Console.ReadLine();
      int quantity;
      bool valid = Int32.TryParse(input, out quantity);
      if (!valid)
      {
        System.Console.WriteLine("Enter a number please");
        return;
      }
      selectedTaco.InStock += quantity;
      System.Console.WriteLine("Thank you for stocking " + quantity + " tacos");
      return;
    }

    public void OrderTaco()
    {
      Console.Clear();
      Truck.ViewTacos();
      System.Console.WriteLine("Select a taco to order!");
      string selection = Console.ReadLine();
      Taco selectedTaco = Truck.checkTacoAvailability(selection);
      if (selectedTaco == null)
      {
        System.Console.WriteLine("Invalid Selection");
        return;
      }
      System.Console.WriteLine("How many " + selectedTaco.Protein + " tacos do you want today?");
      string input = Console.ReadLine();
      int quantity;
      bool valid = Int32.TryParse(input, out quantity);
      if (!valid)
      {
        System.Console.WriteLine("Enter a number please");
        return;
      }
      if (selectedTaco.InStock >= quantity)
      {
        selectedTaco.InStock -= quantity;
        System.Console.WriteLine($"Thanks for buying {quantity} tacos");
        return;
      }
      else
      {
        System.Console.WriteLine($"We do not have enough {quantity} {selectedTaco.Protein} in stock!");
        return;
      }
    }
  }
}