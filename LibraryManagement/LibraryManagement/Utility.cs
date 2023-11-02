using Microsoft.VisualBasic.FileIO;
using System;

public class Utility
{
    public int getUserIntegerInput(int startRange, int endRange)
    {
        int option = 0;
       
        try
        {

            option = Convert.ToInt32(Console.ReadLine());
            if (!(option > startRange && option < endRange))
                throw new Exception("Out of bound");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: Invalid entry!");
        }
        finally
        {
            if (!(option > startRange && option < endRange))
            {
                option = -1;
            }
        }
        return option;
    }

    public string getUserStringInput()
    {
        string input = "";

        try
        {
            input = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: Invalid entry!");
        }
        return input;

    }

}
