using System;

namespace UserService.Domain.Entities
{
    public class User
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
        public string Picture { get; set; }

        public Account Account { get; set; }
        public Location Location { get; set; }
    }
}
