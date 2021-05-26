using Foundation.Core.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Core.Requests
{
    public class GetUserRequest : Request
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
