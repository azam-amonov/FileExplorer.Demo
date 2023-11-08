using AutoMapper;
using FIleExplorer.Demo.Application.FileStorage.Brokers;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FileExplorer.Demo.Infrastructure.FileStorage.Brokers;

public class FileBroker: IFileBroker
{
    private readonly IMapper _mapper;

    public FileBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public StorageFile GetByPath(string filePath)
    {
        return _mapper.Map<StorageFile>(new FileInfo(filePath));
    }
}