using Foundation.Domain.Entities;
using System;

namespace UserService.Domain.Entities
{
    public class User : BaseEntity
    {
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
        public string Picture { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        //public Account Account { get; set; }
    }
}
