namespace Middleware
{
    public interface IMiddleware
    {
        public void SetNext(string status, IMiddleware next);
        public void Process(EnterContext context);
    }
}