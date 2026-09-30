namespace IncomeManager.Domain.Entities;

public class Income
{
    public Guid Id { get; set; }
    public string Source { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public DateTime ReceivedDate { get; set; }
    public string Category { get; set; } = string.Empty;
    public string ReceiveMethod { get; set; } = string.Empty;
    public DateTime RegisteredAt { get; set; }
}
