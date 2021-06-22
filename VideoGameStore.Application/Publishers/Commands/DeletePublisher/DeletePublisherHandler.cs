using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Persistance;

namespace VideoGameStore.Application.Publishers.Commands.DeletePublisher
{
    public class DeletePublisherHandler : IRequestHandler<DeletePublisherCommand>
    {
        IBaseRepository<Publisher> _repo;
        public DeletePublisherHandler(IBaseRepository<Publisher> repo)
        {
            _repo = repo;
        }
        public Task<Unit> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            _repo.Delete(request.Id);
            return Task.FromResult(Unit.Value);
        }
    }
}
