using System;
// 實際執行命令的物件
public class ReceiverRobot
{
    public void GoAhead()
    {
        Console.WriteLine("向前走一步");
    }

    public void TurnLeft()
    {
        Console.WriteLine("向左轉");
    }

    public void TurnRight()
    {
        Console.WriteLine("向右轉");
    }
    public void TurnBack()
    {
        Console.WriteLine("向後轉");
    }
}