namespace Node.Tests;

public class NodeNameValidatorTests
{
    [Fact]
    public void Should_Return_True_When_Name_Is_Valid()
    {
        var node = new Node
        {
            Name = "Server01"
        };

        var validator = new NodeNameValidator();

        var result = validator.IsValid(node);

        Assert.True(result);
    }
}