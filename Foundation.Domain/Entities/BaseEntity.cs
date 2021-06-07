using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int IdResponsible { get; set; } // qual o melhor nome para o user responsavel?
    }
}
