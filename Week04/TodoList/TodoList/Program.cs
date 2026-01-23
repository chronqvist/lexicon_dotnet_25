// Assignment: Indvidual Project: Todo List  
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com

using TodoList;

List<TodoItem> todoItems = new List<TodoItem>();
TodoItem todoItem1 = new TodoItem("Mouse", new DateTime(2021, 11, 27), false, "Project M2");
todoItems.Add(todoItem1);
TodoItem todoItem2 = new TodoItem("Keyboard", new DateTime(2024, 08, 08), true, "Project L1");
todoItems.Add(todoItem2);
TodoItem todoItem3 = new TodoItem("Screen", new DateTime(2022, 03, 25), false, "Project XL3");
todoItems.Add(todoItem3);
TodoItem todoItem4 = new TodoItem("Printer", new DateTime(2019, 01, 15), false, "Project S7");
todoItems.Add(todoItem4);
TodoItem todoItem5 = new TodoItem("Scanner", new DateTime(2025, 02, 20), true, "Project M1");
todoItems.Add(todoItem5);
TodoItem todoItem6 = new TodoItem("NAS", new DateTime(2001, 06, 12), false, "Project S3");
todoItems.Add(todoItem6);


ProgramStates programStates = new ProgramStates(todoItems);
programStates.StartMenu();