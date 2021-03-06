using Labdays.DigitalCookbook.Rest.Shared;
using Microsoft.AspNetCore.Mvc;
using rest.Client.Models;
using rest.Server.ModelFactoryMethods;
using rest.Client.Models;
using rest.Shared;
using Adapters.AzureCS;
using AI;
using Adapters.GoogleCV;

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
        public async Task<Recipe> GetById([FromRoute] Guid recipeId)
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

        [HttpDelete("{recipeId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid recipeId)
        {
            await _recipeRepository.DeleteAsync(recipeId);
            return NoContent();
        }

        [HttpPost("scan")]
        public async Task<IActionResult> UploadScan(
            [FromServices] IComputerVisionOcrRepository ocrRepository,
            [FromForm] IEnumerable<IFormFile> files)
        {
            var stream = files.Single().OpenReadStream();
            var ocrOutput = await ocrRepository.OCRFromStreamAsync(stream);
            var response = new Splitter().SplitText(ocrOutput);
            var ingredientsString = string.Join(Environment.NewLine, response.Ingridients);
            var responseModel = new ManualCorrectionModel { Ingredients = ingredientsString, Instruction = response.Instruction };
            // TODO: map to Model for rework UI
            return Ok(responseModel);
        }
        [HttpPost("scan2")]
        public async Task<IActionResult> UploadScanGoole(
            [FromServices] ICloudVisionOcr googleOcr,
            [FromForm] IEnumerable<IFormFile> files)
        {
            var stream = files.Single().OpenReadStream();
            //var ocrOutput = await ocrRepository.OCRFromStreamAsync(stream);
            var ocrOutput = googleOcr.OCRFromStreamAsync(stream);
            var response = new Splitter().SplitText(ocrOutput);
            var ingredientsString = string.Join(Environment.NewLine, response.Ingridients);
            var responseModel = new ManualCorrectionModel { Ingredients = ingredientsString, Instruction = response.Instruction };
            // TODO: map to Model for rework UI
            return Ok(responseModel);
        }

        [HttpPost("manualcorrection")]
        public async Task<Guid> ManualCorrectionAsync([FromBody] ManualCorrectionModel manualCorrection)
        {
            var splittedIngredients = manualCorrection.Ingredients?.Split("\n");
            var stored = await _recipeRepository.CreateAsync(Recipe.CreateNew(
                manualCorrection.Title,
                manualCorrection.Instruction,
                splittedIngredients.Select(i => new Ingredient() { Name = i })));
            return stored.Id;
        }
    }
}