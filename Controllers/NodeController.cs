using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NebulaCloud.Data;
using NebulaCloud.Models;
using NebulaCloud.ViewModels;

namespace NebulaCloud.Controllers;

[ApiController]
public class NodeController : ControllerBase
{
    [HttpGet("v1/nodes")]
    public async Task<IActionResult> GetAsync(
        [FromServices] NebulaCloudDbContext context) => Ok(await context.Nodes.ToListAsync());

    [HttpGet("v1/nodes/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id,
        [FromServices] NebulaCloudDbContext context)
    {
        try
        {
        var node = await context.Nodes.FirstOrDefaultAsync(x => x.Id == id);

        if (node == null)
            return NotFound();

        return Ok(node);
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Não foi possivel listar os servidores.");
        }
    }

    [HttpPost("v1/nodes")]
    public async Task<IActionResult> PostAsync(
        [FromBody] CreateNodeViewModel model,
        [FromServices] NebulaCloudDbContext context
    )
    {
        try
        {
            var node = new Node()
            {
                Id = 0,
                UserId = model.UserId,
                Ip = model.Ip,
                Name = model.Name,
                Status = ENodeStatus.Offline,
                CreatedAt = DateTime.UtcNow
            };
            context.Nodes.Add(node);
            await context.SaveChangesAsync();

            return Created($"v1/nodes/{node.Id}", node);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Não foi possivel criar um servidor.");
        }
    }

    [HttpPut("v1/nodes/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int id,
        [FromBody] Node node,
        [FromServices] NebulaCloudDbContext context)
    {
        try
        {
        var existingNode = await context.Nodes.FirstOrDefaultAsync(x => x.Id == id);

        if (existingNode == null)
            return NotFound();

        existingNode.Id = node.Id;
        existingNode.Name = node.Name;
        existingNode.Status = node.Status;

        await context.SaveChangesAsync();
        return Ok(existingNode);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Não foi possivel editar o servidor.");
        }
    }

    [HttpDelete("v1/nodes/{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id,
        [FromServices] NebulaCloudDbContext context)
    {
        try
        {
            var node = await context.Nodes.FirstOrDefaultAsync(x => x.Id == id);

            if (node == null)
                return NotFound();

            if (node.Status == ENodeStatus.Online)
                return Conflict("Não é possivel excluir um servidor ativo.");

            context.Nodes.Remove(node);
            await context.SaveChangesAsync();
            return Ok(node);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Não foi possivel excluir o node");
        }
    }
}