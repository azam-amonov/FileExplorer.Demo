using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FileExplorer.Demo.Api.Models.DTOs;

public class StorageDirectoryDto
{
    public string Name { get; set; } = string.Empty;
    
    public string Path { get; set; } = string.Empty;
    
    public long ItemsCount { get; set; }
    
    public StorageEntryType EntryType { get; set; }
}