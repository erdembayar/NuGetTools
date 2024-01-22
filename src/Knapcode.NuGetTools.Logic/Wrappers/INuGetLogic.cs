namespace Knapcode.NuGetTools.Logic.Wrappers;

public interface INuGetLogic
{
    IFrameworkLogic Framework { get; }
    IVersionLogic Version { get; }
    IVersionRangeLogic VersionRange { get; }
    IReadOnlyList<string> AssemblyNames { get; }
}
