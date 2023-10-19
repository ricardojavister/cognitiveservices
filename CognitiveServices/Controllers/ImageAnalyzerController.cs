using CognitiveServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace CognitiveServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageAnalyzerController : ControllerBase
    {
        private readonly IComputerVisionClientService _clientService;
        public ImageAnalyzerController(IComputerVisionClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("url")]
        public async Task<ActionResult<List<Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models.ImageTag>>> GetAnalysis(string url) {
            _clientService.Authenticate("https://computervisiondigitalsky.cognitiveservices.azure.com/", "YOUR_KEY");
            var tags = await _clientService.AnalyzeImageUrl(url);
            return tags;
        }
    }
}
