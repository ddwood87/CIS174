using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Views.ViewComponents
{
    public class ButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context,
            TagHelperOutput output)
        {
            TagHelperAttribute classAttribute;
            context.AllAttributes.TryGetAttribute("class", out classAttribute);
            output.Attributes.SetAttribute("class", "btn btn-primary " + classAttribute.Value);
        }
    }
}
