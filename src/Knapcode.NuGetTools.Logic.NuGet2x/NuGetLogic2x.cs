using Knapcode.NuGetTools.Logic.Wrappers;
using NuGet;

namespace Knapcode.NuGetTools.Logic.NuGet2x;

public class NuGetLogic2x : INuGetLogic
{
    public NuGetLogic2x()
    {
        Framework = new FrameworkLogic2x();
        Version = new VersionLogic2x();
        VersionRange = new VersionRangeLogic2x();
        AssemblyNames = new[]
        {
            typeof(VersionUtility).Assembly.FullName ?? throw new NotSupportedException(),
        };
    }

    public IFrameworkLogic Framework { get; }
    public IVersionLogic Version { get; }
    public IVersionRangeLogic VersionRange { get; }
    public IReadOnlyList<string> AssemblyNames { get; }
}
