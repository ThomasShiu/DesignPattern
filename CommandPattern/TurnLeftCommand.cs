// 向左轉的命令
public class TurnLeftCommand : Command
{
    public TurnLeftCommand(ReceiverRobot robot)
        : base(robot)
    {
    }
 
    public override void Execute()
    {
        robot.TurnLeft();
    }
}