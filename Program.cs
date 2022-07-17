using Autofac;
namespace Middleware
{
    public class Middleware
    {
        private static IContainer Container = null;
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Has24HourHealthCode>().Named<IMiddleware>("has24HourHealthCode").SingleInstance();
            builder.RegisterType<IsFromHighRiskAreaMiddleware>().Named<IMiddleware>("isFromHighRiskArea").SingleInstance();
            builder.RegisterType<RefuseMiddleware>().Named<IMiddleware>("refuse").SingleInstance();
            builder.RegisterType<EnterMiddleware>().Named<IMiddleware>("enter").SingleInstance();
            Container = builder.Build();
            new MiddlewareChainBuilder().CreateChain(Container);
            using(var scope = Container.BeginLifetimeScope())
            {
                var has24HourHealthCode = scope.ResolveNamed<IMiddleware>("has24HourHealthCode");
                
                for(int i = 0; i < 10; i++)
                {
                    var enter = new EnterContext()
                    {
                        name = "张三",
                        has24HourHealthCode = new Random().Next(2) == 1,
                        isFromHighRiskArea = new Random().Next(2) == 1,
                    };
                    Console.WriteLine($"hhc: {enter.has24HourHealthCode}, ifhra: {enter.isFromHighRiskArea}");
                    has24HourHealthCode.Process(enter);
                }
            }
        }
    }
}