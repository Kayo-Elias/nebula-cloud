using Microsoft.AspNetCore.Mvc;
using NebulaCloud.Data;
using NebulaCloud.Models;
using NebulaCloud.Services;

namespace NebulaCloud.Controllers;

[ApiController]
[Route("api/v1/nodes")]
public class NodeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(
        [FromServices] NebulaCloudDbContext context)
     => Ok(context.Nodes.ToList());

    [HttpGet("{id:int}")]
    public IActionResult GetById(
        [FromRoute] int id,
        [FromServices] NebulaCloudDbContext context)
    {
        var node = context.Nodes.FirstOrDefault(x => x.Id == id);
        if (node == null)
            return NotFound();

        return Ok(node);
    }

    [HttpPost]
    public IActionResult Post(
        [FromBody] Node node,
        [FromServices] NebulaCloudDbContext context
    )
    {
        if (new NodeNameValidator().IsValid(node, context))
        {
            context.Nodes.Add(node);
            context.SaveChanges();

            return Created($"/{node.Id}", node);
        }
        return Created($"/{node.Id}", node);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody] Node node,
        [FromServices] NebulaCloudDbContext context)
    {

        var existingNode = context.Nodes.FirstOrDefault(x => x.Id == id);

        if (existingNode == null)
            return NotFound();

        existingNode.Name = node.Name;
        existingNode.Status = node.Status;
        context.SaveChanges();
        return Ok(existingNode);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(
        [FromRoute] int id,
        [FromServices] NebulaCloudDbContext context)
    {
        var node = context.Nodes.FirstOrDefault(x => x.Id == id);
        if (node == null)
            return NotFound();

        context.Nodes.Remove(node);
        context.SaveChanges();
        return Ok(node);
    }
}