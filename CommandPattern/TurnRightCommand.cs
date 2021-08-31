// 向右轉的命令
class TurnRightCommand : Command
{
    public TurnRightCommand(ReceiverRobot robot)
        : base(robot)
    {
    }
 
    public override void Execute()
    {
        robot.TurnRight();
    }
}