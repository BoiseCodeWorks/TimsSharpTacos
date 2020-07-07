namespace timstacos.Models
{
  public class Taco
  {
    public Taco(string shell, string protein, int inStock)
    {
      Shell = shell;
      Protein = protein;
      InStock = inStock;
    }

    public string Shell { get; set; }
    public string Protein { get; set; }
    public int InStock { get; set; }
    public bool Available { get { return InStock > 0; } }

    public override string ToString()
    {
      return $"  {Protein} {Shell} {InStock} ";
    }

  }
}