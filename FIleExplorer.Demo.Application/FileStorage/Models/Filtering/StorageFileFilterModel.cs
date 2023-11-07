using FIleExplorer.Demo.Application.Commons.Models.Filtering;

namespace FIleExplorer.Demo.Application.FileStorage.Models.Filtering;

public class StorageFileFilterModel : FilePagination
{
    public string DirectoryPath { get; set; } = string.Empty;
    
    public  ICollection<StorageFileType> FileTypes { get; set; } = default!;
}