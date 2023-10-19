namespace CognitiveServices.Services
{
    public interface IComputerVisionClientService
    {
        void Authenticate(string endPoint, string key);
        Task<List<Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models.ImageTag>> AnalyzeImageUrl(string imageUrl);
    }
}
