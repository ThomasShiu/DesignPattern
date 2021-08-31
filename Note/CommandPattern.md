# Command Pattern 命令模式

命令模式將「請求」封裝成物件，以便使用不同的請求、佇列、或者日誌，參數化其他物件。命令模式也支援可復原的作業。
![樣板方法](command_pattern.png)

命令模式介面

<pre>
<code>
public interface ICommand
{
    void ExecuteAction();
    void UndoAction();
}
</code>
</pre>

<pre>
<code>
public class ModifyPrice
{
    private readonly List<ICommand> _commands; //所有命令
    private ICommand _command;//單一命令

    public ModifyPrice()
    {
        _commands = new List<ICommand>();
    }

    public void SetCommand(ICommand command) => _command = command;

    public void Invoke()
    {
        _commands.Add(_command);
        _command.ExecuteAction();
    }

    public void Undo()
    {
        // 反轉並依序復原
        foreach (var command in Enumerable.Reverse(_commands))
        {
            command.UndoAction();
        }
    }
}
</code>
</pre>

<pre>
<code>
public enum PriceAction
{
    Increase,
    Decrease
}

// 設定要執行的命令
public class ProductCommand : ICommand
{
    private readonly Product _product;
    private readonly PriceAction _priceAction;
    private readonly int _amount;

    public ProductCommand(Product product, PriceAction priceAction, int amount)
    {
        _product = product;
        _priceAction = priceAction;
        _amount = amount;
    }

    public void ExecuteAction()
    {
        if(_priceAction == PriceAction.Increase)
        {
            _product.IncreasePrice(_amount);
        }
        else
        {
            _product.DecreasePrice(_amount);
        }
    }
    public void UndoAction()
    {
        if (_priceAction == PriceAction.Increase)
        {
            _product.DecreasePrice(_amount);
        }
        else
        {
            _product.IncreasePrice(_amount);
        }
    }
}
</code>
</pre>


Result:

    商品:[iPhone 13] , 價格=30000.
    商品:[iPhone 13] , 價格:+ 100.
    商品:[iPhone 13] , 價格:+ 50.
    商品:[iPhone 13] , 價格:- 25.
    商品:[iPhone 13] , 價格:+ 70.
    商品:[iPhone 13] , 價格=30195.
    ====取消命令====
    商品:[iPhone 13] , 價格:- 70.
    商品:[iPhone 13] , 價格:+ 25.
    商品:[iPhone 13] , 價格:- 50.
    商品:[iPhone 13] , 價格:- 100.
    商品:[iPhone 13] , 價格=30000.