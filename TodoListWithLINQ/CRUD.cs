using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListWithLINQ
{
    // Class for managing CRUD operations on tasks
    public class CRUD
    {
        // Static list to hold all tasks
        static List<Task> tasks = new List<Task>
        {
            new Task { Id = 1, Title = "Buy groceries", Description = "Buy vegetables and fruits", DueDate = DateTime.Now.AddDays(1), Priority = "High", Status = "Pending" },
            new Task { Id = 2, Title = "Complete project", Description = "Finish the coding project for work", DueDate = DateTime.Now.AddDays(2), Priority = "Medium", Status = "In Progress" },
            new Task { Id = 3, Title = "Clean the house", Description = "Tidy up the living room and kitchen", DueDate = DateTime.Now.AddDays(3), Priority = "Low", Status = "Pending" }
        };

        // Method to add a new task to the list
        public void AddTask(Task task)
        {
            tasks.Add(task);
            Console.WriteLine($"\nTask '{task.Title}' has been added.");
        }

        // Method to edit an existing task by its ID
        public void EditTask(int taskId, string newTitle, string newDescription, string newPriority, string newStatus)
        {
            var task = tasks.FirstOrDefault(x => x.Id == taskId); // Find the task by ID
            if (task != null)
            {
                task.Title = newTitle;
                task.Description = newDescription;
                task.Priority = newPriority;
                task.Status = newStatus;
                Console.WriteLine($"\nTask '{taskId}' has been updated.");
            }
            else
            {
                Console.WriteLine("\nTask not found."); // If task not found
            }
        }

        // Method to delete a task by its ID
        public void DeleteTask(int taskId)
        {
            var task = tasks.FirstOrDefault(x => x.Id == taskId); // Find the task by ID

            if (task != null)
            {
                tasks.Remove(task); // Remove the task
                Console.WriteLine($"\nTask '{taskId}' has been deleted.");
            }
            else
            {
                Console.WriteLine("\nTask not found."); // If task not found
            }
        }

        // Method to mark a task as completed by its ID
        public void MarkAsCompleted(int taskId)
        {
            var task = tasks.FirstOrDefault(x => x.Id == taskId); // Find the task by ID
            if (task != null)
            {
                task.Status = "Completed"; // Update the status to 'Completed'
                Console.WriteLine($"\nTask '{taskId}' has been marked as completed.");
            }
            else
            {
                Console.WriteLine("\nTask not found."); // If task not found
            }
        }

        // Method to display all current tasks
        public void DisplayTasks()
        {
            Console.WriteLine("\nCurrent Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Status: {task.Status}, Priority: {task.Priority}, DueDate: {task.DueDate.ToShortDateString()}");
            }
        }
    }
}
