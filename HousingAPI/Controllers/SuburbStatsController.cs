using Microsoft.AspNetCore.Mvc;
using HousingAPI.Services;

namespace HousingAPI.Controllers;

[ApiController]
[Route("suburb")]
public class SuburbController : ControllerBase
{
    private readonly SuburbService _service;

    public SuburbController(SuburbService service)
    {
        _service = service;
    }

    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        var result = _service.GetByName(name);

        if (result == null || result.Count == 0)
            return NotFound(new { message = $"No stats found for suburb: {name}" });

        return Ok(result.First());
    }
}