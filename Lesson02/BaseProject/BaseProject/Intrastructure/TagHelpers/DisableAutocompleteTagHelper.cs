using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Intrastructure.TagHelpers
{
    [HtmlTargetElement("form", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class DisableAutocompleteTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!context.AllAttributes.Any(a => (a.Name == "autocomplete" && a.Value.ToString() == "on")))

            {
                output.Attributes.SetAttribute("autocomplete", "off");
            }
        }
    }
}
