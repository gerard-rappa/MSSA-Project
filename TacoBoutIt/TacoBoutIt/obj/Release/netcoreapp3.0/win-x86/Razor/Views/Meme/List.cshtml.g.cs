#pragma checksum "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\Meme\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95087e7d20848f64d628685ac8adba6ad72d636a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Meme_List), @"mvc.1.0.view", @"/Views/Meme/List.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\_ViewImports.cshtml"
using TacoBoutIt.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\_ViewImports.cshtml"
using TacoBoutIt.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95087e7d20848f64d628685ac8adba6ad72d636a", @"/Views/Meme/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b680dde1517f0cf5fa9c8a850d7b2f8f65e1fa88", @"/Views/_ViewImports.cshtml")]
    public class Views_Meme_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Meme>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\Meme\List.cshtml"
Write(Html.Partial("MyPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\Meme\List.cshtml"
 foreach (var r in Model)
{
    if (r.ImgUrl.Contains(".webm"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"flex-fill px-4\" style=\"text-align:center; width:auto\">\r\n            <video controls class=\"img-fluid\" type=\"video/webm\" style=\"max-width:100%; max-height:650px; background-size:contain\"");
            BeginWriteAttribute("src", " src=\"", 339, "\"", 400, 2);
            WriteAttributeValue("", 345, "https://litmemes.blob.core.windows.net/images/", 345, 46, true);
#nullable restore
#line 11 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\Meme\List.cshtml"
WriteAttributeValue("", 391, r.ImgUrl, 391, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></video>\r\n            <p class=\"container-fluid font-weight-light\">Latitude: ");
#nullable restore
#line 12 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\Meme\List.cshtml"
                                                              Write(Math.Round(r.Latitude, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br> ");
#nullable restore
#line 12 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\Meme\List.cshtml"
                                                                                              Write(Math.Round(r.Longitude, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <br />\r\n        </div>\r\n");
#nullable restore
#line 15 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\Meme\List.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"flex-fill px-4\" style=\"text-align:center; width:100%;\">\r\n            <img class=\"img-fluid rounded\" style=\"max-width:100%; max-height:650px; background-size:contain\"");
            BeginWriteAttribute("src", " src=\"", 789, "\"", 850, 2);
            WriteAttributeValue("", 795, "https://litmemes.blob.core.windows.net/images/", 795, 46, true);
#nullable restore
#line 19 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\Meme\List.cshtml"
WriteAttributeValue("", 841, r.ImgUrl, 841, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            <p class=\"container-fluid font-weight-light\">Latitude: ");
#nullable restore
#line 20 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\Meme\List.cshtml"
                                                              Write(Math.Round(r.Latitude, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>Longitude: ");
#nullable restore
#line 20 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\Meme\List.cshtml"
                                                                                                        Write(Math.Round(r.Longitude, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <br />\r\n        </div>\r\n");
#nullable restore
#line 23 "C:\Users\user\Desktop\MSSA Project\TacoBoutIt\TacoBoutIt\Views\Meme\List.cshtml"
    }
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Meme>> Html { get; private set; }
    }
}
#pragma warning restore 1591
