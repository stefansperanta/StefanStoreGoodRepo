using System;
using System.Text;
using System.Web.Mvc;
using StefanStoreDTO.ProductDto;

namespace StefanStore.WebUI.Helpers.Html
{
    public static class PagingHelpers
    {
        public static MvcHtmlString CreatePageLinks(this HtmlHelper html,
            PagingInfo pagingInfo,
            Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var tag = ConstructAnchorTag(pagingInfo, pageUrl, i);
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        private static TagBuilder ConstructAnchorTag(PagingInfo pagingInfo, Func<int, string> pageUrl, int i)
        {
            TagBuilder tag = new TagBuilder("a");
            tag.MergeAttribute("href", pageUrl(i));
            tag.InnerHtml = i.ToString();
            if (i == pagingInfo.CurrentPage)
                tag.AddCssClass("selected");
            return tag;
        }
    }
}