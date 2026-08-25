namespace Node;

public class NodeNameValidator
{
    public bool IsValid(Node node)
    {
        if(node == null || string.IsNullOrWhiteSpace(node.Name))
        {
            return false;
        }
            return true;
    }
}