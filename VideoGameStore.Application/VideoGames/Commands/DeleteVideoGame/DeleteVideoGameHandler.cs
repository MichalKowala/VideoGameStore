using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Persistance;

namespace VideoGameStore.Application.VideoGames.Commands.DeleteVideoGame
{
    public class DeleteVideoGameHandler : IRequestHandler<DeleteVideoGameCommand>
    {
        IBaseRepository<VideoGame> _repository;
        public DeleteVideoGameHandler(IBaseRepository<VideoGame> repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(DeleteVideoGameCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            return Task.FromResult(Unit.Value);
        }
    }
}
