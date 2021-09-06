using System;
using System.Collections.Generic;

public interface CarComponent
{
    public void printMessage();
}
public class Wheel : CarComponent
{

    public void printMessage()
    {
        Console.WriteLine("This is a wheel");
    }

    // 這是 Wheel 跟 Engine 不同的方法
    public void doWheel()
    {
        Console.WriteLine("Checking wheel...");
    }
}

public class Engine : CarComponent
{

    public void printMessage()
    {
        Console.WriteLine("This is a engine");
    }

    // 這是 Wheel 跟 Engine 不同的方法
    public void doEngine()
    {
        Console.WriteLine("Testing this engine...");
    }
}

public class Car
{

    private List<CarComponent> mComponents;

    public Car()
    {
        mComponents = new List<CarComponent>();
    }

    // 有些時候我們還是需要針對不同類別去做不同的事情
    public void setComponent(CarComponent component)
    {
        mComponents.Add(component);
        if (typeof(Wheel).IsInstanceOfType(component))
        {
            ((Wheel)component).doWheel();
        }
        else
        {
            ((Engine)component).doEngine();
        }
    }
}