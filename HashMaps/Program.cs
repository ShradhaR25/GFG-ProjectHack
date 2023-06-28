using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Dictionary<string, int>> hashTables = new List<Dictionary<string, int>>();

        Console.Write("Enter the name of target branch: ");
        Console.ReadLine();
        Console.Write("Enter the number of file changed: ");
        int numberOfHashTables = int.Parse(Console.ReadLine());

        // taking entries
        for (int i = 0; i < numberOfHashTables; i++)
        {
            Dictionary<string, int> changeFrequency = new Dictionary<string, int>();

            Console.Write("Enter the name of file changed: ");
            string tableName = Console.ReadLine();

           // Console.Write("Enter the total no. of file changed: ");
           // int entryCount = int.Parse(Console.ReadLine());

            for (int j = 0; j < 3; j++)    // getting 15 git history from the commit history
            {
                Console.WriteLine($"Enter details for entry {j + 1}: ");
                Console.Write("ID of reviewer: ");
                string id = Console.ReadLine();
                Console.Write("Name of reviewer: ");
                string name = Console.ReadLine();
                Console.Write("Number of commits made: ");
                int changes = int.Parse(Console.ReadLine());

                string key = $"{id}-{name}";

                if (changeFrequency.TryGetValue(key, out int existingChanges))
                    changeFrequency[key] = existingChanges + changes;
                else
                    changeFrequency[key] = changes;
            }

            hashTables.Add(changeFrequency);

            Console.WriteLine();
        }

        var topIndividuals = new Dictionary<string, int>();

        foreach (var table in hashTables)
        {
            foreach (var entry in table)
            {
                string reviewer = entry.Key;
                int totalChange = entry.Value;

                if (topIndividuals.TryGetValue(reviewer, out int existingChanges))
                    topIndividuals[reviewer] = existingChanges + totalChange;
                else
                    topIndividuals[reviewer] = totalChange;
            }
        }

        Console.WriteLine("Top Reviewers:");

        int n = hashTables.Count; // Number of different branches 
        int count = 0;

        foreach (var entry in topIndividuals.OrderByDescending(x => x.Value))
        {
            string reviewer = entry.Key;
            int totalChange = entry.Value;
            Console.WriteLine("The top reviewer is --> ");
            Console.WriteLine($"ID of reviewer: {reviewer}, Total Changes made by them: {totalChange}");

            count++;

            if (count == n)
                break;
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
