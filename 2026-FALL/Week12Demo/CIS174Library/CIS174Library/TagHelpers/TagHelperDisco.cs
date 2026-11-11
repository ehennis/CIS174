using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week13.TagHelpers
{
    public class LabelTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("Evan", "All Labels");
        }
    }

    [HtmlTargetElement("label")]
    public class MyLabelTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("Evan2", "All Labels from Attribute");
        }
    }
    [HtmlTargetElement("label", Attributes = "asp-for", ParentTag = "form")]
    public class FormLabelTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("Evan3", "Labels with asp-for");
        }
    }
}
