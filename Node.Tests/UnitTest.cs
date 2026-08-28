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

     [Fact]
    public void Should_Return_True_When_Node_Starts_With_Letter()
    {
        var node = new Node
        {
            Name = "Server01"
        };

        var validator = new NodeNameValidator();

        var result = validator.StartWithLetter(node);

        Assert.True(result);
    }

    [Fact]
    public void Should_Return_HasMaximumLength()
    {
        var node = new Node
        {
            Name = "Server01"   
        };

        var validator = new NodeNameValidator();

        var result = validator.HasMaximumLength(node);

        Assert.True(result);
    }

    [Fact]
    public void Should_Return_HasMinimumLength()
    {
        var node = new Node
        {
            Name = "Server01"   
        };

        var validator = new NodeNameValidator();

        var result = validator.HasMinimumLength(node);

        Assert.True(result);
    }

    [Fact]
    public void Should_Return_False_When_Name_Exceeds_MaximumLength()
    {
        var node = new Node
        {
            Name = "Server1234567890"
        };

        var validator = new NodeNameValidator();

        var result = validator.IsValid(node);

        Assert.False(result);
    }

    [Fact]
    public void Should_Return_False_When_Name_Contains_Invalid_Characters()
    {
        var node = new Node
        {
            Name = "Server 01"
        };

        var validator = new NodeNameValidator();

        var result = validator.IsValid(node);

        Assert.False(result);
    }

    [Fact]
    public void Should_Return_False_When_Name_Starts_With_Number()
    {
        var node = new Node
        {
            Name = "01Server"
        };

        var validator = new NodeNameValidator();

        var result = validator.IsValid(node);

        Assert.False(result);
    }

    [Fact]
    public void Should_Return_False_When_Name_Is_Empty()
    {
        var node = new Node
        {
            Name = string.Empty
        };

        var validator = new NodeNameValidator();

        var result = validator.IsValid(node);

        Assert.False(result);
    }

    [Fact]
    public void Should_Return_False_When_Name_Is_Null()
    {
        var node = new Node
        {
            Name = null
        };

        var validator = new NodeNameValidator();

        var result = validator.IsValid(node);

        Assert.False(result);
    }

    [Fact]
    public void Should_Return_False_When_Name_Ends_With_Invalid_Character()
    {
        var node = new Node
        {
            Name = "Server_"
        };

        var validator = new NodeNameValidator();

        var result = validator.EndWithLetterOrNumber(node);

        Assert.False(result);
    }

    [Fact]
    public void Should_Return_False_When_Valid_Name_Ends_With_Invalid_Character()
    {
        var node = new Node
        {
            Name = "Server_"
        };

        var validator = new NodeNameValidator();

        var result = validator.IsValid(node);

        Assert.False(result);
    }
}