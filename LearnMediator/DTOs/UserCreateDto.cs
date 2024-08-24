namespace LearnMediator.DTOs;

/// <summary>
/// Exposes what is needed to create a user
/// </summary>
/// <param name="Name"></param>
/// <param name="Email"></param>
public record UserCreateDto(string Name, string Email);