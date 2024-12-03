using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListWithLINQ
{
    // Represents a task with properties such as title, description, due date, etc.
    public class Task
    {
        // Unique identifier for the task
        public int Id { get; set; }

        // Title or name of the task
        public string Title { get; set; }

        // Detailed description of the task
        public string Description { get; set; }

        // Due date for the task
        public DateTime DueDate { get; set; }

        // Priority level of the task (e.g., High, Medium, Low)
        public string Priority { get; set; }

        // Current status of the task (e.g., Pending, In Progress, Completed)
        public string Status { get; set; }
    }
}
