using System;
public class TestPeper
{

    //試題1
    public void TestQuestion1()
    {
        Console.WriteLine("試題1:1111111");
        Console.WriteLine($"答案:{Answer1()}");
    }
    //試題2
    public void TestQuestion2()
    {
        Console.WriteLine("試題2:2222222");
        Console.WriteLine($"答案:{Answer2()}");
    }
    //試題3
    public void TestQuestion3()
    {
        Console.WriteLine("試題3:3333333");
        Console.WriteLine($"答案:{Answer3()}");
    }

    protected virtual string Answer1()
    {
        return "";
    }
    protected virtual string Answer2()
    {
        return "";
    }
    protected virtual string Answer3()
    {
        return "";
    }
}