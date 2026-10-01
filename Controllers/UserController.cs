using Microsoft.AspNetCore.Mvc;
using NebulaCloud.Data;
using NebulaCloud.Models;

namespace NebulaCloud.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(
    [FromServices] NebulaCloudDbContext context)
     => Ok(context.Users.ToList());

    [HttpGet("{id:int}")]
    public IActionResult GetById(
        [FromRoute] int id,
        [FromServices] NebulaCloudDbContext context)
    {
        var user = context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Post(
        [FromBody] User user,
        [FromServices] NebulaCloudDbContext context
    )
    {
        context.Users.Add(user);
        context.SaveChanges();

        return Created($"/{user.Id}", user);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody] User user,
        [FromServices] NebulaCloudDbContext context)
    {
        var existingUser = context.Users.FirstOrDefault(x => x.Id == id);

        if (existingUser == null)
            return NotFound();

        existingUser.Name = user.Name;
        context.SaveChanges();
        return Ok(existingUser);
    }

     [HttpDelete("{id:int}")]
    public IActionResult Delete(
        [FromRoute] int id,
        [FromServices] NebulaCloudDbContext context)
    {
        var user = context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
            return NotFound();

        context.Users.Remove(user);
        context.SaveChanges();
        return Ok(user);
    }
}