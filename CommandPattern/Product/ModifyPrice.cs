using System.Collections.Generic;
using System.Linq;
// Invoker:用來發出命令的類別
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
        // 反轉並依序取消
        foreach (var command in Enumerable.Reverse(_commands))
        {
            command.UndoAction();
        }
    }
}