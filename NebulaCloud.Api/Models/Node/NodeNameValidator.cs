using System.Text.RegularExpressions;

namespace Node;

public class NodeNameValidator
{
    public bool IsValid(Node node)
    {
        if (node == null || string.IsNullOrWhiteSpace(node.Name))
        {
            return false;
        }
        return true;
    }

    public bool HasMaximumLength(Node node)
    {
        return node.Name.Length <= 15;
    }

    public bool HasValidCharacters(Node node)
    {
        return Regex.IsMatch(node.Name, @"^[a-zA-Z0-9_-]+$");
    }
}