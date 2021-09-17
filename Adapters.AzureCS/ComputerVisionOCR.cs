using Application;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.AzureCS
{
    public class ComputerVisionOCR : IComputerVisionOcrRepository
    {
        public ComputerVisionOCR()
        {
        }

        public async Task<string> OCRFromStreamAsync(Stream stream)
        {
            var computerVision = CreateClient();
            OcrResult analysis = await computerVision.RecognizePrintedTextInStreamAsync(true, stream);
            return DisplayResults(analysis);
        }

        private string DisplayResults(OcrResult analysis)
        {
            var output = string.Empty;
            foreach (var region in analysis.Regions)
            {
                foreach (var line in region.Lines)
                {
                    foreach (var word in line.Words)
                    {
                        output += word.Text + " ";
                    }
                    output += "\n";
                }
            }

            return output;
        }
        
        private ComputerVisionClient CreateClient()
        {
            string subscriptionKey = "fd7e47ff4ad34912903bd556ec832e76";
            string endpoint = "https://cookbookcomputertvision.cognitiveservices.azure.com/";

            ComputerVisionClient computerVision = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
            {
                Endpoint = endpoint
            };

            return computerVision;
        }
    }
}
