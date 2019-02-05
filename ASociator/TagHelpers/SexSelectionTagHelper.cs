using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.TagHelpers
{
    public class SexSelectionTagHelper: SelectTagHelper
    {
        public SexSelectionTagHelper(IHtmlGenerator generator) : base(generator) {
            Items = new List<SelectListItem>() { new SelectListItem("Male", "Male"), new SelectListItem("Female", "Female") };            
        }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            output.TagName = "select";
            
        }
    }
}
