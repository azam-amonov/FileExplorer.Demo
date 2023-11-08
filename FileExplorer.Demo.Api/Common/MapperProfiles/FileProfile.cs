using AutoMapper;
using FileExplorer.Demo.Api.Models.DTOs;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FileExplorer.Demo.Api.Common.MapperProfiles;

public class FileProfile : Profile
{
    public FileProfile()
    {
        CreateMap<StorageFile, StorageFileDto>();
        CreateMap<StorageFileDto, StorageFile>();
    }
}