using Elsa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa.Attributes;
using Elsa.Expressions;
using Elsa.Providers.WorkflowStorage;
using Elsa.RD.BusinessLibrary;
using Elsa.ActivityResults;
using Elsa.Services.Models;

namespace Elsa.RD.ActivityLibrary.Activities
{
    [Action(Category = "Customer OnBoarding", Description = "Customer onboarding activity to add customer contact details")]
    public class AddContactDetails :Activity
    {
        [ActivityInput(
           Label = "PersonEdit",
           Hint = "The customer to add contact details",
           SupportedSyntaxes = new[] { SyntaxNames.JavaScript, SyntaxNames.Liquid },
           DefaultWorkflowStorageProvider = TransientWorkflowStorageProvider.ProviderName
       )]
        public PersonEdit Person { get; set; } = default!;

        [ActivityInput(Hint = "Enter an expression that evaluates to the addressline 1 of the customer")]
        public string AddressLine1 { get; set; } = default!;

        
        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            Person = context.GetInput<PersonEdit>()!;
            Person.AddressLine1=AddressLine1;
            return Done();
        }
    }
}
