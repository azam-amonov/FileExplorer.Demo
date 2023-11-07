using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FIleExplorer.Demo.Application.FileStorage.Brokers;

public interface IDriverBroker
{
    IEnumerable<StorageDrive> Get();
}