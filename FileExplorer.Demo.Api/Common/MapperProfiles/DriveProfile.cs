using AutoMapper;
using FileExplorer.Demo.Api.Models.DTOs;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;

namespace FileExplorer.Demo.Api.Common.MapperProfiles;

public class DriveProfile : Profile
{
    public DriveProfile()
    {
        CreateMap<StorageDrive, StorageDriveDto>();
        CreateMap<StorageDriveDto, StorageDrive>();
    }
}