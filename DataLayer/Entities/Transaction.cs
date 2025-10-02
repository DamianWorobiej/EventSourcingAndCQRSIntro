namespace DataLayer.Entities;

public class Transaction
{
    public int Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime OcurredAt { get; set; }
}
