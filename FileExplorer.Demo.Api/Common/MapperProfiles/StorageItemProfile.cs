using AutoMapper;
using FileExplorer.Demo.Api.Models.DTOs;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FileExplorer.Demo.Api.Common.MapperProfiles;

public class StorageItemProfile : Profile
{
    public StorageItemProfile()
    {
        CreateMap<IStorageEntry, IStorageItemDto>();
        CreateMap<IStorageItemDto, IStorageEntry>();
    }
}