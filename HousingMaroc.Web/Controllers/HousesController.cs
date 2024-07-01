using HousingMaroc.Application.Housing.Commands;
using HousingMaroc.Application.Housing.Queries;
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
    
    [HttpPost("add-house-offer")]
    public async Task<IActionResult> AddHouseOffer([FromBody] AddHouseCommand command)
    {
        await _mediator.Send(command);
        
        return Ok();
    }
}
