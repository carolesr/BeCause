using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.Entities.Filters
{
    public class UserFilter
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
