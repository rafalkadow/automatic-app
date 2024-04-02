namespace Domain.Requests.Identity
{
    public class ToggleUserStatusRequest
    {
        public bool ActivateUser { get; set; }
        public Guid UserId { get; set; }
    }
}