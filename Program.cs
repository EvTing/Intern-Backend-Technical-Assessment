using System;
using System.Collections.Generic;

public interface IItemManager{
    void AddItem(string item);
    void RemoveItem(string item);
    void PrintAllItems();
    void ClearAllItems();
}

public interface IItemManager<T>{
    void AddItem(T item);
    void RemoveItem(T item);
    void PrintAllItems();
    void ClearAllItems();
}

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
    }
}

public class ItemManager:IItemManager
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

public class ItemManager<T>:IItemManager<T>
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void RemoveItem(T item)
    {
        items.Remove(item);
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
