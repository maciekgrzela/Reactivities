namespace Application.Services.Responses
{
    public abstract class BaseResponse
    {

        public bool Status { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool Status, string Message)
        {
            this.Status = Status;
            this.Message = Message;
        }
    }
}