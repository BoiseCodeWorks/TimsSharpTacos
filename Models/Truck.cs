using System;
using System.Collections.Generic;

namespace timstacos.Models
{
  public class Truck
  {

    //NOTE classes default to internal if not specified
    //NOTE properties default to private if not specified


    //field
    string _Name;
    //prop
    public string Name { get { return _Name; } set { _Name = value; } }

    //autoprops
    public string Location { get; set; }

    public List<Taco> Tacos { get; set; } = new List<Taco>();



    public void ViewTacos()
    {
      Console.WriteLine("Tacos Currently In Stock : \n");
      for (int i = 0; i < Tacos.Count; i++)
      {
        Taco taco = Tacos[i];
        if (taco.Available)
        {
          System.Console.WriteLine($"{i + 1}. {taco}");
          // Console.WriteLine(taco.ToString());

        }
      }
    }
    public void ViewTacos(bool available)
    {
      System.Console.WriteLine("Taco Stock:");
      ConsoleColor forecolor = Console.ForegroundColor;
      for (int i = 0; i < Tacos.Count; i++)
      {
        Taco taco = Tacos[i];
        if (taco.Available == available)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          System.Console.WriteLine($"{i + 1}. {taco.Protein} on {taco.Shell} x {taco.InStock} ");
        }
        else
        {
          Console.ForegroundColor = forecolor;
          System.Console.WriteLine($"{i + 1}. {taco.Protein} on {taco.Shell} x {taco.InStock} ");
        }
      }
      Console.ForegroundColor = forecolor;
    }



    public Truck(string location, string name)
    {
      Location = location;
      Name = name;
      // Tacos = new List<Taco>();
      Tacos.Add(new Taco("Corn", "Call it 'pork'", 100));
      Tacos.Add(new Taco("Flour", "Chicken", 10));
      Tacos.Add(new Taco("Corn", "Octopus", 8));
    }
    public Truck()
    {
      Location = "default";
      Name = "default";
    }

    internal Taco checkTacoAvailability(string selection)
    {
      int tacoIndex;
      bool valid = Int32.TryParse(selection, out tacoIndex);
      if (!valid || tacoIndex < 1 || tacoIndex > Tacos.Count)
      {
        return null;
      }
      return Tacos[tacoIndex - 1];
    }
  }
}