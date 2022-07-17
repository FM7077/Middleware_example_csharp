namespace Middleware
{
    public class EnterMiddleware : IMiddleware
    {
        public string Code{get; set;}
        public void Process(EnterContext context)
        {
            Console.WriteLine($"Congratulation {context.name}, you may enter the building now");
        }

        public void SetNext(string status, IMiddleware next)
        {
            // final middleware need not to setnext
        }
    }
}