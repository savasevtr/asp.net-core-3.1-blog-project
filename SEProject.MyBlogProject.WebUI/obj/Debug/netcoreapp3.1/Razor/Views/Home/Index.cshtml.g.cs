#pragma checksum "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07b9bbde4be5ff49ca56ce2914bbdd72f2aff0b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SEProject.MyBlogProject.WebUI.Models.Home.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace SEProject.MyBlogProject.WebUI.Models.Home
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07b9bbde4be5ff49ca56ce2914bbdd72f2aff0b2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b43197f5a0d9ad9865d9c11a6238864783202628", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BlogListModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class-name", "card-img-top", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BlogDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::SEProject.MyBlogProject.WebUI.TagHelpers.ImageTagHelper __SEProject_MyBlogProject_WebUI_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
 if (ViewBag.ActiveCategory != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("GetCategoryName", new { @categoryId = (int)ViewBag.ActiveCategory }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
                                                                                                      
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 8 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
 if (!string.IsNullOrWhiteSpace(ViewBag.SearchString))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("Search", new { @s=ViewBag.SearchString }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
                                                                           
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 13 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card mb-4\">\n\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("getblogimage", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07b9bbde4be5ff49ca56ce2914bbdd72f2aff0b26050", async() => {
            }
            );
            __SEProject_MyBlogProject_WebUI_TagHelpers_ImageTagHelper = CreateTagHelper<global::SEProject.MyBlogProject.WebUI.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__SEProject_MyBlogProject_WebUI_TagHelpers_ImageTagHelper);
#nullable restore
#line 17 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
__SEProject_MyBlogProject_WebUI_TagHelpers_ImageTagHelper.Id = item.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("id", __SEProject_MyBlogProject_WebUI_TagHelpers_ImageTagHelper.Id, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __SEProject_MyBlogProject_WebUI_TagHelpers_ImageTagHelper.ClassName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n    <div class=\"card-body\">\n        <h2 class=\"card-title\">");
#nullable restore
#line 20 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
                          Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n        <p class=\"card-text\">");
#nullable restore
#line 21 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
                        Write(item.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07b9bbde4be5ff49ca56ce2914bbdd72f2aff0b28284", async() => {
                WriteLiteral("Read More &rarr;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
                                                            WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n\n    <div class=\"card-footer text-muted\">\n        Posted on ");
#nullable restore
#line 26 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
             Write(item.PostedTime.ToLongDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <a href=\"#\">Start Bootstrap</a>\n    </div>\n\n</div>");
#nullable restore
#line 30 "C:\Users\SE\source\repos\MyBlogProject\SEProject.MyBlogProject.WebUI\Views\Home\Index.cshtml"
      }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BlogListModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
