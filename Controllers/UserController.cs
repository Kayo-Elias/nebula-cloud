using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NebulaCloud.Data;
using NebulaCloud.Models;
using NebulaCloud.Services;

namespace NebulaCloud.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("v1/users")]
    public async Task<IActionResult> Get(
    [FromServices] NebulaCloudDbContext context) => Ok(context.Users.ToList());

    [HttpGet("v1/users/{id:int}")]
    public async Task<IActionResult> GetById(
        [FromRoute] int id,
        [FromServices] NebulaCloudDbContext context)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost("v1/users")]
    public async Task<IActionResult> Post(
        [FromBody] User user,
        [FromServices] NebulaCloudDbContext context
    )
    {
        if(new UserNameValidator().IsValid(user, context) )
        context.Users.Add(user);
        await context.SaveChangesAsync();

        return Created($"/{user.Id}", user);
    }

    [HttpPut("v1/users/{id:int}")]
    public async Task<IActionResult> Put(
        [FromRoute] int id,
        [FromBody] User user,
        [FromServices] NebulaCloudDbContext context)
    {
        var existingUser = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (existingUser == null)
            return NotFound();

        existingUser.Name = user.Name;

        await context.SaveChangesAsync();
        return Ok(existingUser);
    }

     [HttpDelete("v1/users/{id:int}")]
    public async Task<IActionResult> Delete(
        [FromRoute] int id,
        [FromServices] NebulaCloudDbContext context)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        
        if (user == null)
            return NotFound();

        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return Ok(user);
    }
}