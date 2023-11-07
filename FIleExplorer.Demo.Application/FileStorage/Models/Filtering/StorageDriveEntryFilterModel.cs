using FIleExplorer.Demo.Application.Commons.Models.Filtering;

namespace FIleExplorer.Demo.Application.FileStorage.Models.Filtering;

public class StorageDriveEntryFilterModel : FilterPagination
{
    public bool IncludeDirection { get; set; }
    
    public bool IncludeFiles { get; set; }
}