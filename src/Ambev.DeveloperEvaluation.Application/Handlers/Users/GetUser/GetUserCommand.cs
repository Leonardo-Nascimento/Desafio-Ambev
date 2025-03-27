using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Users.GetUser;

/// <summary>
/// Command for retrieving a user by their ID
/// </summary>
public record GetUserCommand : IRequest<GetUserResult>
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Initializes a new instance of GetUserCommand
    /// </summary>
    /// <param name="id">The ID of the user to retrieve</param>
    public GetUserCommand(long id)
    {
        Id = id;
    }
}
