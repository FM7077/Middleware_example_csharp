namespace Middleware
{
    public class RefuseMiddleware : IMiddleware
    {
        public string Code{get; set;}
        public void Process(EnterContext context)
        {
            Console.WriteLine($"Sorry, you can not enter. Because {context.refuseReason}");
        }

        public void SetNext(string status, IMiddleware next)
        {
            // final middleware need not to setnext
        }
    }
}