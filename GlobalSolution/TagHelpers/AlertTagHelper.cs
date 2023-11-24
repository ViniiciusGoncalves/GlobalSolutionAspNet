using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GlobalSolution.TagHelpers
{
    public class AlertTagHelper : TagHelper
    {
        public string? AlertType { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(AlertType))
            {
                // Adicione as classes de bootstrap ao elemento div
                output.Attributes.SetAttribute("class", $"alert alert-dismissible alert-{AlertType}");

                // Renderize o conteúdo existente
                output.Content.SetContent(AlertType);

                // Adicione o botão de fechar
                output.PostContent.AppendHtml("<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\"></button>");
            }
        }
    }
}
