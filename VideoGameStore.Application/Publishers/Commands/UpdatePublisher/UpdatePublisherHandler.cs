using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Persistance;

namespace VideoGameStore.Application.Publishers.Commands.UpdatePublisher
{
    public class UpdatePublisherHandler : IRequestHandler<UpdatePublisherCommand>
    {
        IBaseRepository<Publisher> _repo;
        public UpdatePublisherHandler(IBaseRepository<Publisher> repo)
        {
            _repo = repo;
        }
        public Task<Unit> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
        {
            _repo.Update(request.Publisher);
            return Task.FromResult(Unit.Value);
        }
    }
}
