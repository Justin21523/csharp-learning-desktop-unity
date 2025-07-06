using System;
using System.Collections.Generic;
using System.Linq;

// 定義 Item 類別
class Item
{
    public string Name { get; set; }
    public Item(string name) => Name = name;

    // 深複製建構子
    public Item(Item other) => Name = other.Name;
}

// 定義 Inventory 類別
class Inventory : ICloneable
{
    public List<Item> Items { get; set; } = new();

    // 淺複製：只複製參考
    public object Clone() => this.MemberwiseClone();

    // 深複製：複製本身 + 複製清單內每個 Item
    public Inventory DeepClone()
    {
        var copy = (Inventory)this.MemberwiseClone();
        copy.Items = this.Items.Select(i => new Item(i)).ToList();
        return copy;
    }
}

class Program
{
    static void Main()
    {
        // 原始背包
        var invA = new Inventory();
        invA.Items.Add(new Item("Sword"));
        invA.Items.Add(new Item("Shield"));
        Console.WriteLine("Original Inventory A: " + string.Join(", ", invA.Items.Select(i => i.Name)));

        // 淺複製
        var invShallow = (Inventory)invA.Clone();
        invShallow.Items[0].Name = "Broken Sword";
        Console.WriteLine("\nAfter shallow clone & modify invShallow.Items[0]:");
        Console.WriteLine($"Inventory A: {string.Join(", ", invA.Items.Select(i => i.Name))}");
        Console.WriteLine($"Shallow Copy: {string.Join(", ", invShallow.Items.Select(i => i.Name))}");

        // 深複製
        var invDeep = invA.DeepClone();
        invDeep.Items[1].Name = "Golden Shield";
        Console.WriteLine("\nAfter deep clone & modify invDeep.Items[1]:");
        Console.WriteLine($"Inventory A: {string.Join(", ", invA.Items.Select(i => i.Name))}");
        Console.WriteLine($"Deep Copy: {string.Join(", ", invDeep.Items.Select(i => i.Name))}");
    }
}
