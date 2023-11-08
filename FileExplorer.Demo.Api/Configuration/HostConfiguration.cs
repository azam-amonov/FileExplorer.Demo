namespace FileExplorer.Demo.Api.Configuration;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        throw new NotSupportedException();
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication builder)
    {
        throw new NotSupportedException();
    }
}