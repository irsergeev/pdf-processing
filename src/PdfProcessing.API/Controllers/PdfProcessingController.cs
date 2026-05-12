using Microsoft.AspNetCore.Mvc;
using PdfProcessing.Application.Interfaces;

namespace PdfProcessing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfProcessingController(
        IQueueUploadFileService queueUploadFileService,
        IPdfService pdfService) : ControllerBase
    {
        private readonly IQueueUploadFileService _queueUploadFileService = queueUploadFileService;
        private readonly IPdfService _pdfService = pdfService;

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var result = await _queueUploadFileService.UploadPdfFileAsync(file);
            return result ? Ok() : Problem("just some error");
        }

        [HttpGet("GetContentString")]
        public async Task<IActionResult> GetContentStringAsync([FromQuery] Guid id)
        {
            var contentString = await _pdfService.GetStringContentAsync(id);
            return Ok(contentString);
        }

        [HttpGet("GetFileList")]
        public async Task<IActionResult> GetFileList()
        {
            var files = await _pdfService.GetListAsync();
            return Ok(files);
        }
    }
}
