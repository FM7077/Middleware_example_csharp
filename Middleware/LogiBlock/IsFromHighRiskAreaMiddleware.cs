namespace Middleware
{
    public class IsFromHighRiskAreaMiddleware : IMiddleware
    {
        IMiddleware _isFromHighRiskArea;
        IMiddleware _isNotFromHighRiskArea;
        public string Code{get; set;}
        public void Process(EnterContext context)
        {
            if(context.isFromHighRiskArea)
            {
                context.refuseReason = "You are from high risk area";
                _isFromHighRiskArea.Process(context);
            }else
            {
                _isNotFromHighRiskArea.Process(context);
            }
        }

        public void SetNext(string status, IMiddleware next)
        {
            switch(status)
            {
                case "isFromHighRiskArea":
                    _isFromHighRiskArea = next; break;
                case "isNotFromHighRiskArea":
                    _isNotFromHighRiskArea = next; break;
                default:
                    throw new Exception("Unknow middleware");
            }
        }
    }
}