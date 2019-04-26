using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaglarDurmus.ShoppingApi.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper : TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-categoryId")]
        public int CurrentCategoryId { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("<ul class ='pagination'>");

            stringBuilder.AppendFormat(
                @"<li class='page-item {2}'>
                    <a class='page-link' href='/Product/Index?page={0}&categoryId={1}'>Previous</a>
                  </li>", CurrentPage - 1, CurrentCategoryId, CurrentPage == 1 ? "disabled" : string.Empty);

            for (int i = 1; i <= PageCount; i++)
            {
                bool isCurrentPage = (i == CurrentPage);
                string str = string.Empty;

                stringBuilder.AppendFormat("<li class='page-item {0}'>", isCurrentPage ? "active" : string.Empty);

                if (!isCurrentPage)
                {
                    str = string.Format("href='/Product/Index?page={0}&categoryId={1}'", i, CurrentCategoryId);
                }
                else
                {
                    str = "style='cursor:default'";
                }

                stringBuilder.AppendFormat("<a class='page-link' {0}>{1}</a>", str, i);

                stringBuilder.Append("</li>");
            }

            stringBuilder.AppendFormat(
                @"<li class='page-item {2}'>
                    <a class='page-link' href='/Product/Index?page={0}&categoryId={1}' {2}>Next</a>
                  </li>", CurrentPage + 1, CurrentCategoryId, CurrentPage == PageSize ? "disabled" : string.Empty);

            output.Content.SetHtmlContent(stringBuilder.ToString());

            base.Process(context, output);
        }
    }
}
