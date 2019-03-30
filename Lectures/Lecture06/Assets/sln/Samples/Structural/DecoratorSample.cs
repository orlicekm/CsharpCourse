using System;
using System.Collections.Generic;

namespace Samples.Structural
{
    public class DecoratorSample
    {
        public static void Main()
        {
            // Create book
            var book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            // Create video
            var video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("\nMaking video borrowable:");
            var borrowVideo = new Borrowable(video);
            borrowVideo.BorrowItem("Customer #1");
            borrowVideo.BorrowItem("Customer #2");
            borrowVideo.Display();
        }
    }

    internal abstract class LibraryItem
    {
        public int NumCopies { get; set; }

        public abstract void Display();
    }

    internal class Book : LibraryItem
    {
        private readonly string author;
        private readonly string title;

        public Book(string author, string title, int numCopies)
        {
            this.author = author;
            this.title = title;
            NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine($" Author: {author}");
            Console.WriteLine($" Title: {title}");
            Console.WriteLine($" # Copies: {NumCopies}");
        }
    }

    internal class Video : LibraryItem
    {
        private readonly string director;
        private readonly int playTime;
        private readonly string title;

        public Video(string director, string title,
            int numCopies, int playTime)
        {
            this.director = director;
            this.title = title;
            NumCopies = numCopies;
            this.playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", director);
            Console.WriteLine(" Title: {0}", title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", playTime);
        }
    }

    internal abstract class Decorator : LibraryItem
    {
        protected LibraryItem libraryItem;

        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        public override void Display()
        {
            libraryItem.Display();
        }
    }

    internal class Borrowable : Decorator
    {
        protected List<string> borrowers = new List<string>();

        public Borrowable(LibraryItem libraryItem)
            : base(libraryItem)
        {
        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.NumCopies++;
        }

        public override void Display()
        {
            base.Display();
            foreach (var borrower in borrowers) Console.WriteLine(" borrower: " + borrower);
        }
    }
}