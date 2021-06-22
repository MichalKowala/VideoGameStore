using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.VideoGames.Queries.GetAllVideoGames
{
    public class GetAllVideoGamesQuery : IRequest<List<VideoGame>>
    {

    }
}
