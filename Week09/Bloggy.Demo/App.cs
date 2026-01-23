using System;
using System.Collections.Generic;
using Bloggy.Demo.Domain;

namespace Bloggy.Demo
{
    public class App
    {
        DataAccess _dataAccess = new DataAccess();

        public void Run()
        {
            // _dataAccess.InitDatabase();
            // Console.WriteLine("Database initialized. Press any key to exit.");
            PageMainMenu();

        }

        private void PageMainMenu()
        {
            Header("Main menu");

            ShowAllBlogPostsBrief();

            WriteLine("Select task?");
            WriteLine("a) Main menu");
            WriteLine("b) Add a blog post");
            WriteLine("c) Update a blog post");
            WriteLine("d) Delete a blog post");
            WriteLine("e) Exit application");

            ConsoleKey command = Console.ReadKey(true).Key;

            switch (command)
            {
                case ConsoleKey.A:
                    PageMainMenu(); ;
                    break;
                case ConsoleKey.B:
                    PageAddPost();
                    break;
                case ConsoleKey.C:
                    PageUpdatePost();
                    break;
                case ConsoleKey.D:
                    PageDeletePost();
                    break;
                case ConsoleKey.E:
                    return;
                    break;
                default:
                    Write("Only keys a-e or A-E are valid.");
                    Console.ReadKey();
                    PageMainMenu();
                    break;
            }

        }

        private void PageAddPost()
        {
            Header("Add a blog post");
            BlogPost blogpost = new BlogPost();
            ShowAllBlogPostsBrief();
            Write("Enter title: ");
            blogpost.Title = Console.ReadLine();
            Write("Enter author: ");
            blogpost.Author = Console.ReadLine();
            _dataAccess.AddBlogPost(blogpost);
            Write("Blog post is added.");
            Console.ReadKey();
            PageMainMenu();
        }
        private void PageUpdatePost()
        {
            Header("Update a blog post");
            ShowAllBlogPostsBrief();
            Write("Which blog post do you want to update? ");
            int postId = int.Parse(Console.ReadLine());
            BlogPost blogpost = _dataAccess.GetPostById(postId);
            WriteLine("Current title is: " + blogpost.Title);
            Write("Enter new title: ");
            string newTitle = Console.ReadLine();
            blogpost.Title = newTitle;

            WriteLine("Current author is: " + blogpost.Author);
            Write("Enter new author: ");
            string newAuthor = Console.ReadLine();
            blogpost.Author = newAuthor;
            _dataAccess.UpdateBlogPost(blogpost);
            Write("Blog post is updated.");
            Console.ReadKey();
            PageMainMenu();
        }

        private void PageDeletePost()
        {
            Header("Delete a blog post");
            ShowAllBlogPostsBrief();
            Write("Which blog post do you want to delete? ");
            int DeletePostById = int.Parse(Console.ReadLine());
            _dataAccess.DeletePostById(DeletePostById);
            Write("Blog post is deleted.");
            Console.ReadKey();
            PageMainMenu();
        }

        private void ShowAllBlogPostsBrief()
        {
            List<BlogPost> list = _dataAccess.GetAllBlogPostsBrief();

            foreach (BlogPost bp in list)
            {
                WriteLine(bp.Id.ToString().PadRight(5) + bp.Title.PadRight(50) + bp.Author.PadRight(20));
            }
            WriteLine();
        }

        private void Header(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
        }

        private void WriteLine(string text = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }

        private void Write(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
        }
    }
}
