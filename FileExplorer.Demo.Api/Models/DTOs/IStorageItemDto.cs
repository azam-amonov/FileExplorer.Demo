using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FileExplorer.Demo.Api.Models.DTOs;

public interface IStorageItemDto
{
    string Path { get; set; }
    
    StorageEntryType EntryType { get; set; }
}