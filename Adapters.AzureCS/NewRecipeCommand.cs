using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
