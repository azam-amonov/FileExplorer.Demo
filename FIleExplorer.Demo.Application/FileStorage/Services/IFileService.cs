using FIleExplorer.Demo.Application.Commons.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FIleExplorer.Demo.Application.FileStorage.Services;

public interface IFileService
{
    ValueTask<IList<StorageFile>> GetFileByPathAsync(IEnumerable<string> filePaths);
    
    ValueTask<StorageFile> GetFileByPathAsync(string path);
    
    IEnumerable<StorageFileSummary> GetFileSummary(IEnumerable<StorageFile> files);
    
    StorageFile GetFileType(string filePath);
}