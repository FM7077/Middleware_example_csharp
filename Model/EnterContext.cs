namespace Middleware
{
    public class EnterContext
    {
        public string name{get; set;}
        public bool has24HourHealthCode{get; set;}
        public bool isFromHighRiskArea{get; set;}
        public string refuseReason{get; set;}
    }
}