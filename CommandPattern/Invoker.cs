
using System.Collections.Generic;
// 用來發出命令的類別
public class Invoker
{
    private IList<Command> cmds = new List<Command>();
 
    public void SetCommand(Command command)
    {
        cmds.Add(command);
    }
 
    public void Run()
    {
        foreach (Command command in cmds)
        {
            command.Execute();
        }
    }
 
}