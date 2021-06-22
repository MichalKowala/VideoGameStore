using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Persistance;

namespace VideoGameStore.Application.VideoGames.Commands.AddVideoGame
{
    public class AddVideoGameHandler : IRequestHandler<AddVideoGameCommand>
    {
        IBaseRepository<VideoGame> _repository;
        public AddVideoGameHandler(IBaseRepository<VideoGame> repository)
        {
            _repository = repository;
        }
        public Task<Unit> Handle(AddVideoGameCommand request, CancellationToken cancellationToken)
        {
           
            _repository.Create(request.VideoGame);
            return Task.FromResult(Unit.Value); 
        }
    }
}
