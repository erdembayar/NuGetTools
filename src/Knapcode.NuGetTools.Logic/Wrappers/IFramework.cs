namespace Knapcode.NuGetTools.Logic.Wrappers;

public interface IFramework
{
    string ShortFolderName { get; }
    string DotNetFrameworkName { get; }
    string Identifier { get; }
    Version Version { get; }
    bool HasProfile { get; }
    string Profile { get; }
    bool IsPlatformAvailable { get; }
    bool HasPlatform { get; }
    string Platform { get; }
    Version PlatformVersion { get; }
    string ToStringResult { get; }
}
