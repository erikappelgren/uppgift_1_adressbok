using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace uppgift_1_adressbok
{
    class Program
    {
        public class Person
        {
            public string firstName, lastName, phone, email;
            public Person(string fName, string lName, string P, string E)
            {
                firstName = fName; lastName = lName; phone = P; email = E;
            }
        }
        static void Main(string[] args)
        {
            bool quitProgram = false;
            List<Person> pers = new List<Person>();
            string fileName = @"C:\Users\erika\adressbok.txt";

            Console.WriteLine("Välkommen till adressboken!");
            Console.WriteLine("Skriv 'spara' efter varje ny person tillagd!");
            Console.WriteLine("Skriv 'quit' för att avsluta");
            for (int i = 0; i < pers.Count; i++)
            {
                if (pers[i] != null)
                {
                    Console.WriteLine("{0} {1} {2} {3}",
                        pers[i].firstName, pers[i].lastName, pers[i].phone, pers[i].email);
                }
            }
            while (!quitProgram)
            {
                Console.Write("> ");
                string userInput = Console.ReadLine();
                if (userInput == "quit")
                {
                    return;
                }
                else if (userInput == "visa")
                {
                    try
                    { //Källa https://www.c-sharpcorner.com/article/working-with-c-sharp-streamreader/
                        using (StreamReader reader = new StreamReader(fileName))
                        {
                            Console.WriteLine(reader.ReadToEnd());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                }
                else if (userInput == "ny")
                {
                    Console.WriteLine("Skriv in förnamn: ");
                    string fName = Console.ReadLine();
                    Console.WriteLine("Skriv in efternamn: ");
                    string lName = Console.ReadLine();
                    Console.WriteLine("Skriv in telefonnummer: ");
                    string P = Console.ReadLine();
                    Console.WriteLine("Skriv in email: ");
                    string E = Console.ReadLine();
                    pers.Add(new Person(fName, lName, P, E));
                }
                else if (userInput == "spara")
                {
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        for (int i = 0; i < pers.Count(); i++)
                        {
                            writer.WriteLine("{0} {1} {2} {3}",
                                pers[i].firstName, pers[i].lastName, pers[i].phone, pers[i].email);
                        }
                    }
                }
                else if (userInput == "ta bort")
                {
                    Console.WriteLine("Vem vill du ta bort?");
                    string removeItem = Console.ReadLine();
                    int index = -1;
                    for (int i = 0; i < pers.Count(); i++)
                    {
                        if (removeItem == pers[i].firstName)
                        {
                            index = i;
                            break;
                        }
                    }
                    if (index != -1)
                    {
                        pers.RemoveAt(index);
                        Console.WriteLine("Tog bort {0}", removeItem);
                    }
                    else
                    {
                        Console.WriteLine("Hittade inte");
                    }
                }
                else
                {
                    Console.WriteLine("Okänt kommando: {0}", userInput);
                }
            }
        }
    }
}
