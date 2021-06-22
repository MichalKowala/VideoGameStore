using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameStore.Application.VideoGames.Commands.AddVideoGame;
using VideoGameStore.Application.VideoGames.Commands.DeleteVideoGame;
using VideoGameStore.Application.VideoGames.Commands.UpdateVideoGame;
using VideoGameStore.Application.VideoGames.Queries.GetAllVideoGames;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoGamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<VideoGame>> Get()
        {

            List<VideoGame> games = await _mediator.Send(new GetAllVideoGamesQuery());
            return games;
        }
        [HttpPost]
        public async Task Create(VideoGame game)
        {
            await _mediator.Send(new AddVideoGameCommand(game));
        }
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _mediator.Send(new DeleteVideoGameCommand(id));
        }
        [HttpPut]
        public async Task Update(VideoGame game)
        {
            await _mediator.Send(new UpdateVideoGameCommand(game));
        }
    }
}
