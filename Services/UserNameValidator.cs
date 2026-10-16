using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using NebulaCloud.Models;

namespace NebulaCloud.Services;

public class UserNameValidator
{
    public bool IsValid(User user, DbContext context)
    {
        IsNullOrEmpty(user);
        IsMinimum(user);
        IsMax(user);
        HasValidFormat(user);
        IsUnique(user, context);

        return true;
    }

    public bool IsNullOrEmpty(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name))
            throw new ArgumentException("The user name is required.", nameof(user));

        return true;
    }

    public bool IsMax(User user)
    {
        if (user.Name.Length > 25)
            throw new ArgumentException("The name cannot be longer than 25 characters.", nameof(user));

        return true;
    }

    public bool IsMinimum(User user)
    {
        if (user.Name.Length < 5)
            throw new ArgumentException("The name cannot be shorter than 5 characters.", nameof(user));

        return true;
    }

    public bool HasValidFormat(User user)
    {
        if (!Regex.IsMatch(user.Name, @"^(?=.{5,25}$)[A-Za-z0-9]+(?:-[A-Za-z0-9]+)*$"))
            throw new ArgumentException("The name can only contain letters and numbers separated by '-', without spaces or special characters.", nameof(user));

        return true;
    }

    public bool IsUnique(User user, DbContext context)
    {
        var exists = context.Set<User>().Any(x => x.Name == user.Name && x.Id != user.Id);

        if (exists)
            throw new InvalidOperationException("The name has to be unique.");

        return true;
    }
}