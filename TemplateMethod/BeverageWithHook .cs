using System;
public abstract class BeverageWithHook
{

    public void prepareRecipe()
    {
        boilWater();//燒開水
        brew();//沖泡(抽象方法)
        pourInCup();//倒入杯子

        // 加上一個判斷式, 如果客戶
        // 想要配料才真的加配料
        if (customerWantsCondiments())
        {
            addCondiments();
        }
    }

    /// <summary>
    /// 沖泡
    /// </summary>
    public abstract void brew();
    
    /// <summary>
    /// 加調味
    /// </summary>
    public abstract void addCondiments();

    /// <summary>
    /// 燒開水
    /// </summary>
    private void boilWater()
    {
        // 不管是茶或咖啡做法都一樣
        // 可以直接把實作寫在超類別
        Console.WriteLine("燒開水");
    }
    /// <summary>
    /// 倒入杯子
    /// </summary>
    private void pourInCup()
    {
        // 不管是茶或咖啡做法都一樣
        // 可以直接把實作寫在超類別
        Console.WriteLine("倒入杯子");
    }


    /// <summary>
    /// 顧客加料
    /// </summary>
    /// <returns></returns>
    public virtual bool customerWantsCondiments()
    {
        // 這就是一個掛鉤, 通常是空的實作。
        // 次類別可以推翻(Override) 它,
        // 但不見得要這麼做
        return true;
    }
}