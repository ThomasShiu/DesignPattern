using System;
public class TeaWithHook : BeverageWithHook
{
    public override void brew()
    {
        Console.WriteLine("泡茶");
    }

    public override void addCondiments()
    {
        Console.WriteLine("加檸檬片");
    }

    public override bool customerWantsCondiments()
    {
        Console.WriteLine("顧客是否要加料?(y/n)");
        // 推翻掛鉤方法, 改成自己想要的行為
        string answer = getUserInput();
        if (answer.ToLower().StartsWith("y"))
        {
            return true;
        }

        return false;
    }


    private string getUserInput()
    {
        // 省略從標準 I/O 取得使用者輸入...
        return Console.ReadLine();
    }


}