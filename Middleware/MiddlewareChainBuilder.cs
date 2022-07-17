using Autofac;
namespace Middleware
{
    public class MiddlewareChainBuilder
    {
        Dictionary<string, IMiddleware> containMiddleware = new Dictionary<string, IMiddleware>();
        public void CreateChain(IContainer container)
        {
            using(var scope = container.BeginLifetimeScope())
            {
                var has24HourHealthCode = scope.ResolveNamed<IMiddleware>("has24HourHealthCode");
                var isFromHighRiskArea = scope.ResolveNamed<IMiddleware>("isFromHighRiskArea");
                var enter = scope.ResolveNamed<IMiddleware>("enter");
                var refuse = scope.ResolveNamed<IMiddleware>("refuse");

                has24HourHealthCode.SetNext("has24HourHealthCode", isFromHighRiskArea);
                has24HourHealthCode.SetNext("notHas24HourHealthCode", refuse);

                isFromHighRiskArea.SetNext("isFromHighRiskArea", refuse);
                isFromHighRiskArea.SetNext("isNotFromHighRiskArea", enter);
            }
        }
    }
}