using System;

//具體類別
class ConcreteClassA:AbstractClass{
    public override void PrimitiveOperation1()
    {
        Console.WriteLine("具體類A 方法1實作");
    }
    public override void PrimitiveOperation2()
    {
        Console.WriteLine("具體類A 方法2實作");
    }
}

class ConcreteClassB:AbstractClass{
    public override void PrimitiveOperation1()
    {
        Console.WriteLine("具體類B 方法1實作");
    }
    public override void PrimitiveOperation2()
    {
        Console.WriteLine("具體類B 方法2實作");
    }
}