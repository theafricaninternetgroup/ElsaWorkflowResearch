using Csla;
using System.Threading;
using System.Threading.Tasks;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa.RD.BusinessLibrary;
using Elsa.ActivityResults;
using Elsa.Providers.WorkflowStorage;

namespace Elsa.RD.ActivityLibrary.Activities
{
    [Action(Category ="Customer OnBoarding", Description="Customer onboarding activity to add customer personal details")]
    
    public class AddPersonalDetails :Activity
    {
        private readonly IDataPortal<PersonEdit> _portal;
        public AddPersonalDetails(IDataPortal<PersonEdit> portal)
        { 
            _portal = portal;
          //  Step = 1;

        }

        [ActivityInput(Hint = "Enter an expression that evaluates to the first name of the customer")]
        public string FirstName { get; set; } = default!;

        [ActivityInput(Hint = "Enter an expression that evaluates to the last name of the customer")]
        public string LastName { get; set; } = default!;

        [ActivityOutput(
        Hint = "Customer",
        DefaultWorkflowStorageProvider = TransientWorkflowStorageProvider.ProviderName)]
        public PersonEdit Output { get; set; } = default!;

       // [ActivityOutput]
       // public int Step { get;private set; }

        public override async ValueTask<IActivityExecutionResult> ExecuteAsync(ActivityExecutionContext context)
        {
            Output = await _portal.CreateAsync();
            Output.FirstName=FirstName;
            Output.LastName=LastName;
            context.LogOutputProperty(this,nameof(Output),Output);
           
            return Done();
        }

    }
}
