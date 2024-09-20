# Task Tracker CLI

A simple command-line interface (CLI) tool built in C# to manage tasks. This application allows you to add, update, delete, and track tasks, with statuses such as "todo", "in-progress", and "done". Tasks are stored in a local JSON file for persistence. Sample solution for the [Task Tracker](https://roadmap.sh/projects/task-tracker) challenge from [roadmap.sh](https://roadmap.sh/).

## Features

- **Add** a new task with a description.
- **Update** an existing task's description.
- **Delete** a task by ID.
- **Mark** a task as "in-progress" or "done".
- **List** tasks by status or view all tasks.

## Task Properties

Each task includes:
- **ID**: A unique identifier.
- **Description**: A short description of the task.
- **Status**: One of "todo", "in-progress", or "done".
- **CreatedAt**: Timestamp when the task was created.
- **UpdatedAt**: Timestamp when the task was last updated.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/task-tracker-cli.git
    cd task-tracker-cli
    ```

2. Build the project:
    ```bash
    dotnet build
    ```

3. Run the project:
    ```bash
    dotnet run
    ```

## Usage

### Add a new task
```bash
dotnet run add "Buy groceries"
```

### Update an existing task
```bash
dotnet run update 1 "Buy groceries and cook dinner"
```

### Delete a task
```bash
dotnet run delete 1
```

### Mark a task as in progress
```bash
dotnet run mark-in-progress 1
```

### Mark a task as done
```bash
dotnet run mark-done 1
```

### List all tasks
```bash
dotnet run list
```

### List tasks by status
```bash
dotnet run list done
dotnet run list todo
dotnet run list in-progress
```

### JSON File

The tasks are saved in a tasks.json file in the project directory. This file will be created automatically if it does not exist.

## Support My Work
If you enjoy my work or want to support what I do, feel free to [Buy Me a Coffee](https://buymeacoffee.com/marvynharry)!

## Contributing
Feel free to submit a pull request or report issues to help improve the project!

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact
For any questions or support, please reach out via [GitHub Issues](https://github.com/MarvynHarry/github-user-activity/issues).
