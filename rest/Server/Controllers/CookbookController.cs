using Labdays.DigitalCookbook.Rest.Shared;
using Microsoft.AspNetCore.Mvc;
using rest.Server.ModelFactoryMethods;
using rest.Client.Models;
using rest.Shared;

namespace rest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookbookController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<CookbookController> _logger;

        public CookbookController(ILogger<CookbookController> logger, IWebHostEnvironment env, IRecipeRepository recipeRepository)
        {
            _logger = logger;
            _env = env;
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

        [HttpPost("scan")]
        public async Task<IActionResult> UploadScan([FromForm] IEnumerable<IFormFile> files)
        {
            var path = Path.Combine("C:\\Temp", "dummyFileName.jpg");

            try
            {
                await using FileStream fs = new(path, FileMode.Create);
                await (files.Single()).CopyToAsync(fs);
            }
            catch(Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }

            throw new NotImplementedException();
        }
    }
}