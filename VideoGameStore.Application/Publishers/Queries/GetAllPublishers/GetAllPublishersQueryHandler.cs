using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Persistance;

namespace VideoGameStore.Application.Publishers.Queries.GetAllPublishers
{
    public class GetAllPublishersQueryHandler : IRequestHandler<GetAllPublishersQuery, List<Publisher>>
    {
        IBaseRepository<Publisher> _repo;
        public GetAllPublishersQueryHandler(IBaseRepository<Publisher> repo)
        {
            _repo = repo;
        }
        public async Task<List<Publisher>> Handle(GetAllPublishersQuery request, CancellationToken cancellationToken)
        {
            List<Publisher> publishers = _repo.GetAll().ToList();
            return publishers;
        }
    }
}
