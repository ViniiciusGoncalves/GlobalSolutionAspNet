using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GlobalSolution.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "asp-type")]
    public class ButtonTagHelper : TagHelper
    {
        public string AspType { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";  
            output.TagMode = TagMode.StartTagAndEndTag; 

            output.Attributes.SetAttribute("type", string.IsNullOrEmpty(AspType) ? "button" : AspType);

            if (!output.Attributes.ContainsName("class"))
            {
                output.Attributes.Add("class", "btn btn-primary");
            }

            output.Attributes.SetAttribute("style", "margin-top: 20px;");
        }
    }
}
