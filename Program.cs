using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager manager = new ItemManager();

        manager.AddItem("Apple");
        manager.AddItem("Banana");

        manager.PrintAllItems();

        manager.RemoveItem("Apple");

        ItemManager<Fruit> fruitManager = new ItemManager<Fruit>();

        fruitManager.AddItem(new Fruit("Papaya"));
        fruitManager.AddItem(new Fruit("Grapes"));
        fruitManager.AddItem(new Fruit("Watermelon"));

        fruitManager.PrintAllItems();

        // Part Four (Bonus): Implement an interface IItemManager and make ItemManager implement it.
        // TODO: Implement this part four.
    }
}

public class ItemManager
{
    private List<string> items = new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }


    public void RemoveItem(string item)
    {
        items.Remove(item);
    }

    public void ClearAllItems()
    {
        items.Clear();
    }
}

public class Fruit
{
    public string Name {get;set;}

    public Fruit(string name)
    {
        Name=name;
    }

    public override string ToString()
    {
        return Name;

    }
}

public class ItemManager<T>
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearAllItems()
    {
        items.Clear();
    }
}
