using FIleExplorer.Demo.Application.FileStorage.Models.Filtering;

namespace FIleExplorer.Demo.Application.Commons.Models.Filtering;

public class StorageFilesSummary
{
    public StorageFileType FileType { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public long Count { get; set; }

    public long Size { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
}