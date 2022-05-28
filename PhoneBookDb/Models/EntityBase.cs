using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookDb.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
