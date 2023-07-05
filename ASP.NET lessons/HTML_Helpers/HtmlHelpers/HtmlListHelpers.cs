using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace HTML_Helpers.HtmlHelpers;
public static class HtmlListHelpers
{
    public static HtmlString ListFor(
        this IHtmlHelper helper, 
        IEnumerable<object> items,
        string listTag = "ul",
        string color = "black",
        float fontSize = 16) 
    {
        var sb = new StringBuilder();
        sb.Append($@"<{listTag} 
style='color: {color}; 
font-size: {fontSize}px;'>");
        foreach (var item in items)
        {
            sb.Append($"<li>{item}</li>");
        }
        sb.Append($"</{listTag}>");
        return new HtmlString(sb.ToString());
    }
}
