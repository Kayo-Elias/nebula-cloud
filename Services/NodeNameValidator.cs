using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using NebulaCloud.Models;

namespace NebulaCloud.Services;

public class NodeNameValidator
{
    public bool IsValid(Node node, DbContext context)
    {
        IsNullOrEmpty(node);
        IsMinimum(node);
        IsMax(node);
        HasValidFormat(node);
        IsUnique(node, context);

        return true;
    }

    public bool IsNullOrEmpty(Node node)
    {
        if (string.IsNullOrWhiteSpace(node.Name))
            throw new ArgumentException("The node name is required.", nameof(node));

        return true;
    }

    public bool IsMax(Node node)
    {
        if (node.Name.Length > 25)
            throw new ArgumentException("The name cannot be longer than 25 characters.", nameof(node));

        return true;
    }

    public bool IsMinimum(Node node)
    {
        if (node.Name.Length < 5)
            throw new ArgumentException("The name cannot be shorter than 5 characters.", nameof(node));

        return true;
    }

    public bool HasValidFormat(Node node)
    {
        if (!Regex.IsMatch(node.Name, @"^(?=.{5,25}$)[A-Za-z0-9]+(?:-[A-Za-z0-9]+)*$"))
            throw new ArgumentException("The name can only contain letters and numbers separated by '-', without spaces or special characters.", nameof(node));

        return true;
    }

    public bool IsUnique(Node node, DbContext context)
    {
        var exists = context.Set<Node>().Any(x => x.Name == node.Name && x.Id != node.Id);

        if (exists)
            throw new InvalidOperationException("The name has to be unique.");

        return true;
    }
}