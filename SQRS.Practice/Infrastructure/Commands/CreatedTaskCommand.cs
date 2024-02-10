using MediatR;
using SQRS.Practice.Application.Dtos;

namespace SQRS.Practice.Infrastructure.Commands
{
    public record CreatedTaskCommand(string Title, string Description) : IRequest<TaskItemDto>;
}
