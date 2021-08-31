using System;

namespace DesignPattern_thomas
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeTempleteMethod();
            TeaTempleteMethod();
            // CommanPattern();
            // CommanPattern1();
        }

        #region TempleteMethod
        static void CoffeeTempleteMethod()
        {
            Console.WriteLine("=====================");
            Console.WriteLine("Coffee TempleteMethod.");
            Console.WriteLine("=====================");
            CoffeeWithHook coffee = new CoffeeWithHook();
            coffee.prepareRecipe();
        }

        static void TeaTempleteMethod()
        {
            Console.WriteLine("=====================");
            Console.WriteLine("Tea TempleteMethod.");
            Console.WriteLine("=====================");
            TeaWithHook tea = new TeaWithHook();
            tea.prepareRecipe();
        }
        #endregion
        #region Command Pattern
        static void CommanPattern()
        {
            Console.WriteLine("Command Pattern.");
            Console.WriteLine("=====================");
            // 初始化各個物件
            Invoker invoker = new Invoker(); // 發命令物件
            ReceiverRobot robot = new ReceiverRobot(); // 執行命令物件

            GoAheadCommand cmd_go_ahead = new GoAheadCommand(robot); // 向前走指令
            TurnLeftCommand cmd_turn_left = new TurnLeftCommand(robot); // 左轉指令
            TurnRightCommand cmd_turn_right = new TurnRightCommand(robot); // 右轉指令
            TurnBackCommand cmd_turn_back = new TurnBackCommand(robot); // 向後轉指令

            // 設定要執行的命令
            invoker.SetCommand(cmd_go_ahead);
            invoker.SetCommand(cmd_go_ahead);
            invoker.SetCommand(cmd_turn_left);
            invoker.SetCommand(cmd_go_ahead);
            invoker.SetCommand(cmd_turn_right);
            invoker.SetCommand(cmd_turn_back);
            invoker.SetCommand(cmd_go_ahead);

            // 開始執行命令
            invoker.Run();
            Console.WriteLine("=====================");
            Console.Read();
        }
        static void CommanPattern1()
        {
            var modifyPrice = new ModifyPrice();// 發命令物件
            var CurrentPrice = 30000;
            var product = new Product("iPhone 13", CurrentPrice);// 執行命令物件

            Console.WriteLine(product);
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 70));
            Console.WriteLine(product);
            Console.WriteLine("====取消命令====");
            modifyPrice.Undo();
            Console.WriteLine(product);
        }
        private static void Execute(ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
        #endregion
    }
}
