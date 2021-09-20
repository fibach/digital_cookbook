using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.GoogleCV
{
    public interface ICloudVisionOcr
    {
        string OCRFromStreamAsync(Stream stream);
    }
}
