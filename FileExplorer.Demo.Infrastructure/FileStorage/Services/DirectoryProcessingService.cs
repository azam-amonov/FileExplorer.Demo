using FIleExplorer.Demo.Application.FileStorage.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;
using FIleExplorer.Demo.Application.FileStorage.Services;

namespace FileExplorer.Demo.Infrastructure.FileStorage.Services;

public class DirectoryProcessingService : IDirectoryProcessingService
{
    private readonly IFileService _fileService;
    private readonly IDirectoryService _directoryService;

    public DirectoryProcessingService(IFileService fileService, IDirectoryService directoryService)
    {
        _fileService = fileService;
        _directoryService = directoryService;
    }

    public async ValueTask<IList<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDirectoryEntryFilterModel filterModel)
    {
        var storageItems = new List<IStorageEntry>();
        
        if (filterModel.IncludeDirectories)
            storageItems.AddRange(await _directoryService.GetDirectoriesAsync(directoryPath, filterModel));
        
        if(filterModel.IncludeFiles)
            storageItems.AddRange(await _fileService.GetFileByPathAsync(_directoryService.GetFilesPath(directoryPath, filterModel)));

        return storageItems;
    }
}