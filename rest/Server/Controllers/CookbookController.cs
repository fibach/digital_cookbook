using Labdays.DigitalCookbook.Rest.Shared;
using Microsoft.AspNetCore.Mvc;
using rest.Shared;

namespace rest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookbookController : ControllerBase
    {
        private readonly ILogger<CookbookController> _logger;

        public CookbookController(ILogger<CookbookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Recipe
            {
                Id = Guid.NewGuid(),
                Title = $"recipe title {index}",
                Instruction = "Instruction {index}"
            })
            .ToArray();
        }
    }
}