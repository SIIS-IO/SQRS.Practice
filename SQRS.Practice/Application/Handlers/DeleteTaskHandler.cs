using MediatR;
using Microsoft.EntityFrameworkCore;
using SQRS.Practice.Application.Dtos;
using SQRS.Practice.Infrastructure;
using SQRS.Practice.Infrastructure.Commands;

namespace SQRS.Practice.Application.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ApplicationDbContext _dbcontext;
        public DeleteTaskHandler(ApplicationDbContext? dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbcontext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);
            if (taskItem != null) return false;

            _dbcontext.TaskItems.Remove(taskItem);
            await _dbcontext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
