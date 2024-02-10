using MediatR;
using SQRS.Practice.Application.Dtos;

namespace SQRS.Practice.Infrastructure.Queries
{
    public record GetAllTaskQuery: IRequest<IEnumerable<TaskItemDto>>;
}
