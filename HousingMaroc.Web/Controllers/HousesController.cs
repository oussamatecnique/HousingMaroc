using HousingMaroc.Application.House.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HousingMaroc.Controllers;

[ApiController]
[Route("[controller]")]
public class HousesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetHouse([FromRoute] int id)
    {
        var house = await _mediator.Send(new GetHouseQuery { Id = id });
        
        return Ok(house);
    }
}
