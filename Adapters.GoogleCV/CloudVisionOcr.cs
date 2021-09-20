using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;
using Google.Cloud.Vision.V1;

namespace Adapters.GoogleCV
{
    public class CloudVisionOcr : ICloudVisionOcr
    {
        public string OCRFromStreamAsync(Stream stream)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "google-key.json");

            try
            {             
                Image image = Image.FromStream(stream);
                ImageAnnotatorClient client = ImageAnnotatorClient.Create();
                TextAnnotation text = client.DetectDocumentText(image);

                return text.Text;
                //return DisplayResults(text);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private string DisplayResults(TextAnnotation text)
        {
            var output = string.Empty;
            output += $"Text: {text.Text}\n";
            foreach (var page in text.Pages)
            {
                foreach (var block in page.Blocks)
                {
                    string box = string.Join(" - ", block.BoundingBox.Vertices.Select(v => $"({v.X}, {v.Y})"));
                    output += $"Block {block.BlockType} at {box}\n";
                    foreach (var paragraph in block.Paragraphs)
                    {
                        box = string.Join(" - ", paragraph.BoundingBox.Vertices.Select(v => $"({v.X}, {v.Y})"));
                        output += $"  Paragraph at {box}\n";
                        foreach (var word in paragraph.Words)
                        {
                            output += $"    Word: {string.Join("", word.Symbols.Select(s => s.Text))}\n";
                        }
                    }
                }
            }

            return output;
        }
    }
}