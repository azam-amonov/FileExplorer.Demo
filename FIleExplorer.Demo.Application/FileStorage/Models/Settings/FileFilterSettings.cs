namespace FIleExplorer.Demo.Application.FileStorage.Models.Settings;

public class FileFilterSettings
{
    public ICollection<FileExtensionsSetting> FileExtensions { get; set; } = default!;
}