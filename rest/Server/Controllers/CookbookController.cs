using Labdays.DigitalCookbook.Rest.Shared;
using Microsoft.AspNetCore.Mvc;
using rest.Client.Models;
using rest.Server.ModelFactoryMethods;
using rest.Server.Models;
using rest.Shared;

namespace rest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookbookController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        private readonly ILogger<CookbookController> _logger;

        public CookbookController(ILogger<CookbookController> logger, IRecipeRepository recipeRepository)
        {
            _logger = logger;
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Recipe>> Get()
        {
            return await _recipeRepository.GetAllRecipesAsync();
        }

        [HttpGet("{recipeId}")]
        public async Task<Recipe> GetById([FromRoute]Guid recipeId)
        {
            return await _recipeRepository.GetByIdAsync(recipeId);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RecipeModel recipe)
        {
            var stored = await _recipeRepository.CreateAsync(recipe.ToRecipe());
            return CreatedAtAction(nameof(Get), stored);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RecipeModel recipe)
        {
            var stored = await _recipeRepository.UpdateAsync(recipe.ToRecipe());
            return AcceptedAtAction(nameof(Put), stored);
        }

        [HttpPost("manualcorrection")]
        public async Task<IActionResult> ManualCorrectionAsync([FromBody] ManualCorrectionModel manualCorrection)
        {
            var stored = await _recipeRepository.CreateAsync(Recipe.CreateNew(manualCorrection.Title, manualCorrection.Instruction, Enumerable.Empty<Ingredient>()));
            return CreatedAtAction(nameof(ManualCorrectionAsync), stored.Id);
        }
    }
}