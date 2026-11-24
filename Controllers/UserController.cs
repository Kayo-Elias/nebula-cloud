using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NebulaCloud.Data;
using NebulaCloud.Models;
using NebulaCloud.Services;
using NebulaCloud.ViewModels;

namespace NebulaCloud.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("v1/users")]
    public async Task<IActionResult> GetAsync(
    [FromServices] NebulaCloudDbContext context) => Ok( await context.Users.ToListAsync());

    [HttpGet("v1/users/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id,
        [FromServices] NebulaCloudDbContext context)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Não foi possivel listar os usuarios.");
        }
    }

    [HttpPost("v1/users")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditUserViewModel model,
        [FromServices] NebulaCloudDbContext context
    )
    {
        try
        {
            var user = new User()
            {
                Id = 0,
                Name = model.Name,
                ERole = Models.User.EUserRole.Member
            };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return Created($"/{user.Id}", user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Não foi possivel criar um usuario.");
        }
    }

    [HttpPut("v1/users/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int id,
        [FromBody] EditUserViewModel user,
        [FromServices] NebulaCloudDbContext context)
    {
        try
        {
        var existingUser = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (existingUser == null)
            return NotFound();

        existingUser.Id = user.Id;
        existingUser.Name = user.Name;

        await context.SaveChangesAsync();
        return Ok(existingUser);
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Não foi possivel atualizar o usuario");
        }
    }

    [HttpDelete("v1/users/{id:int}")]
    public async Task<IActionResult> DeleteAsync(
       [FromRoute] int id,
       [FromServices] NebulaCloudDbContext context)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return NotFound();

            if (user.ERole == Models.User.EUserRole.Premium)
                return Conflict("Não é possivel excluir um usuario premium.");

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Não foi possivel excluir o usuario");
        }
    }
}