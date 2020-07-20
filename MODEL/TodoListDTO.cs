using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class TodoListDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public long CategoryId { get; set; }

        public TodoListStatus Status { get; set; }
    }
}
