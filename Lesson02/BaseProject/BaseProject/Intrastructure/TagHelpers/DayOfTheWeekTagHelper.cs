using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Intrastructure.TagHelpers
{
    [HtmlTargetElement("day-of-week", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class DayOfTheWeekTagHelper : TagHelper
    {
        private readonly DateTimeProvider _dateTimeProvider = new DateTimeProvider();
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetContent(_dateTimeProvider.Now.DayOfWeek.ToString());
        }
    }
}
