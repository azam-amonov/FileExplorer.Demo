using FIleExplorer.Demo.Application.FileStorage.Brokers;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;
using FIleExplorer.Demo.Application.FileStorage.Services;

namespace FileExplorer.Demo.Infrastructure.FileStorage.Services;

public class DriveService: IDriveService
{
    private readonly IDriverBroker _driverBroker;

    public DriveService(IDriverBroker driverBroker)
    {
        _driverBroker = driverBroker;
    }

    public ValueTask<IList<StorageDrive>> GetAsync()
    {
        var drivers = _driverBroker.Get().ToList();
        
        return new ValueTask<IList<StorageDrive>>(drivers);
    }
}