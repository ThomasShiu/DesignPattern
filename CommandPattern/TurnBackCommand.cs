// 向後轉的命令
public class TurnBackCommand : Command
{
    public TurnBackCommand(ReceiverRobot robot): base(robot)
    {
    }
 
    public override void Execute()
    {
        robot.TurnBack();
    }
}