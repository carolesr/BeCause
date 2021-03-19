using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.Entities
{
    public class Account
    {
        public Guid IdAccount { get; set; }
        public string Bank { get; set; }
        public int Number { get; set; }
        public int Agency { get; set; }
        public string OwnerName { get; set; }
        public string OwnerCPF { get; set; }
    }
}
