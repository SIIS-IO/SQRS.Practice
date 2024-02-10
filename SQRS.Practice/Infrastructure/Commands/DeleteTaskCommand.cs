using MediatR;
using SQRS.Practice.Application.Dtos;

namespace SQRS.Practice.Infrastructure.Commands
{
    public record DeleteTaskCommand(int Id): IRequest<bool>;
}
