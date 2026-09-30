using IncomeManager.Application.DTOs;
using IncomeManager.Domain.Entities;

namespace IncomeManager.Application.Services;

public interface IIncomeService
{
    Income Create(CreateIncomeDto dto);

    List<Income> GetAll(
        string? category,
        string? receiveMethod,
        DateTime? startDate,
        DateTime? endDate,
        decimal? minValue);

    Income? GetById(Guid id);

    bool Delete(Guid id);
}
