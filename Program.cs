using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create Variables for Books
        string book1 = "";
        string book2 = "";
        string book3 = "";
        string book4 = "";
        string book5 = "";

        // Track borrowed status for each book
        bool borrowed1 = false;
        bool borrowed2 = false;
        bool borrowed3 = false;
        bool borrowed4 = false;
        bool borrowed5 = false;

        // Track how many books the user has borrowed
        int borrowedCount = 0;
        const int maxBorrowed = 3;

        while (true)
        {
            // 4. Display the List of Books
            Console.WriteLine("\nCurrent Library:");
            int count = 0;
            if (!string.IsNullOrWhiteSpace(book1)) { Console.WriteLine($"- {book1} {(borrowed1 ? "(Borrowed)" : "")}"); count++; }
            if (!string.IsNullOrWhiteSpace(book2)) { Console.WriteLine($"- {book2} {(borrowed2 ? "(Borrowed)" : "")}"); count++; }
            if (!string.IsNullOrWhiteSpace(book3)) { Console.WriteLine($"- {book3} {(borrowed3 ? "(Borrowed)" : "")}"); count++; }
            if (!string.IsNullOrWhiteSpace(book4)) { Console.WriteLine($"- {book4} {(borrowed4 ? "(Borrowed)" : "")}"); count++; }
            if (!string.IsNullOrWhiteSpace(book5)) { Console.WriteLine($"- {book5} {(borrowed5 ? "(Borrowed)" : "")}"); count++; }
            if (count == 0) Console.WriteLine("Library is empty.");

            Console.WriteLine($"\nYou have borrowed {borrowedCount} out of {maxBorrowed} books.");

            // 5. Loop Indefinitely
            Console.WriteLine("\nChoose an action: add, remove, search, borrow, checkin, or exit");
            string action = Console.ReadLine()?.Trim().ToLower();

            if (action == "add")
            {
                // 7. Only allow adding if there are empty slots
                if (!string.IsNullOrWhiteSpace(book1) &&
                    !string.IsNullOrWhiteSpace(book2) &&
                    !string.IsNullOrWhiteSpace(book3) &&
                    !string.IsNullOrWhiteSpace(book4) &&
                    !string.IsNullOrWhiteSpace(book5))
                {
                    Console.WriteLine("No more space to add books.");
                    continue;
                }

                // 2. Add a Book
                Console.Write("Enter the title of the book to add: ");
                string newBook = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(newBook))
                {
                    Console.WriteLine("Book title cannot be empty.");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(book1)) { book1 = newBook; borrowed1 = false; }
                else if (string.IsNullOrWhiteSpace(book2)) { book2 = newBook; borrowed2 = false; }
                else if (string.IsNullOrWhiteSpace(book3)) { book3 = newBook; borrowed3 = false; }
                else if (string.IsNullOrWhiteSpace(book4)) { book4 = newBook; borrowed4 = false; }
                else if (string.IsNullOrWhiteSpace(book5)) { book5 = newBook; borrowed5 = false; }

                Console.WriteLine($"Book \"{newBook}\" added.");
            }
            else if (action == "remove")
            {
                // 7. Only allow removing if there are books
                if (string.IsNullOrWhiteSpace(book1) &&
                    string.IsNullOrWhiteSpace(book2) &&
                    string.IsNullOrWhiteSpace(book3) &&
                    string.IsNullOrWhiteSpace(book4) &&
                    string.IsNullOrWhiteSpace(book5))
                {
                    Console.WriteLine("No books to remove.");
                    continue;
                }

                // 3. Remove a Book
                Console.Write("Enter the title of the book to remove: ");
                string removeBook = Console.ReadLine()?.Trim();
                bool removed = false;

                if (!string.IsNullOrWhiteSpace(book1) && book1.Equals(removeBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed1)
                    {
                        borrowedCount--;
                    }
                    book1 = "";
                    borrowed1 = false;
                    removed = true;
                }
                else if (!string.IsNullOrWhiteSpace(book2) && book2.Equals(removeBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed2)
                    {
                        borrowedCount--;
                    }
                    book2 = "";
                    borrowed2 = false;
                    removed = true;
                }
                else if (!string.IsNullOrWhiteSpace(book3) && book3.Equals(removeBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed3)
                    {
                        borrowedCount--;
                    }
                    book3 = "";
                    borrowed3 = false;
                    removed = true;
                }
                else if (!string.IsNullOrWhiteSpace(book4) && book4.Equals(removeBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed4)
                    {
                        borrowedCount--;
                    }
                    book4 = "";
                    borrowed4 = false;
                    removed = true;
                }
                else if (!string.IsNullOrWhiteSpace(book5) && book5.Equals(removeBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed5)
                    {
                        borrowedCount--;
                    }
                    book5 = "";
                    borrowed5 = false;
                    removed = true;
                }

                if (removed)
                    Console.WriteLine($"Book \"{removeBook}\" removed.");
                else
                    Console.WriteLine($"Book \"{removeBook}\" not found.");
            }
            else if (action == "search")
            {
                // Search Feature
                Console.Write("Enter the title of the book to search for: ");
                string searchBook = Console.ReadLine()?.Trim();
                bool found = false;

                if (!string.IsNullOrWhiteSpace(book1) && book1.Equals(searchBook, StringComparison.OrdinalIgnoreCase)) found = true;
                else if (!string.IsNullOrWhiteSpace(book2) && book2.Equals(searchBook, StringComparison.OrdinalIgnoreCase)) found = true;
                else if (!string.IsNullOrWhiteSpace(book3) && book3.Equals(searchBook, StringComparison.OrdinalIgnoreCase)) found = true;
                else if (!string.IsNullOrWhiteSpace(book4) && book4.Equals(searchBook, StringComparison.OrdinalIgnoreCase)) found = true;
                else if (!string.IsNullOrWhiteSpace(book5) && book5.Equals(searchBook, StringComparison.OrdinalIgnoreCase)) found = true;

                if (found)
                    Console.WriteLine($"Book \"{searchBook}\" is available in the library.");
                else
                    Console.WriteLine($"Book \"{searchBook}\" is not in the collection.");
            }
            else if (action == "borrow")
            {
                if (borrowedCount >= maxBorrowed)
                {
                    Console.WriteLine($"You have reached the borrowing limit of {maxBorrowed} books.");
                    continue;
                }

                Console.Write("Enter the title of the book to borrow: ");
                string borrowBook = Console.ReadLine()?.Trim();
                bool borrowed = false;

                if (!string.IsNullOrWhiteSpace(book1) && book1.Equals(borrowBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed1)
                    {
                        Console.WriteLine("This book is already borrowed.");
                    }
                    else
                    {
                        borrowed1 = true;
                        borrowedCount++;
                        borrowed = true;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(book2) && book2.Equals(borrowBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed2)
                    {
                        Console.WriteLine("This book is already borrowed.");
                    }
                    else
                    {
                        borrowed2 = true;
                        borrowedCount++;
                        borrowed = true;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(book3) && book3.Equals(borrowBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed3)
                    {
                        Console.WriteLine("This book is already borrowed.");
                    }
                    else
                    {
                        borrowed3 = true;
                        borrowedCount++;
                        borrowed = true;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(book4) && book4.Equals(borrowBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed4)
                    {
                        Console.WriteLine("This book is already borrowed.");
                    }
                    else
                    {
                        borrowed4 = true;
                        borrowedCount++;
                        borrowed = true;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(book5) && book5.Equals(borrowBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed5)
                    {
                        Console.WriteLine("This book is already borrowed.");
                    }
                    else
                    {
                        borrowed5 = true;
                        borrowedCount++;
                        borrowed = true;
                    }
                }
                else
                {
                    Console.WriteLine("Book not found in the library.");
                }

                if (borrowed)
                    Console.WriteLine($"Book \"{borrowBook}\" has been borrowed.");
            }
            else if (action == "checkin")
            {
                Console.Write("Enter the title of the book to check in: ");
                string checkinBook = Console.ReadLine()?.Trim();
                bool checkedIn = false;

                if (!string.IsNullOrWhiteSpace(book1) && book1.Equals(checkinBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed1)
                    {
                        borrowed1 = false;
                        borrowedCount--;
                        checkedIn = true;
                    }
                    else
                    {
                        Console.WriteLine("This book is not currently borrowed.");
                    }
                }
                else if (!string.IsNullOrWhiteSpace(book2) && book2.Equals(checkinBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed2)
                    {
                        borrowed2 = false;
                        borrowedCount--;
                        checkedIn = true;
                    }
                    else
                    {
                        Console.WriteLine("This book is not currently borrowed.");
                    }
                }
                else if (!string.IsNullOrWhiteSpace(book3) && book3.Equals(checkinBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed3)
                    {
                        borrowed3 = false;
                        borrowedCount--;
                        checkedIn = true;
                    }
                    else
                    {
                        Console.WriteLine("This book is not currently borrowed.");
                    }
                }
                else if (!string.IsNullOrWhiteSpace(book4) && book4.Equals(checkinBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed4)
                    {
                        borrowed4 = false;
                        borrowedCount--;
                        checkedIn = true;
                    }
                    else
                    {
                        Console.WriteLine("This book is not currently borrowed.");
                    }
                }
                else if (!string.IsNullOrWhiteSpace(book5) && book5.Equals(checkinBook, StringComparison.OrdinalIgnoreCase))
                {
                    if (borrowed5)
                    {
                        borrowed5 = false;
                        borrowedCount--;
                        checkedIn = true;
                    }
                    else
                    {
                        Console.WriteLine("This book is not currently borrowed.");
                    }
                }
                else
                {
                    Console.WriteLine("Book not found in the library.");
                }

                if (checkedIn)
                    Console.WriteLine($"Book \"{checkinBook}\" has been checked in.");
            }
            else if (action == "exit")
            {
                // Exit the loop and program
                Console.WriteLine("Exiting the program.");
                break;
            }
            else
            {
                // 6. Handle Invalid Inputs
                Console.WriteLine("Invalid action. Please enter 'add', 'remove', 'search', 'borrow', 'checkin', or 'exit'.");
            }
        }
    }
}