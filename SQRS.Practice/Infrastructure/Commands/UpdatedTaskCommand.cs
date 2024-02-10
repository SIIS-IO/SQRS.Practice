using MediatR;
using SQRS.Practice.Application.Dtos;

namespace SQRS.Practice.Infrastructure.Commands
{
    public record UpdatedTaskCommand(int Id, string Title, string Description, bool IsCompleted) : IRequest<TaskItemDto>;
}
