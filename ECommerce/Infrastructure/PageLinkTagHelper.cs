// The Infrastructure folder is where I put classes that deliver the plumbing for an application but that are not related to the application’s main functionality.
//A Tag Helper is a feature in ASP.NET Core that allows developers to generate HTML markup dynamically using C# code within Razor views.
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
namespace ECommerce.Infrastructure
// This tag helper populates a div element with a elements that correspond to pages of products
// tag helpers have to be registered
{
    [HtmlTargetElement("div",Attributes="page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlhelperfactory;

        public PageLinkTagHelper(IUrlHelperFactory urlhelperfactory)
        {
            this.urlhelperfactory = urlhelperfactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public PageInfo? PageModel { get; set; }
        public string? PageAction { get; set; }

        //Adding classes to elements 
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } = String.Empty;
        public string PageClassNormal { get; set; } = String.Empty;
        public string PageClassSelected { get; set; } = String.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(ViewContext!=null && PageModel != null)
            {
                IUrlHelper urlHelper= urlhelperfactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                for (int i = 1;i<=PageModel.TotalPages;i++)
                {
                   TagBuilder tag=new TagBuilder("a");
                    tag.Attributes["href"]=urlHelper.Action(PageAction,new { productPage = i });
                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                    }
                    tag.InnerHtml.AppendHtml(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }
                output.Content.AppendHtml(result.InnerHtml);
            }
        }

    }
}
