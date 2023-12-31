using AutoMapper;
using FileExplorer.Demo.Api.Models.DTOs;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FileExplorer.Demo.Api.Common.MapperProfiles;

public class DirectoryProfile : Profile
{
    public DirectoryProfile()
    {
        CreateMap<StorageDirectory, StorageDirectoryDto>();
        CreateMap<StorageDirectoryDto, StorageDirectory>();
    }
}