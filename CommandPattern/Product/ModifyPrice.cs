using System.Collections.Generic;
using System.Linq;
using System;
// Invoker:用來發出命令的類別
public class ModifyPrice
{
    private readonly Stack<ICommand> _commands; //所有命令
    private ICommand _command;//單一命令

    public ModifyPrice()
    {
        _commands = new Stack<ICommand>();
    }

    public void SetCommand(ICommand command) => _command = command;

    public void Invoke()
    {
        _commands.Push(_command);
        _command.ExecuteAction();
    }

    public void Undo()
    {
        if (_commands.Count == 0)
        {
            Console.WriteLine("[復原失敗] --- 查無記錄");
            return;
        }
        var cmd = _commands.Pop();
        cmd.UndoAction();
    }
    public void UndoAll()
    {
        // 依序取消
        foreach (var command in _commands)
        {
            command.UndoAction();
        }
    }
}