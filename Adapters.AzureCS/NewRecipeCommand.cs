namespace Adapters.AzureCS
{
    public class NewRecipeCommand
    {
        private readonly IComputerVisionOcrRepository _computerVisionOcrRepository;

        public NewRecipeCommand(IComputerVisionOcrRepository computerVisionOcrRepository)
        {
            _computerVisionOcrRepository = computerVisionOcrRepository;
        }

        public async Task<string> ExecuteAsync(Stream imagePath)
        {
            return await _computerVisionOcrRepository.OCRFromStreamAsync(imagePath);
        }

    }
}
