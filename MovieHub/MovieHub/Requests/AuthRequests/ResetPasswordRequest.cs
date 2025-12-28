namespace MovieHub.Requests.AuthRequests
{
    public class ResetPasswordRequest
    {
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }
}
