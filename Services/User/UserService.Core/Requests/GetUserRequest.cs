using Foundation.Core.Requests;

namespace UserService.Core.Requests
{
    public class GetUserRequest : Request
    {
        public bool ActiveOnly { get; set; }
    }
}
