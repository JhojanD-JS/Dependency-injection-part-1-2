using IncomeManager.Application.DTOs;
using IncomeManager.Domain.Entities;

namespace IncomeManager.Application.Services;

public class IncomeService : IIncomeService
{
    private readonly List<Income> _incomes = [];

    public Income Create(CreateIncomeDto dto)
    {
        var income = new Income
        {
            Id = Guid.NewGuid(),
            Source = dto.Source,
            Value = dto.Value,
            ReceivedDate = dto.ReceivedDate,
            Category = dto.Category,
            ReceiveMethod = dto.ReceiveMethod,
            RegisteredAt = DateTime.Now
        };

        _incomes.Add(income);
        return income;
    }

    public List<Income> GetAll(
        string? category,
        string? receiveMethod,
        DateTime? startDate,
        DateTime? endDate,
        decimal? minValue)
    {
        IEnumerable<Income> result = _incomes;

        if (!string.IsNullOrWhiteSpace(category))
            result = result.Where(i => i.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(receiveMethod))
            result = result.Where(i => i.ReceiveMethod.Equals(receiveMethod, StringComparison.OrdinalIgnoreCase));

        if (startDate.HasValue)
            result = result.Where(i => i.ReceivedDate >= startDate.Value);

        if (endDate.HasValue)
            result = result.Where(i => i.ReceivedDate <= endDate.Value);

        if (minValue.HasValue)
            result = result.Where(i => i.Value >= minValue.Value);

        return result.OrderByDescending(i => i.ReceivedDate).ToList();
    }

    public Income? GetById(Guid id) => _incomes.FirstOrDefault(i => i.Id == id);

    public bool Delete(Guid id)
    {
        var income = _incomes.FirstOrDefault(i => i.Id == id);

        if (income is null)
            return false;

        _incomes.Remove(income);
        return true;
    }
}