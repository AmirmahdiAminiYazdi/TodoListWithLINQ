using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListWithLINQ
{
    // Class for demonstrating relationships (JOINs) between tasks and categories
    public class Relationship
    {
        // Static list of tasks
        static List<Task> tasks = new List<Task>
        {
            new Task { Id = 1, Title = "Buy groceries", Description = "Buy vegetables and fruits", DueDate = DateTime.Now.AddDays(1), Priority = "High", Status = "Pending" },
            new Task { Id = 2, Title = "Complete project", Description = "Finish the coding project for work", DueDate = DateTime.Now.AddDays(2), Priority = "Medium", Status = "In Progress" },
            new Task { Id = 3, Title = "Clean the house", Description = "Tidy up the living room and kitchen", DueDate = DateTime.Now.AddDays(3), Priority = "Low", Status = "Pending" }
        };

        // Static list of categories
        static List<Category> categories = new List<Category>
        {
            new Category { CategoryId = 1, CategoryName = "Household" },
            new Category { CategoryId = 2, CategoryName = "Work" }
        };

        // Perform an INNER JOIN operation
        public void InnerJoin()
        {
            // Join tasks with categories where the IDs are related by a modulo condition
            var innerJoinResult = tasks.Join(
                categories,
                task => task.Id % 2,
                category => category.CategoryId % 2,
                (task, category) => new
                {
                    TaskID = task.Id,
                    Title = task.Title,
                    Status = task.Status,
                    CategoryName = category.CategoryName,
                });

            Console.WriteLine("\nINNER JOIN - Tasks and Categories:");
            foreach (var item in innerJoinResult)
            {
                Console.WriteLine($"Task: {item.Title}, Status: {item.Status}, Category: {item.CategoryName}");
            }
        }

        // Perform a GROUP JOIN operation
        public void GroupJoin()
        {
            // Group tasks by category and show all tasks within each category
            var groupJoinResult = categories.GroupJoin(
                tasks,
                category => category.CategoryId,
                task => task.Id % 2,
                (category, taskGroup) => new
                {
                    CategoryName = category.CategoryName,
                    Tasks = taskGroup
                });

            Console.WriteLine("\nGROUP JOIN - Grouping Tasks by Category:");
            foreach (var group in groupJoinResult)
            {
                Console.WriteLine($"Category: {group.CategoryName}");
                foreach (var task in group.Tasks)
                {
                    Console.WriteLine($"  Task: {task.Title}, Status: {task.Status}");
                }
                if (!group.Tasks.Any())
                {
                    Console.WriteLine("  No tasks in this category."); // Handle empty groups
                }
            }
        }

        // Perform a LEFT JOIN operation
        public void LeftJoin()
        {
            // Join all tasks with categories and include tasks without matching categories
            var leftJoinResult = tasks.GroupJoin(
                categories,
                task => task.Id % 2,
                category => category.CategoryId % 2,
                (task, categoryGroup) => new
                {
                    task.Id,
                    task.Title,
                    task.Status,
                    CategoryName = categoryGroup.DefaultIfEmpty().FirstOrDefault()?.CategoryName ?? "No Category" // Handle null matches
                });

            Console.WriteLine("\nLEFT JOIN - Tasks and Categories (with non-matching tasks):");
            foreach (var item in leftJoinResult)
            {
                Console.WriteLine($"Task: {item.Title}, Status: {item.Status}, Category: {item.CategoryName}");
            }
        }
    }
}
