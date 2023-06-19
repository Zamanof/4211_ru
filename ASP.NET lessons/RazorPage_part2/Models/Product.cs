namespace RazorPage_part2.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public uint Count { get; set; }
    public decimal Price { get; set; }
    public bool Available { get; set; }
}
