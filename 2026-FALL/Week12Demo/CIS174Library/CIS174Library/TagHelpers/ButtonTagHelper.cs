using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174Library.TagHelpers
{
    public class ButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "btn btn-primary");
            output.Attributes.SetAttribute("Evan", "Awesome");
        }
    }
}
