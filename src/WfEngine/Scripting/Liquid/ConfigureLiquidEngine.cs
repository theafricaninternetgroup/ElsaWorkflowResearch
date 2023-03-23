using Elsa.RD.BusinessLibrary;
using Elsa.Scripting.Liquid.Messages;
using Fluid;
using MediatR;
using System.Threading.Tasks;

namespace Elsa.RD.WfEngine.Scripting.Liquid
{
    public class ConfigureLiquidEngine :INotificationHandler<EvaluatingLiquidExpression>    
    {
        public Task Handle(EvaluatingLiquidExpression notification,CancellationToken cancellationToken)
        {
            var memberAccessStrategy=notification.TemplateContext.Options.MemberAccessStrategy;
            memberAccessStrategy.Register<PersonEdit>();
            return Task.CompletedTask;
        }
    }
}
