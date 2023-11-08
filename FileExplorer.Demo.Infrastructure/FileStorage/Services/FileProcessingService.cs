using FIleExplorer.Demo.Application.Commons.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;
using FIleExplorer.Demo.Application.FileStorage.Services;

namespace FileExplorer.Demo.Infrastructure.FileStorage.Services;

public class FileProcessingService : IFileProcessingService
{
    private readonly IDirectoryService _directoryService;
    private readonly IFileService _fileService;

    public FileProcessingService(IDirectoryService directoryService, IFileService fileService)
    {
        _directoryService = directoryService;
        _fileService = fileService;
    }

    public async ValueTask<StorageFileFilterDataModel> GetFilterDataModelAsync(string directoryPath)
    {
        var pagination = new FilterPagination
        {
            PageSize = int.MaxValue,
            PageToken = 1
        };

        var filesPath = _directoryService.GetFilesPath(directoryPath, pagination);
        var files = await _fileService.GetFileByPathAsync(filesPath);

        var fileSummary = _fileService.GetFileSummary(files);
        var filterDataModel = new StorageFileFilterDataModel
        {
            FilterData = fileSummary.ToList()
        };

        return filterDataModel;
    }

    public async ValueTask<IList<StorageFile>> GetByFilterAsync(StorageFileFilterModel filterModel)
    {
        var filteredFilesPath = _directoryService
                        .GetFilesPath(filterModel.DirectoryPath, filterModel)
                        .Where(filePath => filterModel.FileTypes.Contains(_fileService.GetFileType(filePath)));
        var files = await _fileService.GetFileByPathAsync(filteredFilesPath);

        return files;
    }
}