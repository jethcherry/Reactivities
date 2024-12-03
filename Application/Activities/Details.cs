using Domain;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities
                    .AsNoTracking()  // Ensures no change tracking, as we only want to fetch data
                    .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

                if (activity == null)
                {
                    // Optionally log the missing activity
                    throw new KeyNotFoundException($"Activity with Id {request.Id} not found.");
                }

                return activity;
            }
        }
    }
}
