using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Intrastructure.TagHelpers
{
    [HtmlTargetElement("input")]
    [HtmlTargetElement("form")]
    public class DisableAutocompleteTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context.AllAttributes.ContainsName("disable-autocomplete"))
            {
                output.Attributes.RemoveAll("disable-autocomplete");
                output.Attributes.SetAttribute("autocomplete", "off");
            }
        }

    }
}
