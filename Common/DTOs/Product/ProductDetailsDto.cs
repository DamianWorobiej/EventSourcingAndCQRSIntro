namespace Common.DTOs.Product;

public class ProductDetailsDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Quantity { get; set; }
}
