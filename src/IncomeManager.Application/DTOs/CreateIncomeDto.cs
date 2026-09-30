using System.ComponentModel.DataAnnotations;

namespace IncomeManager.Application.DTOs;

public class CreateIncomeDto
{
    [Required(ErrorMessage = "Source is required")]
    [StringLength(200, MinimumLength = 3)]
    public string Source { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Value must be greater than 0")]
    public decimal Value { get; set; }

    [Required]
    public DateTime ReceivedDate { get; set; }

    [Required(ErrorMessage = "Category is required")]
    public string Category { get; set; } = string.Empty;

    [Required(ErrorMessage = "Receive method is required")]
    public string ReceiveMethod { get; set; } = string.Empty;
}
