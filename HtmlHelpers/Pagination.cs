using Edu.Utils;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.HtmlHelpers
{
    public static class Pagination
    {
        public static IHtmlContent PagedList(this IHtmlHelper htmlHelper)
        {
            var pagedResult = htmlHelper.ViewData.Model as PagedResultBase;
            TagBuilder ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");
            for (int i = 0; i < pagedResult.PageCount; i++)
            {
                var aTag = htmlHelper.ActionLink((i + 1).ToString(), "Index", 
                    new { page = i + 1 }, 
                    new { @class = "page-link" });

                TagBuilder liTag = new TagBuilder("li");
                liTag.AddCssClass("page-item");

                if (pagedResult.CurrentPage == (i + 1))
                {
                    liTag.AddCssClass("active");
                }

                liTag.InnerHtml.AppendHtml(aTag);
                ulTag.InnerHtml.AppendHtml(liTag);
            }
            return ulTag; 
        }
    }
}
