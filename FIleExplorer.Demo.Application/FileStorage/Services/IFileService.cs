using FIleExplorer.Demo.Application.Commons.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FIleExplorer.Demo.Application.FileStorage.Services;

public interface IFileService
{
    ValueTask<IList<StorageFile>> GetFileByPathAsync(IEnumerable<string> filesPaths);
    
    ValueTask<StorageFile> GetFileByPathAsync(string path);
    
    IEnumerable<StorageFilesSummary> GetFileSummary(IEnumerable<StorageFile> files);
    
    StorageFileType GetFileType(string filePath);
}