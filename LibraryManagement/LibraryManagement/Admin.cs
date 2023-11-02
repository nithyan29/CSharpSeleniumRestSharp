using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibraryManagement
{
    internal class Admin
    {
        int selfhelpBooksCount = 0, comicsBooksCount = 0, thrillerBooksCount = 0, biographyBooksCount = 0;

        public int SelfhelpBooksCount{ get; set; }
        string[,] books;
        Utility util;

        public Admin(string[,] books) {
            this.books = books;
            this.util = new Utility();
        }

        public void adminAction(int choice) {
            int option = 0;
            
            do
            {
                Console.Write("\n Menu\n1. Add Book\n2. Delete Book\n3. Update Book\n4. List all books\n5. Exit\n Enter your choice: ");
                option = util.getUserIntegerInput(startRange: 0, endRange: 5);

                switch (option)
                {
                    case 1:
                        addBook();
                        break;
                    case 2:
                        removeBook();
                        break;
                    case 3:
                        UpdateBook();
                        break;
                    case 4:
                        viewAllBooks();
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            } while (option != 5);

        }

        public void addBook()
        {
            Console.Write("\n\nSelect Book Categories: \n1.Selfhelp\n2.Comics\n3.thriller\n4.Biography \nEnter the Category:");
            int categoryOfBook = util.getUserIntegerInput(0, 5);
            int bookCount = increaseBookCount(categoryOfBook) + 1;

            Console.WriteLine("\nEnter the book name:");
            string name = util.getUserStringInput();

            books[bookCount, categoryOfBook - 1] = name;
            Console.WriteLine("Book is added to the list Successfully!\n");
        }

        public int increaseBookCount(int categoryOfBook)
        {
            if (categoryOfBook == 1) {
                return selfhelpBooksCount++;
            }
            else if (categoryOfBook == 2) {
                return comicsBooksCount++;
            }
            else if (categoryOfBook == 3) {
                return thrillerBooksCount++;
            }
            else {
               return biographyBooksCount++;
            }
        }

        public int decreaseBookCount(int categoryOfBook)
        {
            if (categoryOfBook == 1)
            {
                return selfhelpBooksCount--;
            }
            else if (categoryOfBook == 2)
            {
                return comicsBooksCount--;
            }
            else if (categoryOfBook == 3)
            {
                return thrillerBooksCount--;
            }
            else
            {
                return biographyBooksCount--;
            }
        }

        public int getBookCount(int categoryOfBook)
        {
            if (categoryOfBook == 1)
            {
                return selfhelpBooksCount;
            }
            else if (categoryOfBook == 2)
            {
                return comicsBooksCount;
            }
            else if (categoryOfBook == 3)
            {
                return thrillerBooksCount;
            }
            else
            {
                return biographyBooksCount;
            }
        }

        public void removeBook()
        {
            Console.Write("\n <--Remove Book-->\n\nSelect Book Categories: \n1.Selfhelp\n2.Comics\n3.thriller\n4.Biography \nEnter the Category:");
            int category = util.getUserIntegerInput(0, 5);
            if (category > 0)
            {
                Console.Write("\n Enter the bookname:");
                string bookName = util.getUserStringInput();

                int rowIndex = getRowIndexOfBook(category - 1, bookName);
                if (rowIndex == -1)
                {
                    Console.WriteLine("Book is not present...!");
                }
                else
                {
                    Console.WriteLine("Deleteing: " + books[rowIndex, category - 1]);
                    category = category - 1;
                    books[rowIndex, category] = "";
                    for (int i = rowIndex; i < getBookCount(category + 1); i++)
                    {
                        books[i, category] = books[i + 1, category];
                    }
                    books[getBookCount(category + 1), category] = "";
                    decreaseBookCount(category);
                }
            }
        }

        private int getRowIndexOfBook(int column, string bookName)
        {
            int rowIndex = -1;
            for (int i = 0; i < books.GetLength(1); i++)
            {
                if (bookName == books[i, column])
                {
                    rowIndex = i;
                }
            }
            return rowIndex;
        }

        public bool isBookPresent(int category, string bookName)
        {
            bool isPresent = false;

            for (int i = 0; i < books.GetLength(1); i++)
            {
                Console.WriteLine(books[i, category]);
                if (bookName == books[i, category])
                {
                    Console.WriteLine("Present");
                    isPresent = true;
                }
            }
            return isPresent;
        }

        public void UpdateBook()
        {
            Console.Write("\n <--Update Book-->\n\nSelect Book Categories: \n1.Selfhelp\n2.Comics\n3.thriller\n4.Biography \nEnter the Category:");
            int category = util.getUserIntegerInput(0, 5);

            Console.Write("\n Enter the bookname:");
            string bookName = util.getUserStringInput();

            int rowIndex = getRowIndexOfBook(category - 1, bookName);
            if (rowIndex == -1)
            {
                Console.WriteLine("Book is not present...!");
            } else
            {
                Console.Write("\n Enter the new bookname:");
                string newBookName = util.getUserStringInput();
                books[rowIndex, category - 1] = newBookName;
            }
        }

        public void viewAllBooks()
        {
            Console.WriteLine("\nList of all books:");
            for (int i = 0; i < books.GetLength(1); i++)
            { 
                for (int j = 0; j < books.GetLength(0); j++)
                {
                    if (j == 0)
                    {
                       Console.Write("[Category: " + books[j, i] + "] => ");
                    }
                   else
                    {
                        Console.Write(books[j, i] + ", ");
                    }
                }
                Console.Write("\n");
                for (int k = 0; k < 120; k++) {
                    Console.Write("-");

                }
                Console.Write("\n");

            }

        }
    }
}
