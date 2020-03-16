using Domain;

namespace Application.Services.Responses
{
    public class ActivityResponse : BaseResponse
    {

        public Activity Activity { get; private set; }

        private ActivityResponse(bool Status, string Message, Activity Activity) : base(Status, Message)
        {
            this.Activity = Activity;
        }

        public ActivityResponse(string Message) : this(false, Message, null) { }
        public ActivityResponse(Activity activity) : this(true, string.Empty, activity) { }
    }
}