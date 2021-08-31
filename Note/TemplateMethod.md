# Template Method 範本方法

樣板方法(範本方法)模式將一個演算法的骨架定義在一個方法中，而演算法本身會用到的一些方法，則是定義在次類別中。樣板方法讓次類別在不改變演算法架構的情況下，重新定義演算法中的某些步驟。
![樣板方法](template_method.png)

假設開了一家飲料店,泡咖啡跟泡茶的SOP如下

<pre>
<code>
public class Coffee {
    // 這是店裡統一的泡咖啡SOP
    void prepareRecipe()
    {
        // 煮開水
        boilWater();

        // 用沸水沖泡咖啡
        brewCoffeeGrinds();

        // 把咖啡倒進杯子
        pourInCup();

        // 加糖和牛奶
        addSugarAndMilk();
    }
    // 底下省略這些方法的實作...
}
</code>
</pre>

<pre>
<code>
public class Coffee {
    // 這是店裡統一的泡咖啡SOP
    void prepareRecipe()
    {
        // 煮開水
        boilWater();

        // 用沸水沖泡咖啡
        brewCoffeeGrinds();

        // 把咖啡倒進杯子
        pourInCup();

        // 加糖和牛奶
        addSugarAndMilk();
    }

    // 底下省略這些方法的實作...
}
</code>
</pre>
prepareRecipe看起來好像喔，應該可以抽象化。第一步很自然的把一些一樣的方法，如biolWater 跟 pourInCup，放到超類別裡，就稱為 Beverage。而雖然咖啡是沖泡「咖啡」、加糖跟牛奶，茶是沖泡「茶葉」、加檸檬，兩種飲料加的東西不一樣，但是做的「動作」是一樣的，只是處裡不同的原料而已。有了這些想法後，就可以來改上面的程式碼了：
<pre>
<code>
// 抽象類別-飲料
public abstract class Beverage {

    // 宣告為 final 是因為不想次類別推翻這個方法, 這是統一的演算法
    final void prepareRecipe()
    {
        // 煮開水
        boilWater();

        // 用沸水沖泡
        // 跟上面程式碼比, 方法名更通用
        brew();

        // 把飲料倒進杯子
        pourInCup();

        // 加配料
        // 跟上面程式碼比, 方法名更通用
        addCondiments();
    }

    // 因為咖啡跟茶處理這些方法的做法不同,
    // 所以宣告為抽象方法,
    // 留給次類別去處理
    abstract void brew();
    abstract void addCondiments();

    private void boilWater()
    {
        // 不管是茶或咖啡做法都一樣
        // 可以直接把實作寫在超類別
    }

    private void pourInCup()
    {
        // 不管是茶或咖啡做法都一樣
        // 可以直接把實作寫在超類別
    }
}
</code>
</pre>
茶與咖啡實作
<pre>
<code>
public class Tea extends Beverage {

    @Override
    public void brew()
    {
        System.out.println("Steeping the tea");
    }

    @Override
    public void addCondiments()
    {
        System.out.println("Adding lemon");
    }
}

public class Coffee extends Beverage {

    @Override
    public void brew()
    {
        System.out.println("Dripping coffee through filter");
    }

    @Override
    public void addCondiments()
    {
        System.out.println("Adding sugar and milk");
    }
}
</code>
</pre>

樣板方法除了上面的範例外，還有一個小技巧可以用，稱為掛鉤(Hook)。掛鉤是一種方法，被宣告在抽象類別中，且定義為什麼都不做，或是有預設的實作方式。這可以讓次類別有能力對演算法進行掛鉤。要不要掛鉤則由次類別決定
<pre>
<code>
public abstract class BeverageWithHook
{

    public void prepareRecipe()
    {
        boilWater();//燒開水
        brew();//沖泡
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
</code>
</pre>

假如要使用掛鉤，次類別要推翻預設的定義，此範例的掛鉤是控制是否要加配料，我們可以在次類別決要怎樣的情形才會加配料：
<pre>
<code>
public class CoffeeWithHook : BeverageWithHook
{
    public override void brew()
    {
        Console.WriteLine("冰滴");
    }
    public override void addCondiments()
    {
        Console.WriteLine("加奶精,糖");
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
</code>
</pre>

Result:

    =====================
    Coffee TempleteMethod.
    ===================== 
    燒開水
    冰滴
    倒入杯子
    顧客是否要加料?(y/n)  
    y
    加奶精,糖
    =====================
    Tea TempleteMethod.  
    =====================
    燒開水
    泡茶
    倒入杯子
    顧客是否要加料?(y/n) 
    n