#pragma checksum "C:\Users\WWStudent\Source\Repos\gerard-rappa\MSSA-Project\TacoBoutIt\TacoBoutIt\Views\Map\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c29a5d3832f63ef87e12d90a7139bce60be62e70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Map_Index), @"mvc.1.0.view", @"/Views/Map/Index.cshtml")]
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
#line 1 "C:\Users\WWStudent\Source\Repos\gerard-rappa\MSSA-Project\TacoBoutIt\TacoBoutIt\Views\_ViewImports.cshtml"
using TacoBoutIt.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\WWStudent\Source\Repos\gerard-rappa\MSSA-Project\TacoBoutIt\TacoBoutIt\Views\_ViewImports.cshtml"
using TacoBoutIt.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c29a5d3832f63ef87e12d90a7139bce60be62e70", @"/Views/Map/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b680dde1517f0cf5fa9c8a850d7b2f8f65e1fa88", @"/Views/_ViewImports.cshtml")]
    public class Views_Map_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Meme>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""px-3 pb-3"" id=""map""></div>
<script>
    var map;
    function initMap() {        
        map = new google.maps.Map(document.getElementById('map'), {
            zoom: 10,
            streetViewControl: false,
            fullscreenControl: false,
            maxZoom: 10,
            minZoom: 2,
            restriction: {
                latLngBounds: {
                    north: 85,
                    south: -85,
                    west: -180,
                    east: 180
                }
            }
        });
        //sets map to bermuda triangle if location is blocked, or while waiting for approval
        map.setCenter({ lat: 25, lng: -71 });      
        
        //else grabs location
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };
           ");
            WriteLiteral(@"     map.setCenter(pos);
            });
        }

        var eden = { lat: 32.819813, lng: -117.138764 };
        var marker = new google.maps.Marker({ position: eden, map: map });
                
        var latArray = [];
        var lonArray = [];
        var imgPath = [];
              
");
#nullable restore
#line 43 "C:\Users\WWStudent\Source\Repos\gerard-rappa\MSSA-Project\TacoBoutIt\TacoBoutIt\Views\Map\Index.cshtml"
         foreach(var taco in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("latArray.push(");
#nullable restore
#line 45 "C:\Users\WWStudent\Source\Repos\gerard-rappa\MSSA-Project\TacoBoutIt\TacoBoutIt\Views\Map\Index.cshtml"
                       Write(taco.Latitude);

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n            ");
            WriteLiteral("lonArray.push(");
#nullable restore
#line 46 "C:\Users\WWStudent\Source\Repos\gerard-rappa\MSSA-Project\TacoBoutIt\TacoBoutIt\Views\Map\Index.cshtml"
                       Write(taco.Longitude);

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n            ");
            WriteLiteral("imgPath.push(\"");
#nullable restore
#line 47 "C:\Users\WWStudent\Source\Repos\gerard-rappa\MSSA-Project\TacoBoutIt\TacoBoutIt\Views\Map\Index.cshtml"
                       Write(taco.ImgUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n");
#nullable restore
#line 48 "C:\Users\WWStudent\Source\Repos\gerard-rappa\MSSA-Project\TacoBoutIt\TacoBoutIt\Views\Map\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"0

        for (var i = 0; i < latArray.length; i++) {
            addMarker({
                coords: { lat: latArray[i], lng: lonArray[i] },
                content: '<img style=""max-width:100px; width:100%"" src=https://litmemes.blob.core.windows.net/images/'+imgPath[i]+' /img>'
            });


            
        }


    }
    
    //google.maps.event.addListener(map, 'click', function(event) {
    //         placeMarker(event.latLng);
    //    });

    function addMarker(props) {
        var marker = new google.maps.Marker({
            position: props.coords,            
            map: map
        });
        var window = new google.maps.InfoWindow({
            content: props.content
        });
        marker.addListener('click', function () {
            window.open(map, marker);
        });
    }
    

    function placeMarker(location) {
        var marker = new google.maps.Marker({
            position: location,
            map: map
        });
    }
</");
            WriteLiteral("script>\r\n<script async defer\r\n        src=\"https://maps.googleapis.com/maps/api/js?key=AIzaSyDBBSbNYenx3aUVJNQDujBpzACQcnJHfSg&callback=initMap\">\r\n</script>");
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
