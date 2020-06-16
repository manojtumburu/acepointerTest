using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sorting
{
    public class Person
    {
        //Properties are created to hold the values of Lastname and GivenName
        internal string LastName { get; set; }
        internal string GivenName { get; set; }

        internal List<Person> SortNamesByLastName(string[] inputNames)
        {
            List<Person> sorted_lstNames = new List<Person>();
            try
            {
                Person ObjPerson = null;
                //Iterating through the list of Names
                foreach (var paramNames in inputNames)
                {
                    ObjPerson = new Person();
                    //Splitting the name based on empty space and assigning the values to GivenName and LastName
                    string[] paramCompleteName = paramNames.Split(' ');
                    //Adding the values to LastName property of Person Object.
                    ObjPerson.LastName = paramCompleteName[paramCompleteName.Length - 1];
                    for (int i = 0; i < paramCompleteName.Length - 1; i++)
                    {
                        //Adding the values to GivenName property of Person Object.
                        ObjPerson.GivenName += paramCompleteName[i].ToString() + " ";
                    }
                    //Adding the Object to List of class Person.
                    sorted_lstNames.Add(ObjPerson);
                }
                //Using LINQ, sorted the names based on LastName
                var sortedStudents = sorted_lstNames.OrderBy(s => s.LastName);
                //Converting the var to List
                sorted_lstNames = sortedStudents.ToList();
            }
            catch (Exception ex)
            {
                //Any exceptions can be seen on console screen.
                Console.WriteLine("ClassName: Person, MethodName:SortNamesByLastName, ErrorMsg: --- " + ex.Message.ToString());
            }
            return sorted_lstNames;
        }
    }

    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //Creating the object for the class Person
                Person ObjPerson = new Person();
                //Creating the List for the class Person
                List<Person> sortedResult_List = new List<Person>();
                //Input text file complete path with filename including extension
                string inputTextFilePath = @"D:\NameSorting\unsorted-names-list.txt";
                //Output text file complete path with filename including extension
                string outputTextFilePath = @"D:\NameSorting\sorted-names-list.txt";
                //Reading list of names from input text file into string array
                string[] inputNames = File.ReadAllLines(inputTextFilePath);
                //Passing the string array as input to the method invoked using the object created for class Person
                //storing the result into list created for class Person.
                sortedResult_List = ObjPerson.SortNamesByLastName(inputNames);
                //Iterating through the list returned to print the names on console screen and writing to text file.             
                using (TextWriter tw = new StreamWriter(outputTextFilePath))
                {
                    foreach (var paramNames in sortedResult_List)
                    {
                        Console.WriteLine(paramNames.GivenName + " " + paramNames.LastName);
                        tw.WriteLine(paramNames.GivenName + " " + paramNames.LastName);
                    }
                }
            }
            catch (Exception ex)
            {//Any exceptions can be seen on console screen.
                Console.WriteLine("ClassName: Program, MethodName:Main, ErrorMsg: --- " + ex.Message.ToString());
            }
        }
    }
}
