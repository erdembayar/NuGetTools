using Knapcode.NuGetTools.Logic.Wrappers;

namespace Knapcode.NuGetTools.Logic.Models.VersionRange;

public class FindBestVersionMatchOutput
{
    public InputStatus InputStatus { get; set; }
    public FindBestVersionMatchInput? Input { get; set; }
    public bool IsVersionRangeValid { get; set; }
    public bool IsVersionValid { get; set; }
    public IVersionRange? VersionRange { get; set; }
    public required IReadOnlyList<OutputVersion> Versions { get; set; }
    public OutputVersion? BestMatch { get; set; }
    public required IReadOnlyList<string> Invalid { get; set; }
    public bool IsOperationSupported { get; set; }
    public bool AreVersionsSorted { get; set; }
}
