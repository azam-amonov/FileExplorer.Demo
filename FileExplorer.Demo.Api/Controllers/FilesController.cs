using FIleExplorer.Demo.Application.FileStorage.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Demo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IFileProcessingService _fileProcessingService;

    public FilesController(IWebHostEnvironment hostEnvironment, IFileProcessingService processingService)
    {
        _hostEnvironment = hostEnvironment;
        _fileProcessingService = processingService;
    }
    [HttpGet("root/files/filter")]
    public async ValueTask<IActionResult> GetFileSummary()
    {
        var result = await _fileProcessingService.GetFilterDataModelAsync(_hostEnvironment.WebRootPath);
        return Ok(result);
    }

    [HttpGet("root/files/by-filter")]
    public async ValueTask<IActionResult> GetFileByFilter([FromQuery] StorageFileFilterModel filterModel)
    {
        var files = await _fileProcessingService.GetByFilterAsync(filterModel);
        return files.Any() ? Ok(files) : NotFound(files);
    }
    
}