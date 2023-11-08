using FIleExplorer.Demo.Application.FileStorage.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FIleExplorer.Demo.Application.FileStorage.Models.Settings;

public class FileExtensionsSetting
{
    public StorageFileType FileType { get; set; }

    public string DisplayName { get; set; } = string.Empty;
    
    public string ImageUrl { get; set; } = string.Empty;

    public ICollection<string> Extensions { get; set; } = default!;
}

// Type - SourceCode
// Name - Source Code
// ImageUrl - wwwroot/images/souce.code
// Extension - .cs, .css, .js