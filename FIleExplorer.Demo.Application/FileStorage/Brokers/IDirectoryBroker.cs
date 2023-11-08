using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FIleExplorer.Demo.Application.FileStorage.Brokers;

public interface IDirectoryBroker
{
    IEnumerable<string> GetDirectoryPath(string directoryPath);

    IEnumerable<string> GetFilePath(string directoryPath);
    
    IEnumerable<StorageDirectory> GetStorageDirectories(string directoryPath);
    
    StorageDirectory GetByPathAsync(string directoryPath);
    
    bool ExistsAsync(string directoryPath);
}