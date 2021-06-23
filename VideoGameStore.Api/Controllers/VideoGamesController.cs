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
        public async Task<IActionResult> Get()
        {

            List<VideoGame> games = await _mediator.Send(new GetAllVideoGamesQuery());
            return Ok(games);
        }
        [HttpPost]
        public async Task<IActionResult> Create(VideoGame game)
        {
            var queryResult = await _mediator.Send(new AddVideoGameCommand(game));
            return Ok(queryResult);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var queryResult = await _mediator.Send(new DeleteVideoGameCommand(id));
            return Ok(queryResult);
        }
        [HttpPut]
        public async Task<IActionResult> Update(VideoGame game)
        {
            var queryResult=await _mediator.Send(new UpdateVideoGameCommand(game));
            return Ok(queryResult);
        }
    }
}
