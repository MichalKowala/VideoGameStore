using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Persistance;

namespace VideoGameStore.Application.VideoGames.Queries.GetAllVideoGames
{
    public class GetAllVideoGamesHandler : IRequestHandler<GetAllVideoGamesQuery, List<VideoGame>>
    {
        IBaseRepository<VideoGame> _repository;
        public GetAllVideoGamesHandler(IBaseRepository<VideoGame> repository)
        {
            _repository = repository;
        }
        public async Task<List<VideoGame>> Handle(GetAllVideoGamesQuery request, CancellationToken cancellationToken)
        {
            List<VideoGame> games = _repository.GetAll().ToList();
            return games;
        }
    }
}
