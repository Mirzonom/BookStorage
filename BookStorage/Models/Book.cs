namespace BookStorage.Models;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public int Page { get; set; }
    public double Price { get; set; }
}