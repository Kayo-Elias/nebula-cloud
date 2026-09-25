using Microsoft.AspNetCore.Mvc;
using NebulaCloud.Data;
using NebulaCloud.Models;

namespace NebulaCloud.Controllers;

[ApiController]
public class NodeController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Get([FromServices] AppDbContext context)
     => Ok(context.Nodes.ToList());

    [HttpGet("/{id:int}")]
    public IActionResult GetById(
        [FromRoute] int id,
        [FromServices] AppDbContext context)
    {
        var node = context.Nodes.FirstOrDefault(x => x.Id == id);
        if (node == null)
            return NotFound();

        return Ok(node);
    }

    [HttpPost("/")]
    public IActionResult Post(
        [FromBody] Node node,
        [FromServices] AppDbContext context
    )
    {
        context.Nodes.Add(node);
        context.SaveChanges();

        return Created($"/{node.Id}", node);
    }

    [HttpPut("/{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody] Node node,
        [FromServices] AppDbContext context)
    {
        var Node = context.Nodes.FirstOrDefault(x => x.Id == id);

        if (node == null)
        {
            return NotFound();
        }

        node.Name = node.Name;
        node.Status = node.Status;

        context.Nodes.Update(node);
        context.SaveChanges();
        return Ok(node);
    }

    [HttpDelete("/{id:int}")]
    public IActionResult Delete(
        [FromRoute] int id,
        [FromServices] AppDbContext context)
    {
        var node = context.Nodes.FirstOrDefault(x => x.Id == id);
        if (node == null)
            return NotFound();

        context.Nodes.Update(node);
        context.SaveChanges();
        return Ok(node);
    }
}