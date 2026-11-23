using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NebulaCloud.Data;
using NebulaCloud.Models;
using NebulaCloud.Services;

namespace NebulaCloud.Controllers;

[ApiController]
public class NodeController : ControllerBase
{
    [HttpGet("v1/nodes")]
    public async Task<IActionResult> Get(
        [FromServices] NebulaCloudDbContext context) => Ok(context.Nodes.ToList());

    [HttpGet("v1/nodes/{id:int}")]
    public async Task<IActionResult> GetById(
        [FromRoute] int id,
        [FromServices] NebulaCloudDbContext context)
    {
        var node = await context.Nodes.FirstOrDefaultAsync(x => x.Id == id);

        if (node == null)
            return NotFound();

        return Ok(node);
    }

    [HttpPost("v1/nodes")]
    public async Task<IActionResult> Post(
        [FromBody] Node node,
        [FromServices] NebulaCloudDbContext context
    )
    {
        node.Status = ENodeStatus.Offline;
        node.CreatedAt = DateTime.UtcNow;

        if (new NodeNameValidator().IsValid(node, context))
        {
            context.Nodes.Add(node);
            await context.SaveChangesAsync();

            return Created($"/{node.Id}", node);
        }
        return Created($"/{node.Id}", node);
    }

    [HttpPut("v1/nodes/{id:int}")]
    public async Task<IActionResult> Put(
        [FromRoute] int id,
        [FromBody] Node node,
        [FromServices] NebulaCloudDbContext context)
    {

        var existingNode = await context.Nodes.FirstOrDefaultAsync(x => x.Id == id);

        if (existingNode == null)
            return NotFound();

        existingNode.Name = node.Name;
        existingNode.Status = node.Status;

        await context.SaveChangesAsync();
        return Ok(existingNode);
    }

    [HttpDelete("v1/nodes/{id:int}")]
    public async Task<IActionResult> Delete(
        [FromRoute] int id,
        [FromServices] NebulaCloudDbContext context)
    {
        var node = await context.Nodes.FirstOrDefaultAsync(x => x.Id == id);
        if (node == null)
            return NotFound();

        context.Nodes.Remove(node);
        await context.SaveChangesAsync();
        return Ok(node);
    }
}