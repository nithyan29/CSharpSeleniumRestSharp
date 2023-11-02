using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class MainPage
    {
        static void Main(String[] args)
        {
            //Creating array for books and adding category
            string[,] books = new string[10, 4];
            string[] categories = new string[]{ "selfhelp", "Comics", "thriller", "Biography" };
            for (int count = 0; count < categories.Length; count++)
            {
                books[0, count] = categories[count];
            }

            int choice = 0;
            Utility util = new Utility();
            do
            {
                Console.Write("\nLogin as \n1. Admin\n2. Exit\n Enter your choice: ");
                choice = util.getUserIntegerInput(startRange: 0, endRange: 4);
       
                switch (choice)
                {
                    case 1:
                        //Admin
                        Admin admin = new Admin(books);
                        admin.adminAction(choice);
                        break;

                    case 2:
                        Console.WriteLine("Thank you....");
                        break;

                    default:
                        Console.WriteLine("Choose Numbers between 1 to 3");
                        break;

;                }
            } while (choice != 3);
        }
    }
}
