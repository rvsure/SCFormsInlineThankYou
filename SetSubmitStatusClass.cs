using Sitecore.ExperienceForms.Mvc.Pipelines.RenderForm;
using Sitecore.Mvc.Pipelines;

namespace SCMadeEasy.Feature.ExperienceFormsExtensions.Pipelines
{
    public class SetSubmitStatusClass : MvcPipelineProcessor<RenderFormEventArgs>
    {
        public override void Process(RenderFormEventArgs args)
        {
            //Check if the request post request to make sure the code executes only on form submission
            if (args.IsPost)
            {
                string responseClass = string.Empty;
                //Check if the model state is valid to confirm successful form submission
                if (args.HtmlHelper.ViewData.ModelState.IsValid)
                {
                    responseClass = "submit-success";
                }
                else
                {
                    responseClass = "submit-error";
                }
                //Make sure we are not overwriting the existing CSS classes
                args.ViewModel.CssClass += string.IsNullOrWhiteSpace(args.ViewModel.CssClass) ? responseClass : " " + responseClass;
            }
        }
    }
}
