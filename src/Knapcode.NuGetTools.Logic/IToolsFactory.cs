using Knapcode.NuGetTools.Logic.Wrappers;

namespace Knapcode.NuGetTools.Logic;

public interface IToolsFactory
{
    /// <summary>
    /// Gets the available versions provided by this factory in descending order. That is, the highest version
    /// available will be the first item in the sequence.
    /// </summary>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The sequence of versions.</returns>
    Task<IEnumerable<string>> GetAvailableVersionsAsync(CancellationToken token);

    Task<string> GetLatestVersionAsync(CancellationToken token);

    Task<IToolsService?> GetServiceAsync(string version, CancellationToken token);

    Task<IFrameworkPrecedenceService?> GetFrameworkPrecedenceServiceAsync(string version, CancellationToken token);

    Task<IFrameworkList> GetFrameworkListAsync(CancellationToken token);

    Task<IReadOnlyList<NuGetPackage>?> GetPackagesAsync(string version, CancellationToken token);
}
