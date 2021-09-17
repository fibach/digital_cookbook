using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.AzureCS
{
    public interface IComputerVisionOcrRepository
    {
        Task<string> OCRFromStreamAsync(Stream stream);
    }
}
