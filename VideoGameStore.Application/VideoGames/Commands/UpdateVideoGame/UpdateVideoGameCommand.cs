using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.VideoGames.Commands.UpdateVideoGame
{
    public class UpdateVideoGameCommand : IRequest
    {
        public VideoGame VideoGame { get; set; }
        public UpdateVideoGameCommand(VideoGame videoGame)
        {
            VideoGame = videoGame;
        }
    }
}
