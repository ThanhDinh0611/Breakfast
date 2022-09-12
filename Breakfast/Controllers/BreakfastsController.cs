using Breakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;
using Breakfast.Models;

namespace Breakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastsController : ControllerBase 
{
    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = new Breakfast.Models.Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        //TODO: Add to Database

        var response =  new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );
    
        return Ok(response);
    }

    [HttpGet("{id:Guid}")]
    public IActionResult GetBreakfast(Guid id){
        return Ok(id);
    }
    
    [HttpPut("{id:Guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:Guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok(id);
    }
}