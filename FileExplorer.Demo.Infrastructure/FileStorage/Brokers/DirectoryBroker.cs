using AutoMapper;
using FIleExplorer.Demo.Application.FileStorage.Brokers;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FileExplorer.Demo.Infrastructure.FileStorage.Brokers;

public class DirectoryBroker : IDirectoryBroker
{
    private readonly IMapper _mapper;

    public DirectoryBroker(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public IEnumerable<string> GetDirectoryPath(string directoryPath)
    {
        return Directory.EnumerateDirectories(directoryPath);
    }

    public IEnumerable<string> GetFilePath(string directoryPath)
    {
        return Directory.EnumerateFiles(directoryPath);
    }

    public IEnumerable<StorageDirectory> GetStorageDirectories(string directoryPath)
    {
        return GetDirectoryPath(directoryPath)
                        .Select(path => _mapper.Map<StorageDirectory>(new DirectoryInfo(directoryPath)));
    }

    public StorageDirectory GetByPathAsync(string directoryPath)
    {
        return _mapper.Map<StorageDirectory>(new DirectoryInfo(directoryPath));
    }

    public bool ExistsAsync(string directoryPath)
    {
        return Directory.Exists(directoryPath);
    }
}