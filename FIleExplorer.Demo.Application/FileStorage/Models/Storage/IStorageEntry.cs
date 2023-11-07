namespace FIleExplorer.Demo.Application.FileStorage.Models.Storage;

public interface IStorageEntry
{ 
    string Path {get; set; }
    
    StorageEntryType EntryType {get; set; }
}