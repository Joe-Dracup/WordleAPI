using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WordleAPI.Models.Query;

namespace WordleAPI.Controllers
{
    [ApiController]
    public class WordleController : Controller
    {

        private readonly IMediator _mediator;
        private readonly ILogger<WordleController> _logger;


        public WordleController(IMediator mediator, ILogger<WordleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("[controller]/getresults")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> GetTopResults(WordleQuery query)
        {
            var result = await _mediator.Send(query);

            if (!result.Result)
            {
                _logger.LogError(result.ErrorMessage, query);
                return NotFound();
            }

            return Ok(result);
        }
    }
}
