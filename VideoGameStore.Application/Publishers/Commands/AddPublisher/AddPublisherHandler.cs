using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Persistance;

namespace VideoGameStore.Application.Publishers.Commands.AddPublisher
{
    public class AddPublisherHandler : IRequestHandler<AddPublisherCommand>
    {
        IBaseRepository<Publisher> _repo;
        public AddPublisherHandler(IBaseRepository<Publisher> repo)
        {
            _repo=repo;
        }
        public Task<Unit> Handle(AddPublisherCommand request, CancellationToken cancellationToken)
        {
            _repo.Create(request.Publisher);
            return Task.FromResult(Unit.Value);
        }
    }
}
