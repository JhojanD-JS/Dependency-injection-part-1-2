using IncomeManager.Application.DTOs;
using IncomeManager.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncomeManager.API.Controllers;

[Route("api/incomes")]
[ApiController]
public class IncomesController : ControllerBase
{
  
    private readonly IIncomeService _incomeService;


    public IncomesController(IIncomeService incomeService)
    {
        _incomeService = incomeService;
    }

    [HttpPost]
    public IActionResult CreateIncome([FromBody] CreateIncomeDto dto)
    {
        var income = _incomeService.Create(dto);
        return CreatedAtAction(nameof(GetIncomeById), new { id = income.Id }, income);
    }

    [HttpGet]
    public IActionResult GetIncomes(
        [FromQuery] string? category,
        [FromQuery] string? receiveMethod,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate,
        [FromQuery] decimal? minValue)
    {
        var incomes = _incomeService.GetAll(category, receiveMethod, startDate, endDate, minValue);
        return Ok(incomes);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetIncomeById(Guid id)
    {
        var income = _incomeService.GetById(id);

        if (income is null)
            return NotFound(new { message = "Income not found" });

        return Ok(income);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteIncome(Guid id)
    {
        var deleted = _incomeService.Delete(id);

        if (!deleted)
            return NotFound(new { message = "Income not found" });

        return NoContent();
    }
}