using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FIleExplorer.Demo.Application.FileStorage.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Services;

namespace FileExplorer.Demo.Api.Controllers;

[ApiController]
[Route("api[controller]")]

public class DirectoriesControllers : ControllerBase
{
    private readonly IDirectoryProcessingService _directoryProcessingService;
    private readonly IMapper _mapper;

    public DirectoriesControllers(IDirectoryProcessingService directoryProcessingService, IMapper mapper)
    {
        _directoryProcessingService = directoryProcessingService;
        _mapper = mapper;
    }

    [HttpGet("root/entries")]
    public async ValueTask<IActionResult> GetRootEntriesAsync ([FromQuery] StorageDirectoryEntryFilterModel filterModel,
                    [FromServices] IWebHostEnvironment environment)
    {
        var data = await _directoryProcessingService.GetEntriesAsync(environment.WebRootPath, filterModel);
        return data.Any() ? Ok(data) : NoContent();
    }

    [HttpGet("{directoryPath}/entries")]
    public async ValueTask<IActionResult> GetDirectoryEntriesByPathAsync([FromRoute] string directoryPath,
                    [FromQuery] StorageDirectoryEntryFilterModel filterModel)
    {
        var data = await _directoryProcessingService.GetEntriesAsync(directoryPath, filterModel);
        return data.Any() ? Ok(data) : NoContent();
    }
}