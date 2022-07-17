namespace Middleware
{
    public class Has24HourHealthCode : IMiddleware
    {
        IMiddleware _has24HourhealthCode;
        IMiddleware _notHas24HourhealthCode;
        public string Code{get; set;}
        public void Process(EnterContext context)
        {
            if(context.has24HourHealthCode)
            {
                _has24HourhealthCode.Process(context);
            }
            else
            {
                context.refuseReason = "You do not have 24 hour health code";
                _notHas24HourhealthCode.Process(context);
            }
        }

        public void SetNext(string status, IMiddleware next)
        {
            switch(status)
            {
                case "has24HourHealthCode":
                    _has24HourhealthCode = next; break;
                case "notHas24HourHealthCode":
                    _notHas24HourhealthCode = next; break;
                default:
                    throw new Exception("Unknow middleware");
            }
        }
    }
}