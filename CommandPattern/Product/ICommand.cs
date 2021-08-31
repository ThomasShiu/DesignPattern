// 命令的介面，用來衍生各種命令，建構時，須設定實際執行命令的物件
public interface ICommand
{
    void ExecuteAction();
    void UndoAction();
}
