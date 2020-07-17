using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DATA
{
    public class TodoList : BaseEntity
    {
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public long CategoryId { get; set; }

        public int Status { get; set; }
    }
}
