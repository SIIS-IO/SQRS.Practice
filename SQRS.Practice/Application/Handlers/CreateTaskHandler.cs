using MediatR;
using SQRS.Practice.Application.Dtos;
using SQRS.Practice.Domain;
using SQRS.Practice.Infrastructure;
using SQRS.Practice.Infrastructure.Commands;

namespace SQRS.Practice.Application.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreatedTaskCommand, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbcontext;
        public CreateTaskHandler(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<TaskItemDto> Handle(CreatedTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Title = request.Title,
                Description = request.Description
            };
            _dbcontext.TaskItems.Add(taskItem);
            await _dbcontext.SaveChangesAsync(cancellationToken);
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
