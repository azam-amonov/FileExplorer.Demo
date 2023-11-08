using AutoMapper;
using FIleExplorer.Demo.Application.Commons.Models.Filtering;
using FIleExplorer.Demo.Application.Commons.Querying.Extensions;
using FIleExplorer.Demo.Application.FileStorage.Brokers;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;
using FIleExplorer.Demo.Application.FileStorage.Services;

namespace FileExplorer.Demo.Infrastructure.FileStorage.Services;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _broker;
    private readonly IMapper _mapper;

    public DirectoryService(IDirectoryBroker broker, IMapper mapper)
    {
        _broker = broker;
        _mapper = mapper;
    }

    public IEnumerable<string> GetDirectoriesPath(string directoryPath, FilterPagination paginationOptions) =>
            _broker.GetFilePath(directoryPath).ApplyPagination(paginationOptions);
    
    public IEnumerable<string> GetFilesPath(string directoryPath, FilterPagination paginationOptions) => 
                    _broker.GetFilePath(directoryPath).ApplyPagination(paginationOptions);
    
    public async ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath, FilterPagination paginationOptions)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        var directories = 
                        await Task.Run(() => _broker
                        .GetStorageDirectories(directoryPath)
                        .ApplyPagination(paginationOptions).ToList());
        return directories;
    }

    public ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        return new ValueTask<StorageDirectory?>(_broker.GetByPathAsync(directoryPath));
    }
}