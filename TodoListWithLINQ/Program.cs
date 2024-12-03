using TodoListWithLINQ;
using Task = TodoListWithLINQ.Task;

var crud = new CRUD();
var relationship = new Relationship();

Console.WriteLine("Task Management System with JOINs");

// Perform an INNER JOIN operation to combine tasks with related data
relationship.InnerJoin();

// Perform a LEFT JOIN operation to include all tasks and related data (or default values)
relationship.LeftJoin();

// Perform a GROUP JOIN operation to group tasks based on related data
relationship.GroupJoin();

// Add a new task to the list
crud.AddTask(new Task { Id = 4, Title = "Go to the gym", Description = "Workout in the evening", DueDate = DateTime.Now.AddDays(4), Priority = "High", Status = "Pending" });

// Edit an existing task with new details
crud.EditTask(1, "Buy groceries and fruits", "Buy fresh vegetables and fruits", "High", "Completed");

// Delete a task by its ID
crud.DeleteTask(2);

// Mark a task as completed by updating its status
crud.MarkAsCompleted(3);

// Display all tasks in the system
crud.DisplayTasks();
