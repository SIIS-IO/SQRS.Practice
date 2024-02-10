using MediatR;
using Microsoft.EntityFrameworkCore;
using SQRS.Practice.Application.Dtos;
using SQRS.Practice.Infrastructure;
using SQRS.Practice.Infrastructure.Queries;

namespace SQRS.Practice.Application.Handlers
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTaskQuery, IEnumerable<TaskItemDto>>
    {
        private readonly ApplicationDbContext _dbcontext;
        public GetAllTaskHandler(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<TaskItemDto>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            var listTask = await _dbcontext.TaskItems.ToListAsync(cancellationToken);
            return listTask.Select(task => new TaskItemDto
            {
                Id = task.Id,
                Description = task.Description,
                Title = task.Title,
                IsCompleted = task.IsCompleted,
            });
        }
    }
}
