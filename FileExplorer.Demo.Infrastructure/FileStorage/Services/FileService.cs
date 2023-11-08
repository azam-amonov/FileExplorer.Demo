using Microsoft.Extensions.Options;
using FIleExplorer.Demo.Application.Commons.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Brokers;
using FIleExplorer.Demo.Application.FileStorage.Models.Filtering;
using FIleExplorer.Demo.Application.FileStorage.Models.Settings;
using FIleExplorer.Demo.Application.FileStorage.Models.Storage;
using FIleExplorer.Demo.Application.FileStorage.Services;

namespace FileExplorer.Demo.Infrastructure.FileStorage.Services;

public class FileService: IFileService
{
    private readonly FileFilterSettings _fileFilterSettings;
    private readonly FileStorageSettings _fileStorageSettings;
    private readonly IFileBroker _fileBroker;


    public FileService(IOptions<FileFilterSettings> fileFilterSettings, IOptions<FileStorageSettings> fileStorageSettings, IFileBroker fileBroker)
    {
        _fileFilterSettings = fileFilterSettings.Value;
        _fileStorageSettings = fileStorageSettings.Value;
        _fileBroker = fileBroker;
    }

    public async ValueTask<IList<StorageFile>> GetFileByPathAsync(IEnumerable<string> filesPaths)
    {
        var files = await Task.Run(() =>
        {
            return filesPaths.Select(filePath => _fileBroker.GetByPath(filePath)).ToList();
        });
        return files;
    }

    public ValueTask<StorageFile> GetFileByPathAsync(string path) =>
                    !string.IsNullOrWhiteSpace(path)
                            ? new ValueTask<StorageFile>(_fileBroker.GetByPath(path))
                            : throw new ArgumentNullException(nameof(path));

    public IEnumerable<StorageFilesSummary> GetFileSummary(IEnumerable<StorageFile> files)
    {
        var filesType = files.Select(file => (File: file, Type: GetFileType(file.Path)));
        return filesType
            .GroupBy(file => file.Type)
            .Select(filesGroup => new StorageFilesSummary
        {
            FileType = filesGroup.Key,
            DisplayName = _fileFilterSettings.FileExtensions.FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.DisplayName ??
                          "Other Files",
            Count = filesGroup.Count(),
            Size = filesGroup.Sum(file => file.File.Size),
            ImageUrl = _fileFilterSettings.FileExtensions.FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.ImageUrl ??
                       _fileStorageSettings.FileImageUrl
        });
    }

    public StorageFileType GetFileType(string filePath)
    {
        var fileExtension = Path.GetExtension(filePath).TrimStart('.');
        var matchedFileType = _fileFilterSettings.FileExtensions.FirstOrDefault(extension => extension.Extensions.Contains(fileExtension));
        return matchedFileType?.FileType ?? StorageFileType.Other;
    }
}