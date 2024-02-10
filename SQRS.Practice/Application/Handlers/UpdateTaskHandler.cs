using MediatR;
using Microsoft.EntityFrameworkCore;
using SQRS.Practice.Application.Dtos;
using SQRS.Practice.Infrastructure;
using SQRS.Practice.Infrastructure.Commands;

namespace SQRS.Practice.Application.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdatedTaskCommand, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbcontext;

        public UpdateTaskHandler(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<TaskItemDto> Handle(UpdatedTaskCommand request, CancellationToken cancellationToken)
        {

            var taskItem = await _dbcontext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);
            if (taskItem != null) return null;

            taskItem.Title = request.Title;
            taskItem.Description = request.Description;
            taskItem.IsCompleted = request.IsCompleted;

            await _dbcontext.SaveChangesAsync();

            return new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted
            };
        }
    }
}
