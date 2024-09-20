using TaskTrackerCLI.Models;
using Task = TaskTrackerCLI.Models.Task;

namespace TaskTrackerCLI
{
    class Program
    {
        static TaskRepository taskRepo = new();
        static List<Task> tasks = [];

        static void Main(string[] args)
        {
            tasks = taskRepo.LoadTasks();

            if (args.Length == 0)
            {
                Console.WriteLine("No command provided.");
                return;
            }

            switch (args[0].ToLower())
            {
                case "add":
                    AddTask(args);
                    break;
                case "update":
                    UpdateTask(args);
                    break;
                case "delete":
                    DeleteTask(args);
                    break;
                case "mark-in-progress":
                    MarkTaskStatus(args, "in-progress");
                    break;
                case "mark-done":
                    MarkTaskStatus(args, "done");
                    break;
                case "list":
                    ListTasks(args);
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }

            taskRepo.SaveTasks(tasks);
        }

        static void AddTask(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please provide a task description.");
                return;
            }

            var task = new Task
            {
                Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
                Description = args[1],
                Status = "todo",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            tasks.Add(task);
            Console.WriteLine($"Task added successfully (ID: {task.Id})");
        }

        static void UpdateTask(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Please provide a task ID and description.");
                return;
            }

            if (int.TryParse(args[1], out int taskId))
            {
                var task = tasks.FirstOrDefault(t => t.Id == taskId);
                if (task != null)
                {
                    task.Description = args[2];
                    task.UpdatedAt = DateTime.Now;
                    Console.WriteLine("Task updated successfully.");
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        static void DeleteTask(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please provide a task ID.");
                return;
            }

            if (int.TryParse(args[1], out int taskId))
            {
                var task = tasks.FirstOrDefault(t => t.Id == taskId);
                if (task != null)
                {
                    tasks.Remove(task);
                    Console.WriteLine("Task deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        static void MarkTaskStatus(string[] args, string status)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please provide a task ID.");
                return;
            }

            if (int.TryParse(args[1], out int taskId))
            {
                var task = tasks.FirstOrDefault(t => t.Id == taskId);
                if (task != null)
                {
                    task.Status = status;
                    task.UpdatedAt = DateTime.Now;
                    Console.WriteLine($"Task marked as {status}.");
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        static void ListTasks(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("All tasks:");
                foreach (var task in tasks)
                {
                    PrintTask(task);
                }
            }
            else
            {
                var status = args[1].ToLower();
                var filteredTasks = tasks.Where(t => t.Status == status).ToList();

                if (filteredTasks.Count == 0)
                {
                    Console.WriteLine($"No tasks with status '{status}' found.");
                    return;
                }

                Console.WriteLine($"Tasks with status '{status}':");
                foreach (var task in filteredTasks)
                {
                    PrintTask(task);
                }
            }
        }

        static void PrintTask(Task task)
        {
            Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Status: {task.Status}, CreatedAt: {task.CreatedAt}, UpdatedAt: {task.UpdatedAt}");
        }
    }
}
