using System;
using System.Collections.Generic;

public class Inventory2
{
    private List<string> _items = new();
    public IReadOnlyList<string> Items => _items.AsReadOnly();

    public void Add(string item)
    {
        if (string.IsNullOrWhiteSpace(item))
            throw new ArgumentException("Item 不可為空");
        _items.Add(item);
    }

    public bool Remove(string item) => _items.Remove(item);
}

class Program
{
    static void Main()
    {
        var inv = new Inventory2();
        inv.Add("Sword");
        inv.Add("Shield");
        Console.WriteLine("Items: " + string.Join(", ", inv.Items));

        // inv.Items.Add("Potion");  // 會編譯失敗

        inv.Remove("Sword");
        Console.WriteLine("After remove Sword: " + string.Join(", ", inv.Items));
    }
}
