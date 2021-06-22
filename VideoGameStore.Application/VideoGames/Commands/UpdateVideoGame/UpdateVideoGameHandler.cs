using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Persistance;

namespace VideoGameStore.Application.VideoGames.Commands.UpdateVideoGame
{
    public class UpdateVideoGameHandler : IRequestHandler<UpdateVideoGameCommand>
    {
        IBaseRepository<VideoGame> _repository;
        public UpdateVideoGameHandler(IBaseRepository<VideoGame> repository)
        {
            _repository = repository;
        }
        public Task<Unit> Handle(UpdateVideoGameCommand request, CancellationToken cancellationToken)
        {
            _repository.Update(request.VideoGame);
            return Task.FromResult(Unit.Value);
        }
    }
}
