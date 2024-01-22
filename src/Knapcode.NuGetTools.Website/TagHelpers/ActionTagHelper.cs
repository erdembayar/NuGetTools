using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Knapcode.NuGetTools.Website;

public abstract class ActionTagHelper : TagHelper
{
    private readonly IUrlHelperFactory _urlHelperFactory;

    public ActionTagHelper(IUrlHelperFactory urlHelperFactory)
    {
        _urlHelperFactory = urlHelperFactory;
    }

    [ViewContext]
    public ViewContext? ViewContext { get; set; }

    public string? Value { get; set; }

    protected abstract string ActionName { get; }
    protected abstract RouteValueDictionary GetRouteValues(string value);

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // build the output
        output.TagName = "a";

        if (Value is null || ViewContext is null)
        {
            return;
        }

        // get the action URL
        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

        var routeValues = GetRouteValues(Value);

        const string nuGetVersionKey = "nuGetVersion";
        if (!routeValues.ContainsKey(nuGetVersionKey)
            && ViewContext.RouteData.Values.TryGetValue(nuGetVersionKey, out var nuGetVersion))
        {
            routeValues.Add(nuGetVersionKey, nuGetVersion);
        }

        var href = urlHelper.Action(ActionName, "Home", routeValues);

        output.Attributes.Add("href", href);

        if (output.TagMode != TagMode.StartTagAndEndTag)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content = new DefaultTagHelperContent().Append(Value);
        }
    }
}
