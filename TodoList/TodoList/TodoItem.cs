// Assignment: Indvidual Project: Todo List  
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com

namespace TodoList
{
    internal class TodoItem
    {
        public string TaskTitle { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
        public string ProjectName { get; set; }
 
        public TodoItem(string taskTitle, DateTime dueDate, bool isDone, string projectName)
        {
            TaskTitle = taskTitle;
            DueDate = dueDate;
            IsDone = isDone;
            ProjectName = projectName;
        }
    }
}