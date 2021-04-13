using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //string[] countries = new string[10]; intance initially when number is 10
            string[] daysOfWeek = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            foreach (var day in daysOfWeek)
            {
                Console.WriteLine(day);
            }

            Console.WriteLine("What number you want to show?");
            Console.WriteLine("Monday = 1 etc >");
            int iDay = int.Parse(Console.ReadLine());

            string dayString = daysOfWeek[iDay];
            Console.WriteLine($"ay Selected {dayString}");


            // Read from CSV file
            //string path = @"C:\Users\Juan.Gomez\Documents\Tutorials & Books\pluralsight courses\CSharp-collections\csharp-collection\countries.csv";
            string path = "C:/files/countries.csv";

            CsvReader reader = new CsvReader(path);
            Country[] countries = reader.ReadFirstNCountries(2);

            foreach (Country c in countries)
            {
                Console.WriteLine($"{c.Population}: {c.Name}");
            }

            // Working with List
            //List<string> dayOfWeeks = new List<string>
            //{
            //    "Monday",
            //    "Tuesday",
            //    "Wednesday",
            //    "Thursday",
            //    "Friday",
            //    "Saturday",
            //    "Sunday"
            //};
            
            
            List<string> dayOfWeeks = new List<string>();
            dayOfWeeks.Add("Monday");
            dayOfWeeks.Add("Tuesday");
            dayOfWeeks.Add("Wednesday");
            dayOfWeeks.Add("Thursday");
            dayOfWeeks.Add("Friday");
            dayOfWeeks.Add("Saturday");
            dayOfWeeks.Add("Sunday");

            string pathList = "C:/files/countries.csv";

            CsvReader readerList = new CsvReader(pathList);
            List<Country> countriesList = readerList.ReadAllCountries();

            // Insert a new item on the list
            Country liliput = new Country("Lilliput", "LIL", "somewhere", 2_000_000);
            int lilIndex = countriesList.FindIndex(x => x.Population < 2_000_000);
            countriesList.Insert(lilIndex, liliput);
            // Remove the item on the list
            countriesList.RemoveAt(lilIndex);

            //foreach (Country c in countriesList)
            //{
            //    Console.WriteLine($"List {c.Population}: {c.Name}");
            //}

            for (int i = 0; i < countriesList.Count; i++)
            {
                Country c = countriesList[i];
                Console.WriteLine($"{i + 1}.- List {c.Population}: {c.Name}");
            }

            // USING LINQ - Need to use System.Linq
            //foreach (var item in countriesList.Take(10)) Take only 10 items
            //foreach (var item in countriesList.OrderBy(x => x.Name).Take(10))
            foreach (var item in countriesList.Take(10).Where(x=>!x.Name.Contains(',')))
            {

            }

            Console.WriteLine($"Total countries {countriesList.Count}");

            // WORKING WITH DICTIONARY
            Country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            Country finland = new Country("Finland", "FIN", "Europe", 5_112_323);

            //Dictionary<string, Country> countriesDictionary = new Dictionary<string, Country>();
            //countriesDictionary.Add(norway.Code, norway);
            //countriesDictionary.Add(finland.Code, norway);
            var countriesDictionary = new Dictionary<string, Country>
            {
                { norway.Code, norway },
                { finland.Code, norway }
            };

            Console.WriteLine(countriesDictionary["NOR"].Name);

            //foreach (var c in countriesDictionary)
            //{
            //    Console.WriteLine(c.Value.Name);
            //}
            foreach (var c in countriesDictionary.Values)
            {
                Console.WriteLine(c.Name);
            }
            
            // check if exist an item dictionary
            bool exist = countriesDictionary.TryGetValue("MUS", out Country country);
            if (exist)
                Console.WriteLine(country.Name);
            else
                Console.WriteLine("There is no country with the code MUS");


            // Read File and use Dictionary
            // Read from CSV file
            //string path = @"C:\Users\Juan.Gomez\Documents\Tutorials & Books\pluralsight courses\CSharp-collections\csharp-collection\countries.csv";
            string pathDictionary = "C:/files/countries.csv";

            CsvReader readerDictionary = new CsvReader(pathDictionary);
            Dictionary<string, Country> countriesDictionaryFile = readerDictionary.ReadAllCountriesWithDictionary();

            Console.WriteLine("Which country code do you want to look up? ");
            string userInput = Console.ReadLine();

            bool gotCountry = countriesDictionaryFile.TryGetValue(userInput, out Country countryFileDictionary);

            if (!gotCountry)
                Console.WriteLine($"Sorry, there is no country with code, {userInput}");
            else
                Console.WriteLine($"{countryFileDictionary.Name} has population {countryFileDictionary.Population}");


            // WORKING WITH REGION AND A DICTIONARY
            string pathDictionaryRegion = "C:/files/countries.csv";
            CsvReader readerDictionaryRegion = new CsvReader(pathDictionaryRegion);

            Dictionary<string, List<Country>> countriesDictionaryRegion = readerDictionaryRegion.ReadAllCountriesDictionary();
            foreach (string region in countriesDictionaryRegion.Keys)
            {
                Console.WriteLine(region);
            }




        }
    }
}
