using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkYard
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee(1000, "Steve");
            var employee2 = new Employee(20, "becky");
            var employee3 = new Employee(3, "Jude");
            var employee4 = new Employee(400, "Eve");
            var employee5 = new Employee(5, "Sarah");

            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

            employees.Add(1, employee);
            employees.Add(2, employee2);
            employees.Add(100, employee3);
            employees.Add(1000, employee4);
            employees.Add(3, employee5);

            //looping threw the key/value pairs 
            foreach (var pair in employees)
            {
                Console.WriteLine($"Key Value:{pair.Key}");
                Console.WriteLine($"Value id:{pair.Value.EmployeeId} ");
                Console.WriteLine($"Value name{pair.Value.EmployeeName}");
                Console.WriteLine("*************************");
            }


            foreach (var pair in employees)
            {
                if (pair.Key==1000)
                {
                    Console.WriteLine(pair.Value.EmployeeName);
                }
            }

            //loop threw the keys
            foreach (var key in employees.Keys)
            {
                //gets all employee keys
                Console.WriteLine(key);
            }

            foreach (var value in employees.Values)
            {
                Console.WriteLine(value.EmployeeName);
            }

            Console.ReadKey();
        }
    }
}

/*private void UpdateExistingContent()
{
    DisplayAllContent();

    Console.WriteLine("enter the title of the content you'd like to update:");

    string oldtitle = Console.ReadLine();
    StreamingContent newContent = new StreamingContent();

    //title
    Console.WriteLine("Enter the title for the content:");
    newContent.Title = Console.ReadLine();

    //description
    Console.WriteLine("Enter the decription for the content:");
    newContent.Description = Console.ReadLine();

    //maturity rating
    Console.WriteLine("Enter the rating for the content(g, pg, pg-13, etc):");
    newContent.MaturityRating = Console.ReadLine();

    //star rating
    Console.WriteLine("Enter the sta count for the content 5.8, 10, 3.5, ect:");
    string starsAsString = Console.ReadLine();
    newContent.StarRating = double.Parse(starsAsString);


    //isfamilyfriendly
    Console.WriteLine("Is this content family friendly? (y/n)");
    string familyFriendlystring = Console.ReadLine().ToLower();

    if (familyFriendlystring == "y")
    {
        newContent.IsFamilyFriendly = true;

    }
    else
    {
        newContent.IsFamilyFriendly = false;
    }
    //genretype
    Console.WriteLine("Enter the Gene number:\n" +
    "1. Horror\n" +
    "2. Romcom\n" +
    "3. Scify\n" +
    "4. Documentary\n" +
    "5. Romance\n" +
    "6. Drama\n" +
    "7. Action\n" +
    "7. Action\n");

    string genreAsString = Console.ReadLine();
    int genreAsInt = int.Parse(genreAsString);
    newContent.TypeOfGenre = (GenreType)genreAsInt;

    bool wasUpdated = _contentRepo.UpdateExistingContent(oldtitle, newContent);

    if (wasUpdated)
    {
        Console.WriteLine("content successfully updated!");
    }

    else
    {
        Console.WriteLine("could not update content");
    }



}