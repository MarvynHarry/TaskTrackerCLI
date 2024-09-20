using System.Text.Json;

namespace TaskTrackerCLI.Models
{
    public class TaskRepository
    {
        private const string FilePath = "tasks.json";

        public List<Task> LoadTasks()
        {
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, "[]");
            }

            var jsonData = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Task>>(jsonData) ?? new List<Task>();
        }

        public void SaveTasks(List<Task> tasks)
        {
            var jsonData = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, jsonData);
        }
    }
}
