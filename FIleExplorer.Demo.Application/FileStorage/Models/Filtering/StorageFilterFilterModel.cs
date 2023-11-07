using FIleExplorer.Demo.Application.Commons.Models.Filtering;

namespace FIleExplorer.Demo.Application.FileStorage.Models.Filtering;

public class StorageFilterFilterModel : FilterPagination
{
    public string DirectoryPath { get; set; } = string.Empty;
    
    public  ICollection<StorageFileType> FileTypes { get; set; } = default!;
}