
// 命令的抽像類別，用來衍生各種命令，建構時，須設定實際執行命令的物件
public abstract class Command
{
    protected ReceiverRobot robot;

    // 設定實際執行命令的物件
    public Command(ReceiverRobot robot)
    {
        this.robot = robot;
    }

    // 用來呼叫執行命令的物件，開始執行命令
    abstract public void Execute();
    //abstract public void Undo();
}