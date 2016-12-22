using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.app.Model
{ 

    public class TodoItem
    {
        public int TodoItemId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? CreationDate { get; set; }

        public int WillDoIn { get; set; }

        public string Tags { get; set; }

        public bool IsComplete { get; set; }

        public DateTime? CompletionDate { get; set; }
    }
}

