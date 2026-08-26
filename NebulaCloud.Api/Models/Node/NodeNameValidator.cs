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

        return HasMaximumLength(node)
            && HasValidCharacters(node)
            && StartWithLetter(node);
    }

    public bool HasMinimumLength(Node node)
    {
        return node.Name.Length >= 3;
    }

    public bool HasMaximumLength(Node node)
    {
        return node.Name.Length <= 15;
    }

    public bool HasValidCharacters(Node node)
    {
        return Regex.IsMatch(node.Name, @"^[a-zA-Z0-9_-]+$");
    }

    public bool StartWithLetter(Node node)
    {
        return Regex.IsMatch(node.Name, @"^[a-zA-Z]");
    }

    public bool EndWithLetterOrNumber(Node node)
    {
        return Regex.IsMatch(node.Name, @"[a-zA-Z0-9]$");
    }
}