using Microsoft.AspNetCore.Mvc;
using HousingAPI.Services;

namespace HousingAPI.Controllers;

[ApiController]
[Route("trend")]
public class SuburbTrendController : ControllerBase
{
    private readonly SuburbTrendService _service;

    public SuburbTrendController(SuburbTrendService service)
    {
        _service = service;
    }

    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        var result = _service.GetByName(name);

        if (result == null || result.Count == 0)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("{name}/{year}")]
    public IActionResult Get(string name, int year)
    {
        var result = _service.GetByNameAndYear(name, year);

        if (result == null || result.Count == 0)
            return NotFound(new { message = $"No trends found for suburb: {name} in year: {year}" });

        return Ok(result.First());
    }
}