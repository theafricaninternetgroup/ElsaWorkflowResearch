using Elsa.Activities.Console;
using Elsa.Builders;
using Elsa.RD.ActivityLibrary.Activities;
using Elsa.RD.BusinessLibrary;

namespace Elsa.RD.WfEngine.Workflows
{
    public class CustomerOnBoardingWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .StartWith<AddPersonalDetails>(a =>
                {
                    a.Set(x => x.FirstName, "Dennis");
                    a.Set(x => x.LastName, "Mwape");
                })
                .WriteLine(x => $"The full names of the new customer is {x.GetInput<PersonEdit>()!.FirstName} {x.GetInput<PersonEdit>()!.LastName}");
        }
    }
}