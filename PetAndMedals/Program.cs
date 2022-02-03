using System;
using System.IO;

namespace PetAndMedals
{
    public class Pet
    {
        //Property definition
        public string Name { get; }
        public string Owner { get; private set; }
        public int Age { get; }
        public string Description { get; }
        public bool IsHouseTrained { get; private set; }

        //Constructor
        public Pet(string name, int age, string desciption)
        {
            Name = name;
            Age = age;
            Description = desciption;
        }

        //Methods
        public override string ToString()
        {
            return $"{Name} is a {Description}, age {Age}, owned by {Owner} and is {(IsHouseTrained ? "" : "not ")}house trained.";
        }

        public void SetOwner (string owner)
        {
            Owner = owner;
        }

        public void Train()
        {
            IsHouseTrained = true;
        }
    }

    public enum MedalColor { Bronze, Silver, Gold }

    public class Medal
    {
        //Property definition
        public string Name { get; }
        public string TheEvent { get; }
        public MedalColor Color { get; }
        public int Year { get; }
        public bool IsRecord { get; }

        //Constructor
        public Medal(string name, string theEvent, MedalColor color, int year, bool isRecord )
        {
            Name=name;
            TheEvent = theEvent;
            Color = color;
            Year = year;
            IsRecord = isRecord;
        }

        //Methods
        public override string ToString()
        {
            return $"{Year} - {TheEvent}{(IsRecord?"":"(R)")} {Name}({Color})";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //CODE FOR PET CLASS
            List<Pet> petsData = new List<Pet>()
            {
                new Pet ("Rocky", 5, "Beagle"),
                new Pet ("Hunter", 2, "Siberian Husky"),
                new Pet ("Gypsy", 3, "German Shephard"),
                new Pet ("Bailey", 8, "Golden Retriever"),
            };

            petsData[0].Train();
            petsData[0].SetOwner("Jack");
            petsData[1].SetOwner("Stephanie");
            petsData[2].SetOwner("Jon");
            petsData[3].SetOwner("Kelly");
            petsData[3].Train();

            foreach (Pet pet in petsData)
            {
                Console.WriteLine(pet.ToString());
            };

            Console.Write("\nType in an owner's name to search: ");
            string ownername = Console.ReadLine();
            if (petsData.Any(pet => pet.Owner == ownername))
            {
                int index = petsData.FindIndex(pet => pet.Owner == ownername);
                Console.WriteLine($"{ownername} has a pet named {petsData[index].Name}, aged {petsData[index].Age}, {petsData[index].Description} who is {(petsData[index].IsHouseTrained ? "" : "not ")}house trained.\n");
            }
            else
            {
                Console.WriteLine($"No owner named {ownername} was found!!\n");
            }

            //CODE FOR MEDALS CLASS
            //create a medal object
            Medal m1 = new Medal("Horace Gwynne", "Boxing", MedalColor.Gold, 2012, true);
            //print the object
            Console.WriteLine(m1);
            //print only the name of the medal holder
            Console.WriteLine(m1.Name);
            //create another object
            Medal m2 = new Medal("Michael Phelps", "Swimming", MedalColor.Gold, 2012, false);
            //print the updated m2
            Console.WriteLine(m2);

            //create a list to store the medal objects
            List<Medal> medals = new List<Medal>() { m1, m2 };
            medals.Add(new Medal("Ryan Cochrane", "Swimming", MedalColor.Silver, 2012, false));

            medals.Add(new Medal("Adam van Koeverden", "Canoeing", MedalColor.Silver, 2012, false));

            medals.Add(new Medal("Rosie MacLennan", "Gymnastics", MedalColor.Gold, 2012, false));

            medals.Add(new Medal("Christine Girard", "Weightlifting", MedalColor.Bronze, 2012, false));

            medals.Add(new Medal("Charles Hamelin", "Short Track", MedalColor.Gold, 2014, true));

            medals.Add(new Medal("Alexandre Bilodeau", "Freestyle skiing", MedalColor.Gold, 2012, true));

            medals.Add(new Medal("Jennifer Jones", "Curling", MedalColor.Gold, 2014, false));

            medals.Add(new Medal("Charle Cournoyer", "Short Track", MedalColor.Bronze, 2014, false));

            medals.Add(new Medal("Mark McMorris", "Snowboarding", MedalColor.Bronze, 2014, false));

            medals.Add(new Medal("Sidney Crosby ", "Ice Hockey", MedalColor.Gold, 2014, false));

            medals.Add(new Medal("Brad Jacobs", "Curling", MedalColor.Gold, 2014, false));

            medals.Add(new Medal("Ryan Fry", "Curling", MedalColor.Gold, 2014, false));

            medals.Add(new Medal("Antoine Valois-Fortier", "Judo", MedalColor.Bronze, 2012, false));

            medals.Add(new Medal("Brent Hayden", "Swimming", MedalColor.Bronze, 2012, false));

            int counter = 1;
            //prints a numbered list of 16 medals.
            Console.WriteLine("\n\nAll 16 medals");
            for(int i = 0; i < medals.Count; i++)
            {
                Console.WriteLine($"{counter} - {medals[i]}");
                counter++;
            }

            counter = 1;
            //prints a numbered list of 16 names (ONLY)
            Console.WriteLine("\n\nAll 16 names");
            for (int i = 0; i < medals.Count; i++)
            {
                Console.WriteLine($"{counter} - {medals[i].Name}");
                counter++;
            }
            counter = 1;
            //prints a numbered list of 9 gold medals
            Console.WriteLine("\n\nAll 9 gold medals");
            for (int i = 0; i < medals.Count; i++)
            {   
                if ((int)medals[i].Color == 2)
                {
                    Console.WriteLine($"{counter} - {medals[i]}");
                    counter++;
                }
                
            }
            counter = 1;
            //prints a numbered list of 9 medals in 2012
            Console.WriteLine("\n\nAll 9 medals");
            for (int i = 0; i < medals.Count; i++)
            {
                if (medals[i].Year == 2012)
                {
                    Console.WriteLine($"{counter} - {medals[i]}");
                    counter++;
                }

            }
            counter = 1;
            //prints a numbered list of 4 gold medals in 2012
            Console.WriteLine("\n\nAll 4 gold medals");
            for (int i = 0; i < medals.Count; i++)
            {
                if (medals[i].Year == 2012 && (int)medals[i].Color == 2)
                {
                    Console.WriteLine($"{counter} - {medals[i]}");
                    counter++;
                }

            }
            counter = 1;
            //prints a numbered list of 3 world record medals
            Console.WriteLine("\n\nAll 3 records");
            for (int i = 0; i < medals.Count; i++)
            {
                if (medals[i].IsRecord == true)
                {
                    Console.WriteLine($"{counter} - {medals[i]}");
                    counter++;
                }

            }

            //saving all the medal to file Medals.txt
            Console.WriteLine("\n\nSaving to file");
            TextWriter writer = new StreamWriter("../../../MedalsDataFile.txt");
            foreach (Medal detail in medals)
            {                
                writer.WriteLine(detail.ToString());               
            }
            writer.Close();
        }
    }
}