using FIleExplorer.Demo.Application.FileStorage.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FIleExplorer.Demo.Application.FileStorage.Services;

public interface IFileProcessingService
{
    ValueTask<StorageFileFilterDataModel> GetFilterDataModelAsync(string directoryPath);

    ValueTask<IList<StorageFile>> GetByFilterAsync(StorageFileFilterModel filterModel);
}