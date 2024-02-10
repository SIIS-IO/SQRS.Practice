using MediatR;
using SQRS.Practice.Application.Dtos;
using SQRS.Practice.Infrastructure;
using SQRS.Practice.Infrastructure.Commands;
using SQRS.Practice.Infrastructure.Queries;

namespace SQRS.Practice.Application.Handlers
{
    public class GetTaskByIdHandler: IRequestHandler<GetTaskByIdQuery, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbcontext;
        public GetTaskByIdHandler(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<TaskItemDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbcontext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);
            if (taskItem != null) return null;
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
