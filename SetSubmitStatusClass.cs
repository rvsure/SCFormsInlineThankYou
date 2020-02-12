using Sitecore.ExperienceForms.Mvc.Pipelines.RenderForm;
using Sitecore.Mvc.Pipelines;

namespace SCMadeEasy.Feature.ExperienceFormsExtensions.Pipelines
{
    public class SetSubmitStatusClass : MvcPipelineProcessor<RenderFormEventArgs>
    {
        public override void Process(RenderFormEventArgs args)
        {
            if (args.IsPost)
            {
                string responseClass = string.Empty;
                if (args.HtmlHelper.ViewData.ModelState.IsValid)
                {
                    responseClass = "submit-success";
                }
                else
                {
                    responseClass = "submit-error";
                }
                args.ViewModel.CssClass += string.IsNullOrWhiteSpace(args.ViewModel.CssClass) ? responseClass : " " + responseClass;
            }
        }
    }
}