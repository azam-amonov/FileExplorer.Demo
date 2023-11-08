using FIleExplorer.Demo.Application.Commons.Models.Filtering;

namespace FIleExplorer.Demo.Application.FileStorage.Models.Filtering;

public class StorageDirectoryEntryFilterModel : FilterPagination
{
    public bool IncludeDirectories { get; set; }
    
    public bool IncludeFiles { get; set; }
}