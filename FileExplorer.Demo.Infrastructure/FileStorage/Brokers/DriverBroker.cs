using AutoMapper;
using FIleExplorer.Demo.Application.FileStorage.Brokers;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FileExplorer.Demo.Infrastructure.FileStorage.Brokers;

public class DriverBroker : IDriverBroker
{
    private readonly IMapper _mapper;

    public DriverBroker(IMapper mapper)
    {
        _mapper = mapper;
    }
    public IEnumerable<StorageDrive> Get()
    {
        return DriveInfo
            .GetDrives()
            .Select(drive => _mapper.Map<StorageDrive>(drive))
            .AsQueryable();
    }
}