using Elsa.RD.WfEngine.Workflows;
using Elsa.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Elsa.RD.WfEngine.Pages
{
    public class PersonModel : PageModel
    {
        private readonly IBuildsAndStartsWorkflow _invoker;
        public PersonModel(IBuildsAndStartsWorkflow invoker)
        {
            _invoker= invoker;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _invoker.BuildAndStartWorkflowAsync<CustomerOnBoardingWorkflow>();
            return Page();
        }
    }
}
