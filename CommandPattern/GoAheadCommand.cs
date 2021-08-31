
// 向前走一步的命令
public class GoAheadCommand : Command
{
    public GoAheadCommand(ReceiverRobot robot): base(robot)
    {
    }
 
    public override void Execute()
    {
        robot.GoAhead();
    }

}