// Assignment: Indvidual Project: Todo List  
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com

namespace TodoList
{
    internal class ProgramStates
    {

        private List<TodoItem> TodoItems;
        public ProgramStates(List<TodoItem> todoItems)
        {
            TodoItems = todoItems;
        }

        public void StartMenu()
        {
            int totalTasks = TodoItems.Count;
            int completedTasks = TodoItems.Count(s => s.IsDone);
            Console.WriteLine(">> Welcome to ToDoLy");
            Console.WriteLine($">> You have {totalTasks} tasks todo and {completedTasks} tasks are done!");
            MainMenu();
        }
        public void MainMenu()
        {
            while (true)
            {
                Console.WriteLine(">> Pick an option:");
                Console.WriteLine(">> (1) Show Task List");
                Console.WriteLine(">> (2) Add New Task");
                Console.WriteLine(">> (3) Quit");
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.KeyChar)
                {
                    case '1':
                        ShowTaskListMenu();
                        break;
                    case '2':
                        AddNewTaskMenu();
                        break;
                    case '3':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(">> Invalid option. Please try again.");
                        break;
                }
            }
        }
        public void ShowTaskListMenu()
        {

            ShowTaskList(true);
            while (true)
            {
                Console.WriteLine(">> Pick an option:");
                Console.WriteLine(">> (1) Sort by Date.");
                Console.WriteLine(">> (2) Sort by Project.");
                Console.WriteLine(">> (3) Add New Task.");
                Console.WriteLine(">> (4) Update Task.");
                Console.WriteLine(">> (5) Make task as done.");
                Console.WriteLine(">> (6) Remove Task.");
                Console.WriteLine(">> (7) Back to Main Menu.");
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.KeyChar)
                {
                    case '1':
                        ShowTaskList(true);
                        break;
                    case '2':
                        ShowTaskList(false);
                        break;
                    case '3':
                        AddNewTaskMenu();
                        break;
                    case '4':
                        UpdateTaskMenu();
                        break;
                    case '5':
                        MakeTaskAsDone();
                        break;
                    case '6':
                        RemoveTask();
                        break;
                    case '7':
                        MainMenu();
                        return;
                    default:
                        Console.WriteLine(">> Invalid option. Please try again.");
                        break;
                }
            }
        }
        public void ShowTaskList(bool sortByDate)
        {
            if (sortByDate)
            {
                TodoItems = TodoItems.OrderBy(d => d.DueDate).ToList();
            }
            else
            {
                TodoItems = TodoItems.OrderBy(p => p.ProjectName).ToList();
            }
            if (TodoItems.Count == 0)
            {
                Console.WriteLine(">> No tasks to show.");
                return;
            }
            Console.WriteLine(">> {0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "Index", "Project Name", "Done", "Task Title", "DueDate");
            Console.WriteLine(">> {0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "-----", "------------", "----", "----------", "-------");
            for (int i = 0; i < TodoItems.Count; i++)
            {
                Console.WriteLine(">> {0,-20} {1,-20} {2,-20} {3,-20} {4,-20}",
                    i, TodoItems[i].ProjectName, TodoItems[i].IsDone, 
                    TodoItems[i].TaskTitle, TodoItems[i].DueDate.ToString("yyyy-MM-dd"));
            }
        }
        public void AddNewTaskMenu()
        {
            while (true)
            {
                Console.WriteLine(">> Add New Task.");
                Console.WriteLine(">> Please enter the task details");
                Console.Write(">> Task Title: ");
                string taskTitle = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(taskTitle))
                {
                    Console.WriteLine("Task Title cannot be empty.");
                    continue;
                }
                Console.Write(">> Due Date (yyyy-MM-dd): ");
                string dueDate = Console.ReadLine()?.Trim() ?? string.Empty;
                if (!DateTime.TryParse(dueDate, out DateTime parsedDueDate))
                {
                    Console.WriteLine("Invalid Due Date format. Please use yyyy-MM-dd.");
                    continue;
                }
                Console.Write(">> Project Name: ");
                string projectName = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(projectName))
                {
                    Console.WriteLine("Project Name cannot be empty.");
                    continue;
                }
                Console.WriteLine(">> (1) Save Task.");
                Console.WriteLine(">> (2) Back to Main Menu.");
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.KeyChar)
                {
                    case '1':
                        TodoItem todoItem = new TodoItem(taskTitle, parsedDueDate, false, projectName);
                        TodoItems.Add(todoItem);    
                        Console.WriteLine(">> Task saved.");
                        MainMenu();
                        break;
                    case '2':
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine(">> Invalid input. Please try again.");
                        break;
                }
            }
        }

        public void UpdateTaskMenu()
        {
            int totalTasks = TodoItems.Count;
            while (true)
            {
                Console.Write(">> Select Task to update: ");
                string taskIndex = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(taskIndex))
                {
                    Console.WriteLine("Task Index cannot be empty.");
                    continue;
                }
                if (!int.TryParse(taskIndex, out int index))
                {
                    Console.WriteLine("Input is not a number.");
                    continue;
                }
                if ((index < 0) || (index >= totalTasks))
                {
                    Console.WriteLine("Input is an invalid number.");
                    continue;
                }
                Console.WriteLine(">> Please update the task details");
                Console.Write($">> Task Title ({TodoItems[index].TaskTitle}): ");
                string taskTitle = Console.ReadLine()?.Trim() ?? TodoItems[index].TaskTitle;
                if (string.IsNullOrWhiteSpace(taskTitle))
                {
                    taskTitle = TodoItems[index].TaskTitle;
                }
                Console.Write($">> Due Date ({TodoItems[index].DueDate.ToString("yyyy-MM-dd")}): ");
                string? dueDate = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(dueDate))
                {
                    dueDate = TodoItems[index].TaskTitle = TodoItems[index].DueDate.ToString("yyyy-MM-dd");
                }
                if (!DateTime.TryParse(dueDate, out DateTime parsedDueDate))
                {
                    Console.WriteLine("Invalid Due Date format. Please use yyyy-MM-dd.");
                    continue;
                }
                Console.Write($">> Project Name ({TodoItems[index].ProjectName}): ");
                string? projectName = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(projectName))
                {
                    projectName = TodoItems[index].ProjectName;
                }
                Console.WriteLine(">> (1) Update Task.");
                Console.WriteLine(">> (2) Back to Main Menu.");
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.KeyChar)
                {
                    case '1':
                        TodoItem todoItem = new TodoItem(taskTitle, parsedDueDate, TodoItems[index].IsDone, projectName);
                        TodoItems[index] = todoItem;
                        Console.WriteLine(">> Task updated.");
                        MainMenu();
                        break;
                    case '2':
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine(">> Invalid input. Please try again.");
                        break;
                }
            }
        }

        public void MakeTaskAsDone()
        {
            int totalTasks = TodoItems.Count;
            while (true)
            {
                Console.Write(">> Select Task to mark as done: ");
                string taskIndex = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(taskIndex))
                {
                    Console.WriteLine("Task Index cannot be empty.");
                    continue;
                }
                if (!int.TryParse(taskIndex, out int index))
                {
                    Console.WriteLine("Input is not a number.");
                    continue;
                }
                if ((index < 0) || (index >= totalTasks))
                {
                    Console.WriteLine("Input is an invalid number.");
                    continue;
                }
                Console.WriteLine(">> (1) Mark task as done.");
                Console.WriteLine(">> (2) Back to Main Menu.");
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.KeyChar)
                {
                    case '1':
                        TodoItems[index].IsDone = true;
                        Console.WriteLine(">> Task updated");
                        MainMenu();
                        break;
                    case '2':
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine(">> Invalid option. Please try again.");
                        break;
                }
            }
        }
        public void RemoveTask()
        {
            int totalTasks = TodoItems.Count;
            while (true)
            {
                Console.Write(">> Select Task to remove: ");
                string taskIndex = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(taskIndex))
                {
                    Console.WriteLine("Task Index cannot be empty");
                    continue;
                }
                if (!int.TryParse(taskIndex, out int index))
                {
                    Console.WriteLine("Input is not a number");
                    continue;
                }
                if ((index < 0) || (index >= totalTasks))
                {
                    Console.WriteLine("Input is an invalid number");
                    continue;
                }
                Console.WriteLine(">> (1) Remove Task");
                Console.WriteLine(">> (2) Back to Main Menu");
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.KeyChar)
                {
                    case '1':
                        TodoItems.RemoveAt(int.Parse(taskIndex));
                        Console.WriteLine(">> Task Removed.");
                        MainMenu();
                        break;
                    case '2':
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine(">> Invalid option. Please try again.");
                        break;

                }
            }
        }

    }
}