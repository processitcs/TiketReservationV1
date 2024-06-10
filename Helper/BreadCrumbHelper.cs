using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RezervariBilete.Helper.Model;

namespace RezervariBilete.Helper;

public static class BreadCrumbHelper
{
    public static HtmlString BreadCrumb(this HtmlHelper htmlHelper, params BreadCrumItem[] items )
    {
        if (items == null || items.Length == 0)
            return HtmlString.Empty;
        var sb = new StringBuilder();
        sb.Append("<nav aria-label=\"breadcrumb\">");
        sb.Append("<ol class=\"breadcrumb\">");

        foreach (var item in items)
        {
            sb.Append("<li class=\"breadcrumb-item");
            if (item.IsActive)
            {
                sb.Append(" active\" aria-current=\"page\">");
                sb.Append(htmlHelper.Encode(item.Title));
            }
            else
            {
                sb.Append("\">");
                var url = new UrlHelper(htmlHelper.ViewContext).Action(item.Action, item.Controller, item.RouteValues);
                sb.AppendFormat("<a href=\"{0}\">{1}</a>", url, htmlHelper.Encode(item.Title));
            }
            sb.Append("</li>");
        }

        sb.Append("</ol>");
        sb.Append("</nav>");

        return new HtmlString(sb.ToString());
    }
}