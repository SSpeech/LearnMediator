using LearnMediator.DTOs;
using LearnMediator.Features.User.Commands;
using LearnMediator.Models;

namespace LearnMediator.Extensions;

public static class UserExtensions
{
    public static UserCreateCommand Map(this UserCreateDto value) =>
        new(value.Name, value.Email);

    public static UserDto Map(this User value) =>
        new(value.Id, value.Name, value.Email);

    public static User Map(this UserCreateCommand value) =>
        new(value.Name, value.Email);
}