using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Spouse { get; set; }
    public List<Person> Children { get; set; }


    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Children = new List<Person>();
    }
}

public class GenTree
{
    public List<Person> People { get; set; }


    public GenTree()
    {
        People = new List<Person>();
    }

    public void AddPerson(string name, int age, string parentName)
    {
        Person newPerson = new Person(name, age);

        if (parentName == null)
        {
            People.Add(newPerson);
        }
        else
        {
            foreach (Person person in People)
            {
                if (person.Name == parentName)
                {
                    person.Children.Add(newPerson);
                }
            }
        }
    }

    public void FamilyTree()
    {
        foreach (Person person in People)
        {
            Console.WriteLine($"|| " + person.Name + " (Возраст: " + person.Age + " лет)");

            if (!string.IsNullOrEmpty(person.Spouse))
            {
                Console.WriteLine($"|| => Супруг/Супруга: " + person.Spouse);
            }

            if (person.Children.Count > 0)
            {
                Console.WriteLine($"|| |");
                Console.WriteLine($"|| V");
                Console.WriteLine($"|| Дети:");
                foreach (Person child in person.Children)
                {
                    Console.WriteLine("|| - " + child.Name + " (Возраст: " + child.Age + " лет)");
                }
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        GenTree tree = new GenTree();


        tree.AddPerson("Денис", 50, null);
        tree.AddPerson("Яна", 45, null);
        tree.AddPerson("Алиса", 25, "Денис");
        tree.AddPerson("Кирилл", 20, "Денис");
        tree.AddPerson("Егор", 18, "Яна");

        tree.People[0].Spouse = "Яна";
        tree.People[1].Spouse = "Денис";

        tree.FamilyTree();
    }
}