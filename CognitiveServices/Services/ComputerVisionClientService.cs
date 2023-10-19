using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

namespace CognitiveServices.Services
{
    public class ComputerVisionClientService : IComputerVisionClientService
    {
        public ComputerVisionClient _client { get; set; }

        public void Authenticate(string endPoint, string key)
        {
            _client =
                  new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
                  { Endpoint = endPoint };
        }

        public async Task<List<Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models.ImageTag>> AnalyzeImageUrl(string imageUrl)
        {
            // Creating a list that defines the features to be extracted from the image. 
            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Tags
            };
            // Analyze the URL image 
            ImageAnalysis results = await _client.AnalyzeImageAsync(imageUrl, visualFeatures: features);
            List<Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models.ImageTag> tags = (List<Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models.ImageTag>)results.Tags;
            return tags;
        }
    }
}
