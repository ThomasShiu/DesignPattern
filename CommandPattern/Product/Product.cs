using System;
// Receiver:實際執行命令的物件
public class Product
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public void IncreasePrice(int amount)
    {
        Price += amount;
        Console.WriteLine($"商品:[{Name}] , 價格:+ {amount}.");
    }

    public void DecreasePrice(int amount)
    {
        if (amount < Price)
        {
            Price -= amount;
            Console.WriteLine($"商品:[{Name}] , 價格:- {amount}.");
        }
    }

    public override string ToString() => $"商品:[{Name}] , 價格={Price}.";
}